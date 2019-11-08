using DAL.Radio.Model;
using External.RadProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace External.RadProApp.ViewModel
{
    public class ImageListViewModel
    {
        public IEnumerable<ImgObj> Images { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}