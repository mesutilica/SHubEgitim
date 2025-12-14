using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        public IActionResult Index()
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
