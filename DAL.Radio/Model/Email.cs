using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Radio.Model
{
    public class Email
    {
        public Email()
        {
            ImgObjs = new HashSet<ImgObj>();
        }

        [Key]
        public int EmailId { get; set; }
        public string ToEmail { get; set; }
        public string EMailBody { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string UserId { get; set; }
        public DateTime SentDateTime { get; set; }
        public DateTime ReceivedDateTime { get; set; }
        
        public virtual ICollection<ImgObj> ImgObjs { get; set; }
    }
}
