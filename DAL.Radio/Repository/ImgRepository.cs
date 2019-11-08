using DAL.Radio.Context;
using DAL.Radio.IRepository;
using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.Repository
{
    public class ImgRepository : IImgRepository
    {
        RadioDbContext db;
        public ImgRepository(RadioDbContext db) { this.db = db; }

        public IEnumerable<ImgObj> GetImgObjs { get { return db.ImgObjs; } }

        public IQueryable<ImgObj> ImgObjs { get { return db.ImgObjs; } set { throw new NotImplementedException(); } }

        public int AddImgObj(ImgObj obj)
        {
            db.ImgObjs.Add(obj);
            db.SaveChanges();
            return 0;
        }

        public bool Delete(ImgObj site)
        {
            db.ImgObjs.Remove(site);
            return true;
        }

        public IEnumerable<ImgObj> GetAll()
        {
            return db.ImgObjs;
        }

        public ImgObj GetImgObjById(int id)
        {
            return db.ImgObjs.Find(id);
        }

        public bool Update(ImgObj site)
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
