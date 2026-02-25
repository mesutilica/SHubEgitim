using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCEgitimi.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
