using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class Site
    {
        public Site()
        {
            ImgObjs = new List<ImgObj>();
            ContractorProfiles = new List<ContractorProfile>();
            SiteOwners = new List<SiteOwner>();
            RiggingPlans = new List<RiggingPlan>();
        }

        [Key]
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string AppNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Post { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
        public string ProjectType { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string SiteClass { get; set; }
        public string SiteType { get; set; }
        public string PlanYear { get; set; }
        public string Market { get; set; }
        public string Vendor { get; set;}
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Region { get; set; }

        public virtual ICollection<ImgObj> ImgObjs { get; set; }
        public virtual ICollection<ContractorProfile> ContractorProfiles { get; set; }
        public virtual ICollection<SiteOwner> SiteOwners { get; set; }
        public virtual ICollection<RiggingPlan> RiggingPlans { get; set; }
    }
}
