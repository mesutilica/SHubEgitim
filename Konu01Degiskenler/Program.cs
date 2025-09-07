namespace Konu01Degiskenler
{
    internal class Program // Sınıf
    {
        static void Main(string[] args) // Method
        {
            Console.WriteLine("Hello, World!"); // Ekrana yazı yazdırma kodu
            Console.WriteLine();
            Console.WriteLine("Merhaba, Dünya!");
            
            Console.Write("Console."); // Write metodu gönderilen değerleri yan yana yazdırır.
            Console.Write(".Write");

            //Console.Read(); // ekrandan girilicek 1 karakteri okur
            //Console.ReadLine(); // ekrandan girilicek 1 satırı okur

            //C# ta değişken tanımlama
            //Tamsayı veri tipleri
            byte plaka_kodu; // 0-255 arası değer alır, 1 byte yer kaplar
            plaka_kodu = 34; // değişkene değer atama
            Console.WriteLine(plaka_kodu); // değişkeni ekrana yazdırma

            // Değişkenler tiplerine göre bellekte stack ve heap denilen 2 ayrı bölümde saklanır. Değer tipli değişkenler stack alanında saklanırken referans tipli değişkenler heap bölümünde saklanır.
            // GC-çöp toplayıcı sistemi
            byte birSayi, birSayiDaha; // bir tiple birden fazla değişken oluşturma
            birSayi = 0;
            birSayiDaha = 255;
            Console.WriteLine(birSayi);
            Console.WriteLine(birSayiDaha);

            sbyte sbyteTuru = 127; // +127 ile -128 arası değer alabilir
            short kisa = 32767; // +32767 ile -32768 arası değer alabilir
            ushort birazUzun = 65535; // 0 - 65535
            int tamsayi = 1234567890; // 32 bit 4 byte
            uint uzuntamsayi = 4294967295; // 0 - 4294967295
            long dahauzuntamsayi = 123456789000000;
            ulong enuzuntamsayi = 12345678900000000000;

            //Kesirli Sayı Değişken Tipleri
            float kesirliSayi = 4.5f; //4byte yer kaplar 6-7 basamak
            double kesirliSayi2 = 4.5; //8byte yer kaplar 15-16 basamak

            // Decimal Veri Tipi
            decimal UrunFiyati = 9999; //12byte, duyarlı basamak 28 - 29

            // Char Veri Tipi
            char karakter = 'ç'; // klavyeden girilen her bir karakter için kullanılabilir, sadece 1 tane değer alabilir.

            //String Veri Tipi
            string degisken; // klavyeden girilecek karakterlerden oluşan yapı
            string degisken1, degisken2;
            string metin = "string veri tipinde tüm karakterleri kullanabiliyoruz."; // string değerleri çift tırnaklar arasına yazılır.
            Console.WriteLine(metin); // debug mod-debugging:Hata ayıklama-satırın solundaki şeride tıklayıp kırmızı nokta oluşturuyoruz bunun adı breakpoint

            //Boolean Veri Tipi
            //Geriye true veya false dönen veri tipidir, 1byte lık yer kaplar
            bool islemSonuc = false;
            // işlem başarılıysa eğer
            islemSonuc = true;

            byte? kilo = null;//eğer bir değişkene başlangıç değeri olarak null vermek istersek veri tipinin yanına ? koyarız
            kilo = 66;

            //* Bir ürünün satışta olup olmadığı bilgisini tutacak değişken
            bool? isSatistami = null;
            //kontrol ettik
            isSatistami = true;

            //var ile değişken oluşturma
            var birdegisken = "18"; //var ile oluşturulan değişkenlerde değişkenin veri tipi c# tarafından değişkene atanan değere göre otomatik algılanır
            var strmetin = "var kullanırsak değişkene değer atamak zorundayız!";
            var sonuc = false;

            Console.WriteLine(birdegisken.GetType()); // GetType() metodu bize değişkenin değerini verir.
            Console.WriteLine(strmetin.GetType());
            Console.WriteLine(sonuc.GetType());

            sonuc = true;
            // sonuc = 1; // var ile tanımlanan bir değişkenin türü sonradan değiştirilemez, ancak içindeki değer değiştirilebilir.

            Console.WriteLine();
            Console.WriteLine("Object Veri Tipi");
            object nesne = "bu bir nesnedir"; // Bu değişken türüne her türden veri atanabilir.
            Console.WriteLine(nesne + "-Tipi:" + nesne.GetType());
            nesne = 18; // object ile tanımlanan nesne değiştirilebilir
            Console.WriteLine(nesne + "-Tipi:" + nesne.GetType());

            object a = 10; // tam sayı
            object b = 'k'; // karakter
            object c = "metin"; // string
            object d = 12.9f; // float

            Console.WriteLine();
            //C# ta sabit tanımlama
            Console.WriteLine("C# ta sabit tanımlama");
            const int kdvOrani = 18; //sabitleri const olarak tanımlayıp program içerisinde kullanabiliriz, sabitlerin değeri tanımlandığı yerde verilir sonradan değişmez
            const int iskonto = 25;
            // kdvOrani = 20;

            Console.WriteLine("kdvOrani:");
            Console.WriteLine(kdvOrani);

            // Ekrandan değer alma
            Console.WriteLine("Ekrandan değer alma");
            var deger = Console.ReadLine(); //bu komut ekrandan girilen 1 satırlık veriyi yakalamamızı sağlar
            Console.WriteLine("\nGirdiğiniz Değer:");
            Console.Write(deger);
            Console.WriteLine("\nGirdiğiniz Değer: " + deger);
            Console.WriteLine("\nGirdiğiniz Değer 2: " + deger);
        }
    }
}
