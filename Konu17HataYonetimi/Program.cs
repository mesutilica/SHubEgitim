namespace Konu17HataYonetimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu17 Hata Yonetimi");
            Console.WriteLine();
            Console.WriteLine("Kdv Hesaplamak İçin Fiyat Giriniz :");
            var fiyat = Console.ReadLine();
            // KdvHesapla(double.Parse(fiyat));
            try // try yaz 2 kere tab a bas
            {
                KdvHesapla(double.Parse(fiyat)); // try bloğunda bulunan kodların çalıştırılması denenir. Bir hata olursa
            }
            catch (Exception hata) // catch bloğunda oluşan hata yakalanarak işlem yapılır.
            {
                Console.WriteLine("Hata Oluştu! Lütfen sadece sayısal değer giriniz!");
                // throw; // throw hata fırlatır.
                // oluşan hatayı veritabanına kaydederek loglayabilir ve kendimize mail atarak haber vermesini sağlayabiliriz.
                Console.WriteLine(hata.Message); // hata mesajını görmek için
            }
            finally
            {
                Console.WriteLine("try catch bloğundan sonra her seferinde çalışmasını istediğimiz bir işlem varsa bu blokta çalıştırabiliriz. Kullanımı zorunlu değildir.");
                Console.WriteLine("Kdv Hesaplamak İçin Fiyat Giriniz :");
                var fiyat2 = Console.ReadLine();
                KdvHesapla(double.Parse(fiyat2));
            }
        }
        static void KdvHesapla(double fiyat)
        {
            Console.WriteLine("Fiyat : " + fiyat);
            Console.WriteLine("Kdv : " + (fiyat * 0.20));
            Console.WriteLine("Kdv Dahil Toplam Tutar :" + (fiyat + (fiyat * 0.20)));
        }
    }
}
