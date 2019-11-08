using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.IRepository
{
    public interface ISiteRepository : IDisposable
    {
        IEnumerable<Site> GetSites { get; }
        IEnumerable<Site> GetAll();
        IQueryable<Site> Sites { get; set; }
        IQueryable<Site> QuerySites();
        Site GetSiteById(int id);
        Site Add(Site item);
        bool Update(Site site);
        bool Delete(int id);
    }
}
