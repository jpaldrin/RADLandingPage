using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using External.RadProApp.Helpers;
using External.RadProApp.Models;
using External.RadProApp.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace External.RadProApp.Controllers
{
    public class SiteAPIController : ApiController
    {
        private ISiteRepository siteRepository;
        private IImgRepository imgRepository;

        public SiteAPIController(IImgRepository imgRepo, ISiteRepository siteRepo)
        {
            siteRepository = siteRepo;
            imgRepository = imgRepo;
        }

        public SiteAPIController()
        {

        }

        private RadioDbContext db = new RadioDbContext();

        [HttpGet]
        [Route("api/getsite")]
        public DataTableResponse Get()
        {
            //IEnumerable<SiteViewModel> sites = null;

            //using (var ctx = new RadioDbContext())
            //{
            //    sites = ctx.Sites.Select(s => new SiteViewModel()
            //    {
            //        Id = s.SiteId,
            //        Name = s.Name,
            //        Address = s.Address,
            //        State = s.State,
            //        Post = s.Post,
            //        AppNo = s.AppNo,
            //        Category = s.Category,
            //        City = s.City,
            //        Latitude = s.Latitude,
            //        Longitude = s.Longitude

            //    }).ToList<SiteViewModel>();
            //}

            //var sites = db.Sites;
            var sites = db.Sites.ToList();

            return new DataTableResponse
            {
                recordsTotal = sites.Count(),
                data = sites.ToArray()
            };
        }

        //[Route("api/staff")]
        //[HttpGet]
        //[HttpPost]
        //public IHttpActionResult SiteApi() 


        public void GetAllSites(SiteViewModel model)
        {
            var sites = siteRepository.GetAll().ToList();
            model.GetAllSitesForOverview = sites;
        }

        //This method is consumed by DataTables - please update and edit all rows on the table!

        //[HttpGet]
        //public Site Get(int id)
        //{
        //    Site site = siteRepository.GetSiteById(id);
        //    if (site == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return site;
        //}

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Site site, HttpPostedFileBase image)
        {
            try
            {
                

                site.LastModified = DateTime.UtcNow;
                site.LastModifiedBy = User.Identity.Name;
                db.Sites.Add(site);
                db.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, site);
                message.Headers.Location = new Uri(Request.RequestUri + site.SiteId.ToString());
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Site site)
        {
            try
            {
                using (RadioDbContext context = new RadioDbContext())
                {
                    var entity = context.Sites.FirstOrDefault(e => e.SiteId == id);

                    if (entity != null)
                    {
                        entity.Name = site.Name;
                        entity.Address = site.Address;
                        entity.AppNo = site.AppNo;
                        entity.Category = site.Category;
                        entity.City = site.City;
                        entity.Latitude = site.Latitude;
                        entity.Longitude = site.Longitude;
                        entity.Post = site.Post;
                        entity.State = site.State;

                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity.Name + " has been updated!");
                    }
                    else 
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id " + entity.SiteId.ToString() + "Not found!");
                    }
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (RadioDbContext context = new RadioDbContext())
                {
                    var entity = context.Sites.FirstOrDefault(e => e.SiteId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Site Id =" + entity.SiteId + " was not found.");
                    }
                    else
                    {
                        context.Sites.Remove(context.Sites.FirstOrDefault(e => e.SiteId == id));
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public void GetPrimarySite(SiteViewModel model, int id)
        {

            var control = siteRepository.GetSiteById(id);
        }


    }
}
