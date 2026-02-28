using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDAL());
        public ActionResult Index()
        {
            var aboutValues = am.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            am.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}