namespace Konu05Metotlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu05Metotlar");
            Console.WriteLine();
            ToplamaYap(); // metotları çağırmazsak çalışmazlar!
            ToplamaYap(18, 25);
            int sonuc = ToplamaYap(10, 20, 30);
            Console.WriteLine("Hesaplanmış Fiyat: " + sonuc);

            Console.WriteLine();
            Console.WriteLine("Mail Adresiniz: ");
            var email = Console.ReadLine();

            var mailGonderildimi = MailGonder(email);
            if (mailGonderildimi == true)
            {
                Console.WriteLine("Mail başarıyla gönderildi..");
            }
            else
                Console.WriteLine("Mail Gönderilemedi!");
        }
        static void ToplamaYap() // metot tanımlama
        {
            // void olan metotlar geriye değer döndürmeyen metotlardır
            // Aynı isimde metotlar farklı parametrelerle kullanılırsa buna overloading-aşırı yükleme denir.
            //Metot kullanımında kullanılan parametreler(sayi1, sayi2) metodun kullanıldığı yerde metoda gönderilmek zorundadır, aksi halde program hata verir
            Console.WriteLine(10 + 8);
        }
        static void ToplamaYap(int sayi1, int sayi2) // metotlar dışarıdan paramtere alarak çalışabilir.
        {
            Console.WriteLine(sayi1 + sayi2);
        }
        static int ToplamaYap(int sayi1, int sayi2, int sayi3) // metotlar dışarıdan paramtere alarak çalışabilir.
        {
            return sayi1 + sayi2 + sayi3; // int olan metotlar geriye değer döndürür, return ile değer döndürülür
        }

        static bool MailGonder(string mailAdresi)
        {
            if (!string.IsNullOrWhiteSpace(mailAdresi)) // eğer mailAdresi değişkeninin değeri boş değilse
            {
                // burada mail gönderim kodları yazılır.
                return true; // mail başarıyla gönderilmişse geriye true değerini
            }
            return false; // mail gönderimi başarısız olmuşsa geriye false değerini gönder.
        }
    }
}
