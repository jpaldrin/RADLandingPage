using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class ImgObj
    {
        public ImgObj()
        {
            Sites = new List<Site>();
            SiteOwners = new List<SiteOwner>();
            Certificate = new List<Certificates>();
            Employees = new List<Employee>();
            Emails = new List<Email>();
            LandingPages = new HashSet<LandingPage>();
        }

        #region Properties  

        [Key]
        public int ImgObjId { get; set; }

        public string FileName { get; set; }

        public string FileContentType { get; set; }

        public byte[] ImageData { get; set; }

        #endregion

        public virtual ICollection<Site> Sites { get; set; }
        public virtual ICollection<Certificates> Certificate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SiteOwner> SiteOwners { get; set; }
        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<LandingPage> LandingPages { get; set; }
    }
}
