using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using DAL.Radio.Repository;
using External.RadProApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//https://github.com/filipwa84/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Services/Services/LinkedIn
namespace External.RadProApp.Controllers
{
    [Authorize]
    [RequireHttps]
    public class SiteController : Controller
    {
        private ISiteRepository siteRepository;
        private IImgRepository imgRepository;

        public SiteController(IImgRepository imgRepo, ISiteRepository siteRepo)
        {
            siteRepository = siteRepo;
            imgRepository = imgRepo;
        }

        private RadioDbContext db = new RadioDbContext();

        // GET: Site
        
        public ActionResult Index(SiteViewModel model)
        {
            GetAllSites(model);
            return View(model);
        }

        public ActionResult Details()
        {
            return View();
        }




        //Manager Page for Site with Collections
        public ActionResult Manager(int? id, HttpPostedFileBase image = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //setup data
            Site site = db.Sites.Find(id);
            //var img = site.ImgObjs.FirstOrDefault(i => i.Sites.Any(z => z.SiteId == id));
           
            var siteImages = db.Sites.Where(i => i.ImgObjs.Any(j => j.ImgObjId.Equals(site.SiteId))).ToList();

            //setup map
            var sites = db.Sites.ToList();

            SiteViewModel model = new SiteViewModel();
            model.Id = site.SiteId;
            model.Name = site.Name;
            model.Latitude = site.Latitude;
            model.Longitude = site.Longitude;
            model.PopulateLatLong = sites;
            model.Address = site.Address;
            model.AppNo = site.AppNo;
            model.Category = site.Category;
            model.City = site.City;
            model.Post = site.Post;
            model.State = site.State;
            model.Status = site.Status;
            model.Version = site.Version;
            model.ProjectType = site.ProjectType;
            model.ApprovedBy = site.ApprovedBy;
            model.LastModified = site.LastModified;
            model.LastModifiedBy = site.LastModifiedBy;
            model.SiteClass = site.SiteClass;
            model.SiteType = site.SiteType;
            model.PlanYear = site.PlanYear;
            model.Market = site.Market;
            model.Vendor = site.Vendor;
            model.Region = site.Region;

            if (siteImages != null)
            {
                // Initialize the array to number of products in optionProducts
                string[] optionProductsIds = new string[siteImages.Count];

                // Then, set the value of optionProducts.Count so the for loop doesn't need to work it out every iteration
                int length = siteImages.Count;

                // Now loop over each of the optionProducts and store the Id in the optionProductsIds array
                for (int i = 0; i < length; i++)
                {   // Note that we employ the ToString() method to convert the int to a string
                    optionProductsIds[i] = siteImages[i].SiteId.ToString();
                }

                // Instantiate the MultiSelectList, plugging in our optionProductsIds array
                MultiSelectList productList = new MultiSelectList(db.ImgObjs.ToList().OrderBy(i => i.FileName), "ImgObjId", "FileName", optionProductsIds);

                // Now add the productList to the Product property of our EditOptionVM (model)
                model.ImageSelectableList = productList;
                model.ImageListOfIds = site.ImgObjs.ToList();
                GetAllSites(model);
                // Return the ViewModel
                return View(model);
            }
            else
            {
                MultiSelectList productList = new MultiSelectList(db.ImgObjs.ToList().OrderBy(i => i.FileName), "ImgObjId", "FileName");
                model.ImageSelectableList = productList;
                GetAllSites(model);
                return View(model);
            }
        }

        //SEND-OVER TO WEB API

        [ChildActionOnly]
        public ActionResult AddNewImageFolder()
        {
            //ViewBag.AzureMapsKey = ConfigurationManager.AppSettings["Subscription_Key"];
            //ViewBag.AuthType = ConfigurationManager.AppSettings["Maps_Key"];

            var sites = db.Sites.ToList();
            List <SelectListItem> imgItems = new List<SelectListItem>();

            foreach (var site in sites)
            {
                var item = new SelectListItem
                {

                    Value = site.SiteId.ToString(),
                    Text = site.Name,
                  
                };
                imgItems.Add(item);
            }
            MultiSelectList imgList = new MultiSelectList(imgItems.OrderBy(i => i.Text), "Value", "text");

            ImageViewModel model = new ImageViewModel { SitesList = imgList };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult AddNewImageFolder([Bind(Include = "FileName, SiteIds")] ImageViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                ImgObj img = new ImgObj
                {
                    ImgObjId = model.ImageId,
                    FileName = model.FileName,
                };

                img.FileContentType = image.ContentType;
                img.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(img.ImageData, 0, image.ContentLength);
                  
                if (model.SiteIds != null)
                {
                    foreach (var id in model.SiteIds)
                    {
                        var siteId = int.Parse(id);
                        var site = db.Sites.Find(siteId);
                     
                        try
                        {
                            img.Sites.Add(site);
                        }
                        catch(Exception ex)
                        {
                            return RedirectToAction("Error", new HandleErrorInfo(ex, "Site", "Manager"));
                        }
                    }
                }
                try
                {
                    db.ImgObjs.Add(img);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", new HandleErrorInfo(ex, "Site", "Manager"));
                }
                TempData["message"] = string.Format("{0} has been included.", img.FileName);
                return RedirectToAction("Manager", new SiteViewModel { ReturnUrl = model.ReturnUrl });
            }
            TempData["Errmessage"] = string.Format("Failure.");
            return RedirectToAction("Manager", new SiteViewModel { ReturnUrl = model.ReturnUrl });
        }

        public ActionResult Edit(int? id, HttpPostedFileBase image = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = db.Sites.Find(id);

            SiteViewModel model = new SiteViewModel();

            model.Name = site.Name;

            if (site == null)
            {
                TempData["ErrMessage"] = string.Format("There is no site to delete!");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site option = db.Sites.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site option = db.Sites.Find(id);
            db.Sites.Remove(option);
            TempData["ErrMessage"] = string.Format("{0} has been deleted.", option.Name);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {

            ImgObj site = db.ImgObjs.Find(id);

             
            if (site != null)
            {
              
                return File(site.ImageData, site.FileContentType);
            }
            else
            {
                return null;
            }
        }

        public void GetAllSites(SiteViewModel model)
        {
            var sites = siteRepository.GetAll().ToList();
            model.GetAllSitesForOverview = sites;
        }
    }
}