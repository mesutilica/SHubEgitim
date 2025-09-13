namespace Konu07Donguler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu07Donguler");

            Console.WriteLine("1-For Döngüsü");
            for (int i = 0; i < 5; i++) //i değişkeni oluştur ve 0 değerini ata; i 5 den küçük olduğu sürece dön; her dönüşte i yi 1 artır i++ ile
            {
                Console.WriteLine("i değişkeninin değeri: {0}", i);
            }

            Console.WriteLine();

            Console.WriteLine("2-While Döngüsü");

            int j = 0; // dışarıda bir değişken tanımlıyoruz
            while (j < 5) //While döngüsünün şartı bu şekilde, anlamı toplam küçükse 5 den sürekli dön
            {
                Console.WriteLine("While Sayı {0} değeri", j);//toplamın değerini ekrana yazdırıyoruz
                j++;//toplam sayısını arttırıyoruz ki sonsuz döngüye girmesin program
            }

            Console.WriteLine();

            Console.WriteLine("3-Do While Döngüsü");

            int toplam = 7;
            do
            {
                Console.WriteLine("toplamın değeri : " + toplam);
            } while (toplam < 5);

            Console.WriteLine();

            Console.WriteLine("4-Foreach Döngüsü");
            string[] kategoriler = { "Bilgisayar", "Elektronik", "Cep Telefonu" };
            Console.WriteLine("Kategoriler:");
            foreach (var item in kategoriler)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // İç içe döngü kullanımı
            string[] urunler = { "Ürün 1", "Ürün 2", "Ürün 3" };
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine(kategori); // kategori adını yazdır
                foreach (var urun in urunler) // urunler dizisinde dönmeye başla
                {
                    Console.WriteLine(urun);
                }
            }
            Console.WriteLine();

            Console.WriteLine("İç İçe For Döngüsü");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("i : " + i);
                for (int k = 0; k < 3; k++)
                {
                    Console.WriteLine($"k nın değeri : {k}");
                }
            }
        }
    }
}
