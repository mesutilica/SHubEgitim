using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UyelerController : Controller
    {
        private readonly UyeContext _context;

        public UyelerController(UyeContext context)
        {
            _context = context;
        }

        // GET: UyelerController
        public ActionResult Index()
        {
            return View(_context.Uyeler);
        }

        // GET: UyelerController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Uyeler.Find(id));
        }

        // GET: UyelerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UyelerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uye uye)
        {
            if (ModelState.IsValid)
            {
                // senkron ekleme
                //_context.Uyeler.Add(uye);
                //_context.SaveChanges();

                // asenkron ekleme
                _context.Uyeler.AddAsync(uye);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(uye);
        }

        // GET: UyelerController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            // var model = _context.Uyeler.Find(id);
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        // POST: UyelerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(uye);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(uye);
        }

        // GET: UyelerController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        // POST: UyelerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Uye collection)
        {
            try
            {
                _context.Uyeler.Remove(collection);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
