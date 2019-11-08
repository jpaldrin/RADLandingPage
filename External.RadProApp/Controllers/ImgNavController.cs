using DAL.Radio.IRepository;
using DAL.Radio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.Controllers
{
    public class ImgNavController : Controller
    {
        private IImgRepository siteRepo;

        public ImgNavController(IImgRepository siteRepository)
        { siteRepo = siteRepository; }

        public PartialViewResult Menu(string category = null)
        {

            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = siteRepo.ImgObjs
                            .Select(x => x.FileName)
                            .Distinct()
                            .OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
    }
}
