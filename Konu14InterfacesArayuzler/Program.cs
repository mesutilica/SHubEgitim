namespace Konu14InterfacesArayuzler
{
    public interface OrnekArayuz // class yerine interface yazıyoruz
    {
        public int Id { get; set; }
    }
    interface IDemo
    {
        void Goster(); // interface de metot imzası tanımlama
    }
    interface icerebilecekleri : IDemo // interface ler başka interface leri içerebilir
    {
        public int sayi1 { get; set; }
        public int sayi { get; set; }
        public static int sayi2 { get; set; }
        void Topla();
        int ToplamaYap();
    }
    class ArayuzKullanimi : icerebilecekleri
    {
        public int sayi1 { get; set; }
        public int sayi { get; set; }

        public void Goster()
        {
            Console.WriteLine("void Goster metodu");
        }

        public void Topla()
        {
            Console.WriteLine("void Topla metodu");
        }

        public int ToplamaYap()
        {
            return sayi + sayi1;
        }
        public int Id { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu14InterfacesArayuzler");
            ArayuzKullanimi arayuzKullanimi = new ArayuzKullanimi();
            arayuzKullanimi.sayi = 5;
            arayuzKullanimi.sayi1 = 10;
            arayuzKullanimi.Goster();
            arayuzKullanimi.Topla();
            Console.WriteLine("Toplama sonucu: " + arayuzKullanimi.ToplamaYap());

            Kategori kategori = new()
            {
                Id = 1,
                KategoriAdi = "Bilgisayar",
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            Console.WriteLine($"Kategori Id: {kategori.Id}, CreateDate: {kategori.CreateDate}, UpdateDate: {kategori.UpdateDate}");
        }
    }
}
