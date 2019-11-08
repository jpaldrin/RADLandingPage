using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class Employee
    {
        public Employee()
        {
            Certificates = new List<Certificates>();
            ImgObjs = new List<ImgObj>();
            ContractorProfiles = new List<ContractorProfile>();
        }
        [Key]
        public int EmployeeId { get; set; }
        //
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Log { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string WhatsApp { get; set; }
        //
        public virtual ICollection<Certificates> Certificates { get; set; }
        public virtual ICollection<ImgObj> ImgObjs { get; set; }
        public virtual ICollection<ContractorProfile> ContractorProfiles { get; set; }
    }
}
