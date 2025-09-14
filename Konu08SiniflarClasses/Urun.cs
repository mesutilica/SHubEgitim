namespace Konu08SiniflarClasses
{
    public class Urun
    {
        // class içinde değişken-field kullanımı
        internal int Id;
        internal string Adi;
        internal decimal Fiyati;
        // class içinde property kullanımı
        public string UrunAciklamasi { get; set; } // property oluşturmanın kısayolu prop yazıp tab a basma
        public string Markasi { get; set; }
        public bool Durum { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; } // Navigation property, ürün ve kategori arasında ilişki kurar
    }
}
