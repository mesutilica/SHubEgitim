using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models; // ViewComponent

namespace NetCoreMVCEgitimi.ViewComponents
{
    public class Uyeler : ViewComponent
    {
        private readonly UyeContext _context;

        public Uyeler(UyeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string secili)
        {
            ViewBag.Secili = secili;
            return View(_context.Uyeler);
        }
    }
}
