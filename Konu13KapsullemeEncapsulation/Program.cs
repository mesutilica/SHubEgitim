namespace Konu13KapsullemeEncapsulation
{
    internal class Bolum
    {
        private string BolumAdi;//dışarıdan erişime kapalı değişkenimiz. 
        //Accessor (Getter)
        public string GetBolumAdi()
        {
            return BolumAdi;
        }//Geriye private BolumAdi değişkenini döndüren metot
        public void SetBolumAdi(string istenenEgitim)
        {
            if (istenenEgitim == "Grafik Tasarım")
            {
                Console.WriteLine("Kurumumuzda " + istenenEgitim + " Eğitimi Verilmemektedir!");
            }
            else
                BolumAdi = istenenEgitim; // Mutator (Setter) Seçilen eğitim onaylandı.
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu13KapsullemeEncapsulation");
            Bolum bolum = new Bolum();
            Console.WriteLine("Eğitim almak istediğiniz bölümü giriniz:");
            // Metot ile kapsülleme
            Console.WriteLine("Metot ile kapsülleme");
            var bolumAdi = Console.ReadLine();
            bolum.SetBolumAdi(bolumAdi);
            Console.WriteLine("Seçtiğiniz bölüm: " + bolum.GetBolumAdi());

            //Property ile kapsülleme
            Console.WriteLine();
            Console.WriteLine("Property ile kapsülleme");
            Fakulte fakulte = new Fakulte();
            fakulte.Bolum = bolumAdi; // set bloğu çalışır
            Console.WriteLine("Seçtiğiniz bölüm: " + fakulte.Bolum); // get bloğu çalışır
        }
    }
    //Property ile kapsülleme
    public class Fakulte
    {
        private string bolum;
        public string Bolum
        {
            get { return bolum; }
            set
            {
                if (value == "Grafik Tasarım")
                {
                    Console.WriteLine("Kurumumuzda " + value + " Eğitimi Verilmemektedir!");
                }
                else
                    bolum = value;
            }
        }
    }
}
