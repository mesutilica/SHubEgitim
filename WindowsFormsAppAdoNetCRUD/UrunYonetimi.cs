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
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        ProductDAL dAL = new ProductDAL();
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvUrunler.DataSource = dAL.GetAll();
            // dgvUrunler.DataSource = dAL.GetDataTable("select * from products");
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            txtUrunAdi.Text = "";
            txtStok.Text = "";
            txtFiyat.Text = string.Empty;
            txtAciklama.Text = string.Empty;
            cbDurum.Checked = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) || string.IsNullOrWhiteSpace(txtStok.Text) || string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                MessageBox.Show("Gerekli Alanları Doldurunuz!");
                return;
            }
            var urun = new Product
            {
                CreateDate = DateTime.Now,
                Stock = Convert.ToInt32(txtStok.Text),
                Description = txtAciklama.Text,
                IsActive = cbDurum.Checked,
                Name = txtUrunAdi.Text,
                Price = Convert.ToDecimal(txtFiyat.Text)
            };
            try
            {
                var sonuc = dAL.Add(urun);
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
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }            
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunAdi.Text = dgvUrunler.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dgvUrunler.CurrentRow.Cells[2].Value.ToString();
            cbDurum.Checked = (bool)dgvUrunler.CurrentRow.Cells[3].Value;
            txtStok.Text = dgvUrunler.CurrentRow.Cells[5].Value.ToString();
            txtFiyat.Text = dgvUrunler.CurrentRow.Cells[6].Value.ToString();

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) || string.IsNullOrWhiteSpace(txtStok.Text) || string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                MessageBox.Show("Gerekli Alanları Doldurunuz!");
                return;
            }
            var urun = new Product
            {
                Id = (int)dgvUrunler.CurrentRow.Cells[0].Value,
                CreateDate = DateTime.Now,
                Stock = Convert.ToInt32(txtStok.Text),
                Description = txtAciklama.Text,
                IsActive = cbDurum.Checked,
                Name = txtUrunAdi.Text,
                Price = Convert.ToDecimal(txtFiyat.Text)
            };
            try
            {
                var sonuc = dAL.Update(urun);
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
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = dAL.Delete((int)dgvUrunler.CurrentRow.Cells[0].Value);
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
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
