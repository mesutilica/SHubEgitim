using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration; // bu
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        // GET: MVC14AppSetting
        public ActionResult Index()
        {
            ViewBag.Mesaj = $"Email: {WebConfigurationManager.AppSettings["Email"]}";
            ViewBag.Mesaj += $"<br>MailSunucu: {WebConfigurationManager.AppSettings["MailSunucu"]}";
            ViewBag.Mesaj += $"<br>UserName: {WebConfigurationManager.AppSettings["UserName"]}";
            ViewBag.Mesaj += $"<br>Password: {WebConfigurationManager.AppSettings["Password"]}";
            return View();
        }
    }
}