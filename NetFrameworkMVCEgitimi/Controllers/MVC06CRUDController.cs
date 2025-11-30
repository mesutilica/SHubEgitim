using NetFrameworkMVCEgitimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC06CRUDController : Controller
    {
        private UyeContext db = new UyeContext();
        // GET: MVC06CRUD
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