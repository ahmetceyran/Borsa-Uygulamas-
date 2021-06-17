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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if ((txtkullaniciadi.Text == "admin") && (txtsifre.Text == "admin"))
                new Admin().Show();
            if ((txtkullaniciadi.Text == Kullanıcı.kullanıcıadı) && (txtsifre.Text == Kullanıcı.sifre))
                if (Kullanıcı.kullanıcıtipi == "Satıcı")
                    new SaticiEkrani().Show();
            if ((txtkullaniciadi.Text == Kullanıcı.kullanıcıadı) && (txtsifre.Text == Kullanıcı.sifre))
                if (Kullanıcı.kullanıcıtipi == "Alıcı")
                    new AliciEkrani().Show();
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            new KullaniciGirisi().Show();
        }
    }
}
