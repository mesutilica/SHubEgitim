using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Areas.Blog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Blog/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}