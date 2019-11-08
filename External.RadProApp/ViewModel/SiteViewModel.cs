using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.ViewModel
{
    public class SiteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* A Site Name is Required")]
        public string Name { get; set; }

        public string Category { get; set; }
        public string AppNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "* Post Code is required.")]
        [DataType(DataType.PostalCode)]
        public string Post { get; set; }

        [Required(ErrorMessage = "* Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "* Version is required.")]
        public string Version { get; set; }

        [Required(ErrorMessage = "* Project Type is required")]
        public string ProjectType { get; set; }

        [Required(ErrorMessage = "* Valid Approval is required.")]
        public string ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage = "* Site Class is required")]
        public string SiteClass { get; set; }

        [Required(ErrorMessage = "* Site Type is required")]
        public string SiteType { get; set; }

        [Required(ErrorMessage = "* Plan Year is required")]
        public string PlanYear { get; set; }

        [Required(ErrorMessage = "* Market is required")]
        public string Market { get; set; }

        [Required(ErrorMessage = "* Vendor is required")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "* Latitude is not present")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "* Longitude is not present")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "* region is required")]
        public string Region { get; set; }

        public string ReturnUrl { get; set; }

        public List<string> ImgObjIds { get; set; }

        public List<Site> PopulateLatLong { get; set; }
        public List<Site> GetAllSitesForOverview { get; set; }

        [Display(Name = "Images")]
        public MultiSelectList ImageSelectableList { get; set; }
        public List<ImgObj> ImageListOfIds { get; internal set; }
    }

    public class ImageViewModel
    {
        public int ImageId { get; set; }

        [Required]
        [Display(Name = "Add a file name.")]
        public string FileName { get; set; }

        public string FileContentType { get; set; }

        public byte[] ImageData { get; set; }

     
        [Display(Name = "Category")]
        public string SiteCategory { get; set; }

        public string ReturnUrl { get; set; }

        public List<string> SiteIds { get; set; }

        [Display(Name = "Sites")]
        public MultiSelectList SitesList { get; set; }

    }

    public class EditSiteViewModel : SiteViewModel
    {
        public string ImgObjId { get; set; }
    }

    public class ContractorProfilesViewModel
    {
        public int SiteId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string EIN { get; set; }
        public string IsInsured { get; set; }
        public string HasWebsite { get; set; }
        public string IsContracted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<SiteViewModel> Sites { get; set; }
    }
}