using NetFrameworkMVCEgitimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        // GET: MVC09ViewResults
        private UyeContext db = new UyeContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public ActionResult Yonlendir()
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            // return Redirect("/Home");
            return Redirect("https://www.google.com.tr/");
        }
        public ActionResult ActionaYonlendir()
        {
            // Bir action içerisinde farklı bir action a yönlendirme yapabiliriz
            // return RedirectToAction("Index");
            // return RedirectToAction("FarkliViewDondur");
            return RedirectToAction("Index", "Home");
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            // Bir action içerisinde bir Route a yönlendirme yapabiliriz
            return RedirectToRoute("Default", new {controller = "Home", action = "Index", id = 18});
        }
        public PartialViewResult KategorileriGetirPartial()
        {
            return PartialView("_PartialMenu");
        }
        public PartialViewResult PartialdaModelKullanimi()
        {
            var kullanicilar = db.Uyeler.ToList();
            return PartialView("_PartialModelKullanimi", kullanicilar);
        }
        public ActionResult JsResult()
        {
            return JavaScript("console.warn('JavaScript result')");
        }
        public ActionResult JsonResult()
        {
            var kullanicilar = db.Uyeler.ToList();
            return Json(kullanicilar, JsonRequestBehavior.AllowGet);
        }
        public ContentResult XmlContentResult()
        {
            var kullanicilar = db.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in kullanicilar)
            {
                xml += $@"<kullanici>
                        <Id>{item.Id}</Id>
                        <Ad>{item.Ad}</Ad>
                        <Soyad>{item.Soyad}</Soyad>
                        <KullaniciAdi>{item.KullaniciAdi}</KullaniciAdi>
                        <Email>{item.Email}</Email>
                    </kullanici>";
            }
            xml += "</kullanicilar>";
            return Content(xml, "application/xml");
        }
    }
}