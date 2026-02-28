using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        // GET: HomePage
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        ContentManager cm = new ContentManager(new EfContentDAL());
        public ActionResult Headings() 
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id)
        {
            var contentList = cm.GetListByHeadingID(id); 
            return PartialView(contentList);
        }
    }
}