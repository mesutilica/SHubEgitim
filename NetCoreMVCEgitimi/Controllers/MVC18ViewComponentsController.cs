using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC18ViewComponentsController : Controller
    {
        private readonly UyeContext _context;

        public MVC18ViewComponentsController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();//_context.Uyeler
        }
    }
}
