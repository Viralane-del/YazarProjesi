using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        Context c = new Context();

        public ActionResult Index()
        {
           var skillValues = c.Skills.ToList();
            return View(skillValues);
        }
    }
}