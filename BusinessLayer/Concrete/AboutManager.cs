using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _AboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _AboutDAL = aboutDAL;
        }
        public void AboutAdd(About about)
        {
            _AboutDAL.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _AboutDAL.Delete(about);
        }

        public void AboutUpdate(About about)
        {
           _AboutDAL.Update(about);
        }

        public About GetByID(int id)
        {
            return _AboutDAL.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _AboutDAL.List();
        }

    }
}
