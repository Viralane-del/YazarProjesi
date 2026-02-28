using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager( new EfContactDAL());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id) 
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult MessageNavbar()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
        public ActionResult MessageNavbar2()
        {
            var contactCount1 = cm.GetList().Count();
            ViewBag.ContactCount1 = contactCount1;
            return PartialView();
        }
    }
}