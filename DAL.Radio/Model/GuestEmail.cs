using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Radio.Model
{
    public class GuestEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string UserIpAddress { get; set; }
        public string Status { get; set; }
    }
}
