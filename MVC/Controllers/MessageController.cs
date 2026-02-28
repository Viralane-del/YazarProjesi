using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDAL());
        MessageValidator messagevalidator = new MessageValidator();
        ContactManager cm = new ContactManager(new EfContactDAL());
        public ActionResult Inbox(string m)
        {
            var messageValues = mm.GetListInbox(m);
            return View(messageValues);
        }
        public ActionResult Sendbox(string m)
        {
            m = (string)Session["WriterMail"];
            var messageValues = mm.GetListSendbox(m);
            return View(messageValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messagevalidator.Validate(message);
            if (results.IsValid) 
            {
                message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult TaskMessage()
        {
            var taskMessageValues = mm.GetListTask();
            return View(taskMessageValues);
        }
        [HttpPost]
        public ActionResult TaskMessage(Message message)
        {
            var taskMessageValues = mm.GetListTask();
            return View(taskMessageValues);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
        public PartialViewResult MessageListMenu()
        {
             var contactCount = cm.GetList().Count();
             ViewBag.ContactCount = contactCount;
             return PartialView();
        }
        public PartialViewResult MessageListMenu2()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
        public PartialViewResult MessageListMenu3() 
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
        public PartialViewResult MessageListMenu4()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
        public PartialViewResult MessageListMenu5()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
        public PartialViewResult MessageListMenu6()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;
            return PartialView();
        }
    }
}