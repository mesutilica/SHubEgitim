using NetFrameworkMVCEgitimi.Models;
using System.Linq;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Areas.Admin.Controllers
{
    [Authorize] // bu controllerdaki tüm action ları korumaya al ve oturum açılmadan kullanılmasını engelle.
    public class UyelerController : Controller
    {
        private UyeContext db = new UyeContext();
        // GET: Admin/Uyeler
        public ActionResult Index()
        {
            return View(db.Uyeler.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Uyeler.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Uyeler.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = System.Data.Entity.EntityState.Modified; // ekrandan gelen uye nesnesinin ef deki kayıt durumunu güncellenecek olarak işaretle
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }
        public ActionResult Details(int id)
        {
            return View(db.Uyeler.Find(id));
        }
        public ActionResult Delete(int id)
        {
            return View(db.Uyeler.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, Uye uye)
        {
            // uye = db.Uyeler.Find(id);
            // db.Uyeler.Remove(uye);

            db.Entry(uye).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}