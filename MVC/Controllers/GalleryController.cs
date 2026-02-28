using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ıfm = new ImageFileManager(new EfImageFileDAL());
        public ActionResult Index()
        {
            var imageFiles = ıfm.GetImagesList();
            return View(imageFiles);
        }
    }
}