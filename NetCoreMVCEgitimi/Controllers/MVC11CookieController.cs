using Microsoft.AspNetCore.Mvc;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC11CookieController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString());

                var cookieAyarlari = new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(1) // cookie ye 1 dk lık bitiş süresi tanımladık
                };
                HttpContext.Response.Cookies.Append("username", kullaniciAdi, cookieAyarlari); // .net de HttpContext ile oluşturuyoruz
                return RedirectToAction("CookieOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] == null || HttpContext.Request.Cookies["userguid"] == null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Lütfen Giriş Yapınız!</div>";
                return RedirectToAction("Index");
            }
            TempData["kullaniciAdi"] = HttpContext.Request.Cookies["username"];
            TempData["kullaniciguid"] = HttpContext.Request.Cookies["userguid"];
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                HttpContext.Response.Cookies.Delete("username");
            }
            if (HttpContext.Request.Cookies["userguid"] != null)
            {
                HttpContext.Response.Cookies.Delete("userguid");
            }
            return RedirectToAction("CookieOku");
        }
    }
}
