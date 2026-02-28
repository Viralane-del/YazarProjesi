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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDAL());
        public ActionResult Index()
        {
            var adminValues = am.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            am.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = am.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            am.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = am.GetByID(id);
            am.AdminDelete(adminValue);
            if (adminValue.AdminStatus == true)
            {
                adminValue.AdminStatus = false;
                am.AdminDelete(adminValue);
            }
            else
            {
                adminValue.AdminStatus = true;
                am.AdminDelete(adminValue);
            }
            return RedirectToAction("Index");
        }
    }
}