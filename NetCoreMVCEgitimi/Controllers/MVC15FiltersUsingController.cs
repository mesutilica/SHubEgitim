using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCEgitimi.Extensions;
using NetCoreMVCEgitimi.Filters;
using NetCoreMVCEgitimi.Models;
using System.Security.Claims;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext db = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [UserControl]
        public ActionResult UyelikBilgilerim()
        {
            return View();
        }
        [UserControl]
        [Authorize]
        public ActionResult UyeGuncelle()
        {
            Uye uye = HttpContext.Session.GetJson<Uye>("uye");
            return View(uye);
        }
        [HttpPost]
        [UserControl]
        [Authorize] // .net oturum açma kontrol attribute ü
        public ActionResult UyeGuncelle(Uye uye)
        {
            Uye kullanici = HttpContext.Session.GetJson<Uye>("uye");
            if (ModelState.IsValid)
            {
                kullanici.Ad = uye.Ad;
                kullanici.Soyad = uye.Soyad;
                kullanici.Email = uye.Email;
                kullanici.Telefon = uye.Telefon;
                kullanici.TcKimlikNo = uye.TcKimlikNo;
                kullanici.DogumTarihi = uye.DogumTarihi;
                kullanici.KullaniciAdi = uye.KullaniciAdi;
                kullanici.Sifre = uye.Sifre;
                kullanici.SifreTekrar = uye.SifreTekrar;

                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UyeGuncelle");
            }
            return View(uye);
        }
        public ActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            try
            {
                var kullanici = db.Uyeler.FirstOrDefault(u => u.Email == uye.Email && u.Sifre == uye.Sifre);
                if (kullanici != null)
                {
                    HttpContext.Session.SetJson("uye", kullanici);
                    var haklar = new List<Claim>() // kullanıcı hakları tanımladık
                    {
                        new(ClaimTypes.Email, kullanici.Email), // claim = hak(kullanıcıya tanımlalan haklar)
                        new(ClaimTypes.Role, "Admin")
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcı için bir kimlik oluşturduk
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    HttpContext.SignInAsync(claimsPrincipal); // yukardaki yetkilerle sisteme giriş yaptık
                    if (!string.IsNullOrEmpty(Request.Query["ReturnUrl"])) // eğer adres çubuğunda ReturnUrl diye bir değer varsa
                    {
                        return Redirect(Request.Query["ReturnUrl"]); // oturum açıldıktan sonra kullanıcıyı kaldığı yere dönürmek için returnurl deki adrese yönlendir
                    }
                    return RedirectToAction("Index"); // ReturnUrl boşsa anasayfaya yönlendir
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(uye);
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
