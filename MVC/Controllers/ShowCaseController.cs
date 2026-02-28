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
    [AllowAnonymous]
    public class ShowCaseController : Controller
    {
        Context c = new Context();
        // GET: ShowCase
        public ActionResult Index()
        {            
            return View();
        }
        public PartialViewResult ProjectAbout() 
        {
            var values = c.ProjectAbouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult ProjectWhatIdo()
        {   var values = c.ProjectWhatIdos.ToList();
            return PartialView(values);
        }
        public PartialViewResult ProjectGallery() 
        {
            var values = c.ProjectGalleries.ToList();
            return PartialView(values);
        }
        public PartialViewResult ProjectStatistic()
        {
            var totalHeading = c.Headings.Count();
            ViewBag.totalheading = totalHeading;
            var totalContent = c.Contents.Count();
            ViewBag.totalcontent = totalContent;
            var totalWriter = c.Writers.Count();
            ViewBag.totalwriter = totalWriter;
            var totalMessage = c.Messages.Count();
            ViewBag.totalmessage = totalMessage;
            return PartialView();
        }
        public PartialViewResult ProjectTestimonial()
        {
            var values = c.ProjectTestimonials.ToList();
            return PartialView(values);
        }
    }
}