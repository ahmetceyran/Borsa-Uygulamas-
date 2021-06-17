using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazılım_Yapımı_1._1
{
    public partial class KullaniciGirisi : Form
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            Kullanıcı.ad = txtad.Text;
            Kullanıcı.soyad = txtsoyad.Text;
            Kullanıcı.kullanıcıadı = txtkullaniciadi.Text;
            Kullanıcı.sifre = txtsifre.Text;
            Kullanıcı.tcno = txttc.Text;
            Kullanıcı.telefon = txttel.Text;
            Kullanıcı.email = txtmail.Text;
            Kullanıcı.il = txtil.Text;
            Kullanıcı.ilce = txtilce.Text;
            Kullanıcı.mahalle = txtmahalle.Text;

            if ((txttip.Text == "Alıcı") || (txttip.Text == "alıcı"))
                Kullanıcı.kullanıcıtipi = "Alıcı";
            if ((txttip.Text == "Satıcı") || (txttip.Text == "satıcı"))
                Kullanıcı.kullanıcıtipi = "Satıcı";

            MessageBox.Show("Kayıt başarıyla tamamlandı.");
            this.Hide();
        }
    }
}
