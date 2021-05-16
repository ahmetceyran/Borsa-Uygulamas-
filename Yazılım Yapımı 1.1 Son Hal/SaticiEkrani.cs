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
    public partial class SaticiEkrani : Form
    {
        public SaticiEkrani()
        {
            InitializeComponent();
            if (Satıcı.onayliurunad != "")
                MessageBox.Show("Onayli Ürününüzü Satmak İçin Lütfen Alıcılar Butonuna Tıklayınız!");
        }

        private void btnbakiye_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bakiyeniz:" + Satıcı.bakiye + " TL");
        }

        private void btnurunler_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ürünleriniz:" + "\nOnay Bekleyen Ürün Bilgileri" + "\nTipi: " + Satıcı.onaysizurunad + "\nMiktarı: " + Satıcı.onaysizmiktar + " Kg"
                + "\nBirim Fiyatı: " + Satıcı.onaysizfiyat + " TL" + "\nToplam Fiyatı: " + (Satıcı.onaysizmiktar*Satıcı.onaysizfiyat) + " TL" + "\n\nOnaylanmış Ürün Bilgileri"
                + "\nTipi: " + Satıcı.onayliurunad + "\nMiktarı: " + Satıcı.onaylimiktar + " Kg" + "\nBirim Fiyatı: " + Satıcı.onaylifiyat + "\nToplam Fiyatı: " + (Satıcı.onaylimiktar*Satıcı.onaylifiyat) + " TL");
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (Satıcı.onaysizurunad != "")
                MessageBox.Show("Onay bekleyen ürününüz olduğu için şu an ürün ekleyemezsiniz!!!");
            else
            {
                Satıcı.onaysizurunad = txttur.Text;
                Satıcı.onaysizmiktar = Convert.ToInt32(txtmiktar.Text);
                Satıcı.onaysizfiyat = Convert.ToInt32(txtfiyat.Text);
            }
        }

        private void btnalicilar_Click(object sender, EventArgs e)
        { 

            Ornekler alıcılar = new Ornekler();
            
            ornekAlıcı a = new ornekAlıcı();
            a.alıcıadı = "Ali Şahin";
            a.alacagıurun = "bulgur";
            a.alacagımiktar = 150;

            ornekAlıcı b = new ornekAlıcı();
            b.alıcıadı = "Erdal Gümüş";
            b.alacagıurun = "pirinç";
            b.alacagımiktar = 100;

            ornekAlıcı c = new ornekAlıcı();
            c.alıcıadı = "Ayşe Yılmaz";
            c.alacagıurun = "bulgur";
            c.alacagımiktar = 125;

            alıcılar.Alıcıs.Add(a);
            alıcılar.Alıcıs.Add(b);
            alıcılar.Alıcıs.Add(c);

            MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());

            if (Satıcı.onaylimiktar == 0)
                MessageBox.Show("Satılacak Ürününüz Bulunmamaktadır!!!");

            if ((a.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaylimiktar > a.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + a.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + a.alacagımiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (a.alacagımiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.onaylimiktar = Satıcı.onaylimiktar - a.alacagımiktar;
                    Satıcı.bakiye = Satıcı.bakiye + (a.alacagımiktar * Satıcı.onaylifiyat);
                    a.alıcıadı = "";
                    a.alacagıurun = "";
                    a.alacagımiktar = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
             
            
            if((a.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaylimiktar <= a.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + a.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + Satıcı.onaylimiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (Satıcı.onaylimiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.bakiye = Satıcı.bakiye + (Satıcı.onaylimiktar * Satıcı.onaysizfiyat);
                    a.alacagımiktar = a.alacagımiktar - Satıcı.onaylimiktar;
                    Satıcı.onayliurunad = "";
                    Satıcı.onaylimiktar = 0;
                    Satıcı.onaylifiyat = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
            
            if((b.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaylimiktar > b.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + b.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + b.alacagımiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (b.alacagımiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.onaylimiktar = Satıcı.onaylimiktar - b.alacagımiktar;
                    Satıcı.bakiye = Satıcı.bakiye + (b.alacagımiktar * Satıcı.onaylifiyat);
                    b.alıcıadı = "";
                    b.alacagıurun = "";
                    b.alacagımiktar = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
            
            if((b.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaylimiktar <= b.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + b.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + Satıcı.onaylimiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (Satıcı.onaylimiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.bakiye = Satıcı.bakiye + (Satıcı.onaylimiktar * Satıcı.onaylifiyat);
                    b.alacagımiktar = b.alacagımiktar - Satıcı.onaylimiktar;
                    Satıcı.onayliurunad = "";
                    Satıcı.onaylimiktar = 0;
                    Satıcı.onaylifiyat = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
            
            if((c.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaylimiktar > c.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + c.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + c.alacagımiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (c.alacagımiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.onaylimiktar = Satıcı.onaylimiktar - c.alacagımiktar;
                    Satıcı.bakiye = Satıcı.bakiye + (c.alacagımiktar * Satıcı.onaylifiyat);
                    c.alıcıadı = "";
                    c.alacagıurun = "";
                    c.alacagımiktar = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
            
            if((c.alacagıurun == Satıcı.onayliurunad) && (Satıcı.onaysizmiktar <= c.alacagımiktar))
                {
                    MessageBox.Show("Satış İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nSatılan Kullanıcı: " + c.alıcıadı + "\nSatılan Ürün: " + Satıcı.onayliurunad + "\nSatılan Miktar: " + Satıcı.onaylimiktar + "\nBirim Fiyat: " + Satıcı.onaylifiyat + " TL" + "\nToplam Kazanç: " + (Satıcı.onaylimiktar * Satıcı.onaylifiyat) + " TL");
                    Satıcı.bakiye = Satıcı.bakiye + (Satıcı.onaylimiktar * Satıcı.onaylifiyat);
                    c.alacagımiktar = c.alacagımiktar - Satıcı.onaylimiktar;
                    Satıcı.onayliurunad = "";
                    Satıcı.onaylimiktar = 0;
                    Satıcı.onaylifiyat = 0;
                    MessageBox.Show("Alıcılar\n" + alıcılar.alıcıListele().ToString());
                }
            else
            {
                MessageBox.Show("Sattığınız Ürünün Alıcısı Bulunmamaktadır!!!");
            }
        }
    }
}
