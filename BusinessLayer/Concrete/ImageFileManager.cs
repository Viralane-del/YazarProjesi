using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager:IImageFileService
    {
        IImageFileDAL _imageFileDAL;
        public ImageFileManager(IImageFileDAL imageFileDAL)
        {
            _imageFileDAL = imageFileDAL;
        }

        public List<ImageFile> GetImagesList()
        {
            return _imageFileDAL.List();
        }
    }
}
