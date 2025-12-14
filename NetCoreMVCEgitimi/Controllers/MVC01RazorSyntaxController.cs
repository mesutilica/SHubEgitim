using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
