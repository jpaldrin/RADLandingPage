using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Model
{
    public class Certificates
    {
        public Certificates()
        {
            ImgObjs = new List<ImgObj>();
        }

        [Key]
        public int CertificateId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedFrom { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        //
        public virtual ICollection<ImgObj> ImgObjs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
