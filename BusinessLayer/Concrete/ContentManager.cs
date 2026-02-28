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
    public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;
        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void ContentAdd(Content content)
        {
             _contentDAL.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }


        public List<Content> GetList(string p)
        {
            return _contentDAL.List(x => x.ContentValue.Contains(p));
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDAL.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.List(x => x.WriterID == id);
        }

        public List<Content> GetContentList()
        {
            return _contentDAL.List();
        }
    }
}
