using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class ProjectInformation
    {
        public ProjectInformation()
        {

        }
        [Key]
        public int ProjectInformationId { get; set; }
        public string RiggingPlanNumber { get; set; }
        public string CompletedBy { get; set; }
        public string BUNumber { get; set; }
        public string SiteAddress { get; set; } //Site Address
        public string RevisionNo { get; set; }
        public string SiteName { get; set; } // SiteName
        public string Latitude { get; set; } // Site Lat
        public string Longitude { get; set; } // Site Long
        public string AppNo { get; set; }
        public DateTime ProjectInormationDateTime { get; set; }

        //Inherit From Collections -- Each should be its own table
        //public virtual IEnumerable<ClassType> ClassTypes {get; set;}
        //public List<string> RiggingPlanClassDefinition { get; set; } 

        //public List<string> CompetentPerson { get; set; }
        //public List<string> ContactName { get; set; }
        //public List<string> Company { get; set; }
        //public List<string> Phone { get; set; }

        //public List<string> DesignEngineerOfRecord { get; set; }

        public string EORProjectNo { get; set; }
    }
}
