using External.RadProApp.ViewModel;
using External.RadProApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Reflection;
using System;

namespace External.RadProApp.Controllers
{
    [RequireHttps]
    [Authorize]
    public class UsersAdminController : Controller
    {
        public UsersAdminController()
        {
        }

        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Users/
        [HttpGet]
        public ActionResult Index()
        {
            var allUsers = UserManager.Users.ToListAsync();
            var removeUserAdminRole = RoleManager.Roles.Where(c => c.Name != "Admin");
            var model = new UserIndexViewModel();

            if (User.IsInRole("Admin"))
            {
                PrepareSearchScreenForAdmin(model);
            }
            else
            {
                PrepareSearchScreen(model);
            }

            TempData["message"] = string.Format("User Screen Loaded");
            return View(model);
        }
        #region Prepare Users --
        private void PrepareSearchScreenForAdmin(UserIndexViewModel model)
        {
            var users = GetAll().ToList();
            model.GetAllUsersForSearchScreen = users;
        }
        private void PrepareSearchScreen(UserIndexViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var users = GetAll().Where(x => x.Id == userId).ToList();
            model.GetAllUsersForSearchScreen = users;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Users;
        }
        #endregion
        //
        // GET: /Users/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);

            return View(user);
        }

        //
        // GET: /Users/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email =
                    userViewModel.Email,
                    // Add the Address Info:
                    Address = userViewModel.Address,
                    City = userViewModel.City,
                    State = userViewModel.State,
                    PostalCode = userViewModel.PostCode
                };

                // Add the Address Info:
                user.Address = userViewModel.Address;
                user.City = userViewModel.City;
                user.State = userViewModel.State;
                user.PostalCode = userViewModel.PostCode;

                // Then create:
                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                    return View();
                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }
        //
        // GET: /Users/Edit/1
        [HttpGet]
        public async Task<ActionResult> Edit(string id, string radius)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoogleApiKey = ConfigurationManager.AppSettings["GoogleAPIKey"];
            
            var users = RoleManager.Roles.ToList();
            var removeUserAdminRole = RoleManager.Roles.Where(c => c.Name != "Admin");
            var userRoles = await UserManager.GetRolesAsync(user.Id);
           
            if (User.IsInRole("Admin"))
            {
                return View(new EditUserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    // Include the Addresss info:
                    FName = user.FName,
                    LName = user.LName,
                    Telephone = user.Telephone,
                    Address = user.Address,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.PostalCode,
                    ImageData = user.ImageData,
                    ImageMimeType = user.ImageMimeType,
                    Longitude = user.Longitude,
                    Latitude = user.Latitude,
                    Radius = user.Radius,
                    RolesList = RoleManager.Roles.Select(x => new SelectListItem()
                    {
                        Selected = userRoles.Contains(x.Name),
                        Text = x.Name,
                        Value = x.Name
                    })
                }); 
            }
            else
            {
                return View(new EditUserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    // Include the Addresss info:
                    FName = user.FName,
                    LName = user.LName,
                    Telephone = user.Telephone,
                    Address = user.Address,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.PostalCode,
                    ImageData = user.ImageData,
                    ImageMimeType = user.ImageMimeType,
                    Longitude = user.Longitude,
                    Latitude = user.Latitude,
                    Radius = user.Radius,
                    RolesList = removeUserAdminRole.Select(x => new SelectListItem()
                    {
                        Selected = userRoles.Contains(x.Name),
                        Text = x.Name,
                        Value = x.Name
                    })
                });
            }
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include =
    "FName,LName,Telephone,Email,Id,Address,City,State,PostalCode,Latitude,Longitude,Radius")]
    EditUserViewModel editUser, HttpPostedFileBase image = null, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.FName = editUser.FName;
                user.LName = editUser.LName;
                user.Telephone = editUser.Telephone;
                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                user.Address = editUser.Address;
                user.City = editUser.City;
                user.State = editUser.State;
                user.PostalCode = editUser.PostalCode;
                user.Latitude = editUser.Latitude;
                user.Longitude = editUser.Longitude;
                user.Radius = editUser.Radius;

                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                }

                var userRoles = await UserManager.GetRolesAsync(user.Id);
                selectedRole = selectedRole ?? new string[] { };
                var result = await UserManager.AddToRolesAsync(user.Id,
                    selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = await UserManager.RemoveFromRolesAsync(user.Id,
                    userRoles.Except(selectedRole).ToArray<string>());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        
        //
        // GET: /Users/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //private ApplicationUser PrepareUpdateUser(EditUserViewModel model)
        //{
        //    var detail = new ApplicationUser();
        //    detail.Id = model.Id;
        //    detail.Email = model.Email;
        //    detail.FName = model.FName;
        //    detail.LName = model.LName;
        //    detail.Address = model.Address;
        //    detail.City = model.City;
        //    detail.State = model.State;
        //    detail.PostalCode = model.PostalCode;
        //    detail.PhoneNumber = model.Telephone;
        //    detail.UserName = model.Email;
        //    detail.ImageData = model.ImageData;
        //    detail.ImageMimeType = model.ImageMimeType;
        //    return detail;
        //}

        //
        // POST: /Users/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        public FileContentResult GetImage(string id)
        {
            ApplicationUser img = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            if (img != null)
            {
                return File(img.ImageData, img.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            bool isValidName = false;
            string keyValue = string.Format("{0}:{1}", Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);
            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                isValidName = true;
            }
            return isValidName;
        }
    }
}
