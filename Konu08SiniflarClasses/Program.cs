namespace Konu08SiniflarClasses
{
    internal class Ev // sınıf tanımlama
    {
        internal string sokakAdi;
        internal int kapiNo;
    }
    public class deneme
    {
        public string UrunAdi = "public öğeye herkes erişebilir";
        protected class test //Ait olduğu sınıftan ve o sınıftan türetilen sınıflardan erişilebilir
        {
            string UrunAdi;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu08SiniflarClasses");
            /*
                *Erişim belirteçleri 4 ana sınıfa ayrılır
                * public    : Erişim kısıtı yoktur, her yerden erişilebilir
                * protected : Ait olduğu sınıftan ve o sınıftan türetilen sınıflardan erişilebilir
                * internal  : Etkin projeye ait sınıflardan erişilebilir, onların dışında erişilemez
                * private   : Yalnız bulunduğu sınıftan erişilebilir, dıştaki sınıflardan erişilemez
             */
            #region Örnek1            
            Ev ilkEv = new Ev(); // soyut bir yapı olan ev sınıfından, somut bir nesne olan ilkev i oluşturduk
            ilkEv.sokakAdi = "Çiçek sk";
            ilkEv.kapiNo = 10;
            Console.WriteLine("ilkEv sokak adı: " + ilkEv.sokakAdi);
            Console.WriteLine("ilkEv kapi No: " + ilkEv.kapiNo);

            Console.WriteLine();

            Ev yazlikEv = new();
            yazlikEv.sokakAdi = "Deniz sk";
            yazlikEv.kapiNo = 10;
            Console.WriteLine("yazlikEv sokak adı: " + yazlikEv.sokakAdi);
            Console.WriteLine("yazlikEv kapi No: " + yazlikEv.kapiNo);

            Console.WriteLine();

            Ev koyEvi = new()
            {
                kapiNo = 10,
                sokakAdi = "Mehmed Ağa Sokak"
            };
            Console.WriteLine("koyEvi sokak adı: " + koyEvi.sokakAdi);
            Console.WriteLine("koyEvi kapi No: " + koyEvi.kapiNo);
            #endregion
            #region Örnek 2
            Kullanici kullanici = new()
            {
                Adi = "Murat",
                Soyadi = "Yılmaz",
                Id = 1,
                KullaniciAdi = "muraty",
                Sifre = "emr123"
            };
            Console.WriteLine("Kullanici Adi:");
            var KullaniciAdi = Console.ReadLine();
            Console.WriteLine("Sifre:");
            var Sifre = Console.ReadLine();

            if (KullaniciAdi == kullanici.KullaniciAdi && Sifre == kullanici.Sifre)
            {
                Console.WriteLine($"Hoşgeldin {kullanici.Adi} {kullanici.Soyadi}");
            }
            else
                Console.WriteLine("Giriş Başarısız!");
            #endregion
            #region Örnek 3
            Araba araba = new()
            {
                Marka = "TOGG", Model = "T10X", KasaTipi = "SUV", VitesTipi = "Otomatik"
            };
            Araba araba2 = new()
            {
                Marka = "TOGG", Model = "T10F", KasaTipi = "Sedan", VitesTipi = "Otomatik"
            };
            #endregion
            #region Örnek 4
            Kategori kategori = new()
            {
                Id = 1, KategoriAdi = "Elektronik"
            };
            Kategori kategori2 = new()
            {
                Id = 2,
                KategoriAdi = "Bilgisayar"
            };
            Kategori kategori3 = new()
            {
                Id = 3,
                KategoriAdi = "Telefon"
            };
            Console.WriteLine($"Anasayfa Hakkımızda {kategori.KategoriAdi} {kategori2.KategoriAdi} {kategori3.KategoriAdi} İletişim");
            #endregion
            #region Örnek 5
            SiniftaMetotKullanimi metotKullanimi = new();
            var sonuc = metotKullanimi.LoginKontrol("admin", "123456");
            if (sonuc) // if de bu şekilde kullanırsak sonuc == true yu kontrol eder
            {
                Console.WriteLine("Giriş Başarılı!");
            }
            else
                Console.WriteLine("Giriş Başarısız!");

            var toplamasonucu = metotKullanimi.ToplamaYap(10, 8);
            Console.WriteLine("toplamasonucu: " + toplamasonucu);

            Console.WriteLine("Statik Degisken: " + SiniftaMetotKullanimi.StatikDegisken); // statik değişkeni sınıfınadı.değişkenadı şeklinde direk kullanabiliyoruz

            Console.WriteLine("Dinamik Degisken: " + metotKullanimi.DinamikDegisken);
            #endregion

            User user = new()
            {
                Id = 1, CreateDate = DateTime.Now, Email = "admin@user.co", Password = "123456"
            };
            var KullaniciGirisSonuc = user.KullaniciGiris(user.Email, user.Password);

            Console.WriteLine("KullaniciGirisSonuc: " + KullaniciGirisSonuc);
        }
    }
    class Kullanici
    {
        internal int Id;
        internal string KullaniciAdi;
        internal string Sifre;
        internal string Email;
        internal string Adi;
        internal string Soyadi;
    }
    class Araba
    {
        internal int Id;
        internal string Marka;
        internal string Model;
        internal string KasaTipi;
        internal string YakitTipi;
        internal string VitesTipi;
        internal string Renk;
    }
}
