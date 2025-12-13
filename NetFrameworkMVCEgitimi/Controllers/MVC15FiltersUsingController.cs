using NetFrameworkMVCEgitimi.Filters; // UserControl using
using NetFrameworkMVCEgitimi.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace NetFrameworkMVCEgitimi.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext db = new UyeContext();
        // GET: MVC15FiltersUsing
        public ActionResult Index()
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
            Uye uye = Session["Kullanici"] as Uye;
            return View(uye);
        }
        [HttpPost]
        [UserControl]
        [Authorize] // .net oturum açma kontrol attribute ü
        public ActionResult UyeGuncelle(Uye uye)
        {
            Uye kullanici = Session["Kullanici"] as Uye;
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
                    Session["Kullanici"] = kullanici;
                    FormsAuthentication.SetAuthCookie(uye.Email, true);
                    if (Request.QueryString["ReturnUrl"] != null) // eğer adres çubuğunda ReturnUrl diye bir değer varsa
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]); // oturum açıldıktan sonra kullanıcıyı kaldığı yere dönürmek için returnurl deki adrese yönlendir
                    }
                    return RedirectToAction("Index"); // ReturnUrl boşsa anasayfaya yönlendir
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(uye);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}