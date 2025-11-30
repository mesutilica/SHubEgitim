using NetFrameworkMVCEgitimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        // GET: MVC05ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) // eğer modeldeki kurallara uyulmuşsa
            {
                // kayıt ekle
            }
            else
            {
                ModelState.AddModelError("", "Zorunlu Alanları Doldurunuz!");
            }
            return View(uye);
        }
    }
}