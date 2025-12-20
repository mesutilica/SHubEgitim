using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC08PartialController : Controller
    {
        private UyeContext db = new UyeContext();
        public IActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }
    }
}
