using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Extensions;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC12SessionController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                //Session["deger"] = "Admin"; //mvc de sessiona veri atma
                //Session["userguid"] = Guid.NewGuid().ToString();
                //Session["username"] = kullanici.KullaniciAdi;
                //Session["kullanici"] = kullanici;
                HttpContext.Session.SetString("deger", "Admin"); //mvc de sessiona veri atma
                HttpContext.Session.SetString("userguid", Guid.NewGuid().ToString());
                HttpContext.Session.SetString("username", kullanici.KullaniciAdi);
                HttpContext.Session.SetString("kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz

                HttpContext.Session.SetInt32("kullaniciId", kullanici.Id);

                HttpContext.Session.SetJson("uye", kullanici); // kullanici nesnesini uye adıyla json formatında saklıyoruz.

                return RedirectToAction("SessionOku");
            }
            else
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            }
            return View("Index");
        }
        public ActionResult SessionOku()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("userguid") == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }

            TempData["kullaniciAdi"] = HttpContext.Session.GetString("username");
            TempData["kullaniciguid"] = HttpContext.Session.GetString("userguid");
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger"); // deger isimli sessionu süresini beklemeden sil
            //Session["userguid"] = null;
            HttpContext.Session.Clear(); // tüm sessionları sil
            return RedirectToAction("Index");
        }
    }
}
