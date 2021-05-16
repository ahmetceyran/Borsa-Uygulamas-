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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btngöster_Click(object sender, EventArgs e)
        {
            if ((Kullanıcı.kullanıcıtipi == "Alıcı") && (Alıcı.onaysizbakiye != 0))
                MessageBox.Show("Onay Bekleyen Kullanıcılar" + "\n\nKullanıcı Tipi: " + Kullanıcı.kullanıcıtipi + "\nKullanıcı Adı: " + Kullanıcı.kullanıcıadı
                    + "\nOnay bekleyen miktar: " + Alıcı.onaysizbakiye);
            

            if ((Kullanıcı.kullanıcıtipi == "Satıcı") && (Satıcı.onaysizurunad != ""))
                MessageBox.Show("Onay Bekleyen Kullanıcılar" + "\n\nKullanıcı Tipi: " + Kullanıcı.kullanıcıtipi + "\nKullanıc Adı: " + Kullanıcı.kullanıcıadı + "\nÜrün Tipi: "
                    + Satıcı.onaysizurunad + "\nMiktar(Kg): " + Satıcı.onaysizmiktar + "\nBirim Fiyatı: " + Satıcı.onaysizfiyat);

            if ((Satıcı.onaysizurunad == "") && (Alıcı.onaysizbakiye == 0))
                MessageBox.Show("Onay Bekleyen Kullanıcı Bulunmamaktadır!!!");
        }

        private void btnonay_Click(object sender, EventArgs e)
        {
            Alıcı.onaylibakiye = Alıcı.onaylibakiye + Alıcı.onaysizbakiye;
            Satıcı.onayliurunad = Satıcı.onaysizurunad;
            Satıcı.onaylimiktar = Satıcı.onaysizmiktar;
            Satıcı.onaylifiyat = Satıcı.onaysizfiyat;

            Alıcı.onaysizbakiye = 0;
            Satıcı.onaysizurunad = "";
            Satıcı.onaysizmiktar = 0;
            Satıcı.onaysizfiyat = 0;
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
