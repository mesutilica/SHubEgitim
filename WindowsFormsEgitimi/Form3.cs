using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEgitimi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Geçilemez!");
            }
            else
            {
                if (txtKullaniciAdi.Text == "Admin" && txtSifre.Text == "12345")
                {
                    MessageBox.Show("Hoşgeldin Admin");
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız!");
                }
            }
        }
    }
}
