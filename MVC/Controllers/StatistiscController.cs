using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MVC.Controllers
{
    public class StatistiscController : Controller
    {
        // GET: Statistisc
        
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Categories.Count();
            ViewBag.d1 = value1;
            var value2 = c.Writers.Count(x => x.WriterName != null && x.WriterName.Contains("a"));
            ViewBag.d2 = value2;
            var value3 = c.Headings.Count(x => x.CategoryID == 11);
            ViewBag.d3 = value3;
            var value4 = c.Categories.OrderByDescending(x => x.Headings.Count).Select( y => y.CategoryName).FirstOrDefault();
            ViewBag.d4 = value4;
            var value5 = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(y => y.CategoryStatus == false);
            ViewBag.d5 = value5;
            return View();
        }
    }
}