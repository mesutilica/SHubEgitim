using NetFrameworkMVCEgitimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC08PartialController : Controller
    {
        // GET: MVC08Partial
        private UyeContext db = new UyeContext();
        public ActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }
    }
}