using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkCRUD
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKullanicilar.DataSource = context.Users.ToList();
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            txtName.Text = "";
            txtSurname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbIsActive.Checked = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Tüm Alanları Doldurmalısınız!");
                return;
            }
            var kullanici = new User
            {
                CreateDate = DateTime.Now,
                IsActive = cbIsActive.Checked,
                Name = txtName.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                Surname = txtSurname.Text
            };
            context.Users.Add(kullanici);
            var sonuc = context.SaveChanges();
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

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvKullanicilar.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = dgvKullanicilar.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgvKullanicilar.CurrentRow.Cells["Email"].Value.ToString();
            txtPassword.Text = dgvKullanicilar.CurrentRow.Cells["Password"].Value.ToString();
            cbIsActive.Checked = (bool)dgvKullanicilar.CurrentRow.Cells["IsActive"].Value;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = (int)dgvKullanicilar.CurrentRow.Cells["Id"].Value;
            var user = context.Users.Find(id);

            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.Name = txtName.Text;
            user.Surname = txtSurname.Text;
            user.IsActive = cbIsActive.Checked;

            var sonuc = context.SaveChanges();
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
            int id = (int)dgvKullanicilar.CurrentRow.Cells["Id"].Value;
            var user = context.Users.Find(id);

            context.Users.Remove(user);

            var sonuc = context.SaveChanges();
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
