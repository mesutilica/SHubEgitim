using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya)// Mvc de dosya yükleme IFormFile interface i ile yapılıyor. Burada dosya isminin ekrandaki file upload name i ile aynı olması gerekir yoksa dosya yüklenmez!
        {
            if (dosya != null)
            {
                var uzanti = Path.GetExtension(dosya.FileName);
                var klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // resmin yükleneceği klasör
                var klasorVarmi = Directory.Exists(klasor); // sunucuda bu klasör var mı?
                TempData["Message"] = "klasorVarmi : " + klasorVarmi;
                if (klasorVarmi == false) // eğer sunucuda bu konumda klasör yoksa
                {
                    var sonuc = Directory.CreateDirectory(klasor); // ana dizine Images klasörü oluştur
                    TempData["Message"] += " - Klasör Oluşturuldu.. " + sonuc;
                }
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // Sadece bu uzantılardaki dosyaları kabul et
                {
                    // 1. Yöntem Random(Rastgele) İsimle Dosya Yükleme
                    /*
                    var randomFileName = Path.GetRandomFileName(); // rasgele dosya ismi oluşturma metodu
                    var fileName = Path.ChangeExtension(randomFileName, ".jpg"); // dosya adı ve uzantısını değiştirip birleştirdik
                    var path = Path.Combine(klasor, fileName); // klasör ve resim adını birleştirdik
                    using var stream = new FileStream(path, FileMode.Create); // resmi farklı kaydet metoduyla sunucuya yüklüyoruz.
                    
                    dosya.CopyTo(stream); // resmi sunucuya yükle
                    TempData["Resim"] = fileName;
                    */
                    // 2. Yöntem - Resmi Kendi Adıyla Yükleme
                    /*
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yol = Path.Combine(klasor, dosyaAdi);
                    using var stream = new FileStream(yol, FileMode.Create);
                    dosya.CopyTo(stream); // resmi sunucuya yükle
                    TempData["Resim"] = dosyaAdi; // yüklenen dosya adı
                    */
                    // 3. yöntem, resmi direk sunucuya yollama
                    using var stream = new FileStream(klasor + dosya.FileName, FileMode.Create);
                    dosya.CopyTo(stream);
                    TempData["Resim"] = dosya.FileName;
                }
                else
                {
                    TempData["Message"] = "Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz!";
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult ResimSil(string resimYolu)
        {
            if (System.IO.File.Exists(resimYolu))
            {
                System.IO.File.Delete(resimYolu);
                TempData["Message"] = "Resim Silindi!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
