namespace DAL.Radio.Repository
{
    using DAL.Radio.Context;
    using DAL.Radio.IRepository;
    using DAL.Radio.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class EmailRepository : IEmailRepository
    {
        RadioDbContext db = new RadioDbContext();
        public IEnumerable<Email> GetContacts
        {
            get { return db.Emails; }
        }

        public int AddLease(Email entity)
        {
            db.Emails.Add(entity);
            db.SaveChanges();
            return 0;
        }
 
        public Email GetEmailsById(long id)
        {
            return db.Emails.Find(id);
        }

        public bool Delete(Email entity)
        {
            db.Emails.Remove(entity);
            return true;
        }

        public IEnumerable<Email> GetAll()
        {
            return db.Emails;
        }

        public bool Update(Email entity)
        {
            db.Entry(entity).State = EntityState.Modified;
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
