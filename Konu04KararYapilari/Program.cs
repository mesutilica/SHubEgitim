namespace Konu04KararYapilari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu04KararYapilari");
            /*
            Console.WriteLine("Bir Sayı Giriniz:");
            var sayi = Convert.ToInt32(Console.ReadLine());
            if (sayi > 0) // eğer sayı 0 dan büyükse
            {
                Console.WriteLine("Sayı pozitif");
            }
            else if (sayi < 0) // üstteki şart sağlanmıyorsa eğer
            {
                Console.WriteLine("Sayı negatif");
            }
            else // üstteki şartların hiçbiri değilse
            {
                Console.WriteLine("Sayı sıfır");
            }
            */
            /*
            Console.WriteLine("Kullanıcı Adınızı Giriniz:");
            string kullaniciAdi = Console.ReadLine();

            Console.WriteLine("Şifrenizi Giriniz:");
            string sifre = Console.ReadLine();

            if (kullaniciAdi == "admin" && sifre == "gamer12")
            {
                Console.WriteLine("Giriş Başarılı!");
                Console.WriteLine("Hoşgeldin Pusat");
            }
            else
            {
                Console.WriteLine("Giriş Başarısız!");
                Console.WriteLine("Kullanıcı adı veya şifrenizi kontrol ederek tekrar deneyiniz!");
            }
            */
            int saat = DateTime.Now.Hour;
            if (saat < 18)
            {
                Console.WriteLine("İyi günler, saat : " + saat); // birden fazla kod satırı yazacaksak süslü parantez içerisine yazıyoruz.
            }
            else
                Console.WriteLine("İyi akşamlar, saat : " + saat); // tek satır yazacaksak süslü parantez kullanmayabiliriz.

            Console.WriteLine("switch case yapısı ile akış kontrolü");
            int ay = DateTime.Now.Month;
            Console.WriteLine("Bulunduğumuz ay: " + ay);
            switch (ay) // ay değişkeninin değerini kontrol et
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("Kış"); // yukardaki 3 şarttan biriyle eşleşiyorsa
                    break; // kod akışını durdur
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("İlkbahar");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Yaz");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Sonbahar");
                    break;
                default:
                    Console.WriteLine("Hata Oluştu");
                    break;
            }
        }
    }
}
