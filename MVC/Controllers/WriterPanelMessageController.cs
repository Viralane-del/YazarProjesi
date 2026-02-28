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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDAL());
        MessageValidator messagevalidator = new MessageValidator();
        public ActionResult Inbox(string m)
        {
            m = (string)Session["WriterMail"];
            var messageValues = mm.GetListInbox(m);
            return View(messageValues);
        }
        public ActionResult Sendbox(string m)
        {
            m = (string)Session["WriterMail"];
            var messageValues = mm.GetListSendbox(m);
            return View(messageValues);
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
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sender;
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
        public PartialViewResult MessageListWriterMenu()
        {
            return PartialView();
        }
        public PartialViewResult MessageListWriterMenu2() 
        {
            return PartialView();
        }
        public PartialViewResult MessageListWriterMenu3()
        {
            return PartialView();
        }
        public PartialViewResult MessageListWriterMenu4()
        {
            return PartialView();
        }
        public PartialViewResult MessageListWriterMenu5()
        {
            return PartialView();
        }
    }
}