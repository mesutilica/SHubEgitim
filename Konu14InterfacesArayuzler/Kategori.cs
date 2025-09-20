namespace Konu14InterfacesArayuzler
{
    public class Kategori : ISinifGereksinimleri
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
