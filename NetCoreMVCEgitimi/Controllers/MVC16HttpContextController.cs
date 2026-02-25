using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var mesaj = "RouteData controller : " + RouteData.Values["controller"];
            mesaj += "<hr/>Action : " + RouteData.Values["action"];
            mesaj += "<hr/>Id : " + RouteData.Values["id"];
            mesaj += "<br />HttpContext.Request.Path : " + HttpContext.Request.Path;
            mesaj += "<hr/>QueryString Kelime : " + HttpContext.Request.Query["kelime"];
            TempData["mesaj"] = mesaj;
            return View();
        }
    }
}
