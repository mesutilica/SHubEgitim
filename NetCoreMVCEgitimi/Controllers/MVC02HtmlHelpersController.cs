using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC02HtmlHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
