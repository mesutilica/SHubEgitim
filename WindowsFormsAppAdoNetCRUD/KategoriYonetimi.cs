using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNetCRUD
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        CategoryDAL dAL = new CategoryDAL();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        void Yukle()
        {
            dgvKategoriler.DataSource = dAL.GetDataTable("select * from categories");
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            txtKategoriAdi.Text = "";
            txtAciklama.Text = string.Empty;
            cbDurum.Checked = false;
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
            var sonuc = dAL.Add(kategori);
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
            txtKategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dgvKategoriler.CurrentRow.Cells[2].Value.ToString();
            cbDurum.Checked = (bool)dgvKategoriler.CurrentRow.Cells[3].Value;

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
            var kategori = new Category
            {
                Id = (int)dgvKategoriler.CurrentRow.Cells[0].Value,
                CreateDate = (DateTime)dgvKategoriler.CurrentRow.Cells[4].Value,
                Description = txtAciklama.Text,
                IsActive = cbDurum.Checked,
                Name = txtKategoriAdi.Text
            };
            var sonuc = dAL.Update(kategori);
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

        }
    }
}
