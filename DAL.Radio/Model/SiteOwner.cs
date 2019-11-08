using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class SiteOwner
    {
        public SiteOwner()
        {
            Sites = new List<Site>();
        }

        [Key]
        public int SiteOwnerId { get; set; }
        public string Company { get; set; }
        public string EIN { get; set; }
        public string IsInsured { get; set; }
        public bool IsLocked { get; set; }
        public bool IsContracted { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}
