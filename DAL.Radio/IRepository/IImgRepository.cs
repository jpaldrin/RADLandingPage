using DAL.Radio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Radio.IRepository
{
    public interface IImgRepository : IDisposable
    {
        IEnumerable<ImgObj> GetImgObjs { get; }
        IEnumerable<ImgObj> GetAll();
        IQueryable<ImgObj> ImgObjs { get; set; }
        ImgObj GetImgObjById(int id);
        int AddImgObj(ImgObj site);
        bool Update(ImgObj site);
        bool Delete(ImgObj site);
    }
}
