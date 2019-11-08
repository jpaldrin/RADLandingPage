using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.IRepository
{
    public interface IEmailRepository
    {
        IEnumerable<Email> GetContacts { get; }

        IEnumerable<Email> GetAll();

        int AddLease(Email entity);

        bool Update(Email entity);

        bool Delete(Email entity);
    }
}
