using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using External.RadProApp.Models;
using External.RadProApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace External.RadProApp.Controllers
{
    public class ImageController : Controller
    {
        private ISiteRepository siteRepository;
        private IImgRepository imgRepository;
        public int PageSize = 4;
        public ImageController(IImgRepository imgRepo, ISiteRepository siteRepo)
        {
            siteRepository = siteRepo;
            imgRepository = imgRepo;
        }

        private RadioDbContext db = new RadioDbContext();
        // GET: Image
        public ViewResult List(string category, int page = 1)
        {

            ImageListViewModel viewModel = new ImageListViewModel
            {
                Images = imgRepository.ImgObjs
                    .Where(p => category == null || p.FileName == category)
                    .OrderBy(p => p.ImgObjId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        imgRepository.ImgObjs.Count() :
                        imgRepository.ImgObjs.Where(e => e.FileName == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            ImgObj prod = imgRepository.ImgObjs
                .FirstOrDefault(p => p.ImgObjId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.FileContentType);
            }
            else
            {
                return null;
            }
        }
    }
}