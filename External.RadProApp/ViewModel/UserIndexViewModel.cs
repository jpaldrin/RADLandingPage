using DAL.Radio.Model;
using External.RadProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace External.RadProApp.ViewModel
{
    public class UserIndexViewModel
    {
        public List<Site> GetAllSitesForOverview { get; set; }
        public List<ApplicationUser> GetAllUsersForSearchScreen { get; set; }
        public List<ApplicationUser> GetSiteOwnerDashboardEmployee { get; set; }
        public List<ApplicationUser> GetSiteOwnerDashboardSubContractor { get; set; }
        public List<ApplicationUser> GetSiteOwnerDashboardContractor { get; set; }
        public List<ApplicationUser> GetSiteOwnerDashboardOverview { get; set; }
        public List<ApplicationUser> GetSiteOwnerDashboardVendor { get; set; }
        public List<ApplicationUser> ListUserDetails { get; }
    }
}