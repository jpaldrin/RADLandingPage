using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class ContractorProfile
    {
        public ContractorProfile()
        {
            Sites = new List<Site>();
            ImgObjs = new List<ImgObj>();
            Employees = new List<Employee>();
        }

        [Key]
        public int ContractorId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string EIN { get; set; }
        public string IsInsured { get; set; }
        public string HasWebsite { get; set; }
        public string IsContracted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<ImgObj> ImgObjs { get; set; }
    }
}
