using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL.Radio.Repository
{
    public class SiteRepository : ISiteRepository
    {
        RadioDbContext db = new RadioDbContext();
        public SiteRepository(RadioDbContext db) { this.db = db; }
        public IEnumerable<Site> GetSites { get { return db.Sites; } }

        private List<Site> sites = new List<Site>();
        private int _nextId = 1;
        public IQueryable<Site> Sites { get { return db.Sites; } set { throw new NotImplementedException(); } }

        public IQueryable<Site> QuerySites()
        {
            return db.Sites;
        }


        public Site Add(Site item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.SiteId = _nextId;
            db.Sites.Add(item);
            db.SaveChanges();
            return item;
        }
        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            sites.RemoveAll(p => p.SiteId == id);

            return true;
        }

        public IEnumerable<Site> GetAll()
        {
            return db.Sites
                .Include(x => x.ImgObjs)
                .Include(x => x.ContractorProfiles)
                .Include(x => x.SiteOwners)
                .Include(x => x.RiggingPlans);
        }

        public Site GetSiteById(int id)
        {
            return db.Sites.Find(id);
        }

        public bool Update(Site site)
        {
            db.Entry(site).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
