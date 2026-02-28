using BusinessLayer.Concrete;
using BusinessLayer.Security;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager WLM = new WriterLoginManager(new EfWriterDAL());
        // GET: Login
        AdminManager AM = new AdminManager(new EfAdminDAL());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            AdminManager AM = new AdminManager(new EfAdminDAL());
            bool result = AM.Login(admin.AdminUserName, admin.AdminPassword);

            if (result)
            {
                // Veritabanından rolü al
                string role = AM.GetByUserName(admin.AdminUserName).AdminRole;

                // FormsAuthenticationTicket oluştur
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                                // ticket versiyonu
                    admin.AdminUserName,              // kullanıcı adı
                    DateTime.Now,                     // oluşturulma zamanı
                    DateTime.Now.AddMinutes(30),      // expiration
                    false,                            // persistent
                    role                              // userData = rol
                );

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı!!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var response = Request["g-recaptcha-response"];
            const string secretKey = "6LexM_srAAAAAEoZJ0JConWJBHLanUCuHXSr2xTP";
            var client = new WebClient();
            var result = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            if (!status)
            {
                ViewBag.Error = "Lütfen Robot Olmadığınızı Doğrulayın";
                return View();
            }

            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writerUserInfo = WLM.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                Session["WriterName"] = writerUserInfo.WriterName;
                Session["WriterSurName"] = writerUserInfo.WriterSurName;
                Session["WriterID"] = writerUserInfo.WriterID;
                Session["WriterImage"] = writerUserInfo.WriterImage;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else 
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "HomePage");
        }
    }
}