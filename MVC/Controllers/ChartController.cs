using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MVC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList() 
        {
           List<CategoryClass> ct = new List<CategoryClass>();

            ct.Add(new CategoryClass()
            {
                CategoryCount = 8,
                CategoryName = "Yazılım"
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 4,
                CategoryName = "Seyehat"
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 7,
                CategoryName = "Teknoloji"
            });
            ct.Add(new CategoryClass()
            {
                CategoryCount = 3,
                CategoryName = "Spor"
            });
            return ct;
        }
    }
}