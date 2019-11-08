using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace External.RadProApp.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}