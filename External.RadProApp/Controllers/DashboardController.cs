using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using External.RadProApp.Models;
using External.RadProApp.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.Controllers
{
    public class DashboardController : Controller
    {
        private ISiteRepository siteRepo;

        public DashboardController(ISiteRepository siteRepository)
        { siteRepo = siteRepository; }

        // GET: Dashboard
        public ActionResult Overview()
        {
            ViewBag.GoogleApiKey = ConfigurationManager.AppSettings["GoogleAPIKey"];
            ApplicationDbContext db = new ApplicationDbContext();
            var model = new UserIndexViewModel();

            if (User.IsInRole("Admin"))
            {
                PrepareSearchScreenForAdmin(model);
                ViewBag.Title = "Super User";
                ViewBag.Role = "Administrator";
               
                return View(model);
            }
            else if (User.IsInRole("Employee"))
            {
                //Employee Mapping List - Show All Contractors and SubContractors where 
                
                PrepareSearchScreen(model);
                ViewBag.Title = "Employee";
                return View(model);
            }
            else if (User.IsInRole("SubContractors"))
            {
               
                PrepareSearchScreen(model);
                ViewBag.Title = "Sub Contractor";
                return View(model);
            }
            else if (User.IsInRole("Contractor"))
            {
            
                PrepareSearchScreen(model);
                ViewBag.Title = "Contractor";
                return View(model);
            }
            else if (User.IsInRole("Vendor"))
            {
             
                PrepareSearchScreen(model);
                ViewBag.Title = "Vendor";
                return View(model);
            }
            else if (User.IsInRole("SiteOwner"))
            {
                
                PrepareSearchScreen(model);
                ViewBag.Title = "Site Owner";
                return View(model);
            }
            else
            {
                //When a new user register to the site, and you want update the controls for that user do that here.
                ViewBag.Title = "No Role Assigned!";
                ViewBag.InstructRole = "How you will use this site? (select one)";
                ViewBag.InstructMiles = "How many miles between your home location and the furthest site you manage?";
                PrepareSearchScreen(model);
                TempData["message"] = string.Format("Welcome, " + "Please select which best describes your role?");
                return View("../Dashboard/Overview", model);
            }
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            var model = new UserIndexViewModel();
            PrepareSearchScreen(model);
            return PartialView("_Header", model);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebar()
        {
            var model = new UserIndexViewModel();
            PrepareSearchScreen(model);
            return PartialView("_Sidebar", model);
        }

        #region Prepare Users -- Custom Globals for Each User Role -- Overides Account Security for Easy Implementation.
   

        //User Profile DB's -- NOT IDentity Tables
        private void PrepareSearchScreen(UserIndexViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var users = GetAll().Where(x => x.Id == userId).ToList();
            model.GetAllUsersForSearchScreen = users;
        }

        private void PrepareSearchScreenForAdmin(UserIndexViewModel model)
        {
            var users = GetAll().ToList();
            model.GetAllUsersForSearchScreen = users;
        }
        //Get the distance from the view where each postcode is within the radius of that user specifically.

        //Show the list of Users within the range specified by that radius


        public IEnumerable<ApplicationUser> GetAll()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Users;
        }

        public IEnumerable<Site> GetAllSites()
        {
            RadioDbContext db = new RadioDbContext();
            return db.Sites;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Roles;
        }
 
        #endregion
    }
   
}