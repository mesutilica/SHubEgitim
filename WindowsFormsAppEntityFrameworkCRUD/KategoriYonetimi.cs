using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkCRUD
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext(); // veritabanı tablolarımızı tutan entity framework sınıfımız
        void Yukle()
        {
            dgvKategoriler.DataSource = context.Categories.ToList();
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            txtKategoriAdi.Text = "";
            txtAciklama.Text = string.Empty;
            cbDurum.Checked = false;
        }
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez!");
                return;
            }
            var kategori = new Category
            {
                CreateDate = DateTime.Now,
                Description = txtAciklama.Text,
                IsActive = cbDurum.Checked,
                Name = txtKategoriAdi.Text
            };

            context.Categories.Add(kategori);
            var sonuc = context.SaveChanges(); // context.SaveChanges() metodu context üzerinde c# tarafında yapılan değişiklikleri sql veritabanına yansıtır ve etkilenen kayıt sayısını int olarak bize getirir.

            if (sonuc > 0)
            {
                Yukle();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            txtKategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dgvKategoriler.CurrentRow.Cells[2].Value.ToString();
            cbDurum.Checked = (bool)dgvKategoriler.CurrentRow.Cells[3].Value;
            */
            var id = (int)dgvKategoriler.CurrentRow.Cells["Id"].Value;
            var kayit = context.Categories.Find(id);
            txtKategoriAdi.Text = kayit.Name;
            txtAciklama.Text = kayit.Description;
            cbDurum.Checked = kayit.IsActive;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategoriAdi.Text))
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez!");
                return;
            }
            var id = (int)dgvKategoriler.CurrentRow.Cells["Id"].Value;
            var kayit = context.Categories.Find(id); // veritabanından güncellenecek kaydı seç
            kayit.Name = txtKategoriAdi.Text; // kaydın bilgilerini güncelle
            kayit.Description = txtAciklama.Text;
            kayit.IsActive = cbDurum.Checked;
            var sonuc = context.SaveChanges(); // değişiklikleri kaydet
            if (sonuc > 0)
            {
                Yukle();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var id = (int)dgvKategoriler.CurrentRow.Cells["Id"].Value;
            var kayit = context.Categories.Find(id); // db den silinecek kaydı bul
            context.Categories.Remove(kayit); // ef remove metodu kaydı silinecek olarak işaretler
            var sonuc = context.SaveChanges(); // değişiklikleri kaydet
            if (sonuc > 0)
            {
                Yukle();
                MessageBox.Show("Kayıt Silme Başarılı!");
            }
            else
            {
                MessageBox.Show("Kayıt Silme Başarısız!");
            }
        }
    }
}
