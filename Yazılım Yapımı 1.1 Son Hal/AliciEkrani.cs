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
    public partial class AliciEkrani : Form
    {
        public AliciEkrani()
        {
            InitializeComponent();
        }

        private void btnbakiye_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bakiye Bilgileriniz:\nOnaylanmamis Bakiyeniz:" + Alıcı.onaysizbakiye + " TL\nOnaylanmis Bakiyeniz:" + Alıcı.onaylibakiye + " TL");
        }

        private void btnyükle_Click(object sender, EventArgs e)
        {
            Alıcı.onaysizbakiye = Alıcı.onaysizbakiye + Convert.ToInt32(txtyüklenecek.Text);
        }

        private void btnal_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtmiktar.Text == "")
            {
                Alıcı.alınacakmiktar = i;
            }
            else
            {
                Alıcı.alınacakmiktar = Convert.ToInt32(txtmiktar.Text);
            }
            
            Alıcı.alınacakurun = txtürün.Text;
            

            Ornekler satıcılar = new Ornekler();

            ornekSatıcı a = new ornekSatıcı();
            a.satıcıadı = "Nail Tütüncü";
            a.satılanurun = "bulgur";
            a.satılanmiktar = 150;
            a.satısfiyatı = 4;

            ornekSatıcı b = new ornekSatıcı();
            b.satıcıadı = "Mahir Ceyran";
            b.satılanurun = "şeker";
            b.satılanmiktar = 75;
            b.satısfiyatı = 5;

            ornekSatıcı c = new ornekSatıcı();
            c.satıcıadı = "Ece Akbeş";
            c.satılanurun = "bulgur";
            c.satılanmiktar = 100;
            c.satısfiyatı = 3;

            satıcılar.Satıcıs.Add(a);
            satıcılar.Satıcıs.Add(b);
            satıcılar.Satıcıs.Add(c);

            MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());

            if (Alıcı.onaylibakiye == 0)
                MessageBox.Show("Ürün Alabilecek Bakiyeniz Bulunmamaktadır!!!");

            if (c.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar >= c.satılanmiktar) && (Alıcı.onaylibakiye >= (c.satılanmiktar * c.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + c.satıcıadı + "\nAlınan Ürün: " + c.satılanurun + "\nAlınan Miktar: " + c.satılanmiktar + "\nBirim Fiyatı(Kg): " + c.satısfiyatı + "\nÖdenen Bakiye: " + (c.satılanmiktar * c.satısfiyatı));
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - c.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (c.satılanmiktar * c.satısfiyatı);
                    c.satıcıadı = "";
                    c.satılanurun = "";
                    c.satılanmiktar = 0;
                    c.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if(c.satılanurun == Alıcı.alınacakurun)
                if((Alıcı.alınacakmiktar < c.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar*c.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + c.satıcıadı + "\nAlınan Ürün: " + c.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + c.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * c.satısfiyatı));
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * c.satısfiyatı);
                    c.satılanmiktar = c.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if (c.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar >= c.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * c.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < c.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * c.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");

            if(b.satılanurun == Alıcı.alınacakurun)
                if((Alıcı.alınacakmiktar >= b.satılanmiktar) && (Alıcı.onaylibakiye >= (b.satılanmiktar*b.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + b.satıcıadı + "\nAlınan Ürün: " + b.satılanurun + "\nAlınan Miktar: " + b.satılanmiktar + "\nBirim Fiyatı(Kg): " + b.satısfiyatı + "\nÖdenen Bakiye: " + (b.satılanmiktar * b.satısfiyatı));
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - b.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (b.satılanmiktar * b.satısfiyatı);
                    b.satıcıadı = "";
                    b.satılanurun = "";
                    b.satılanmiktar = 0;
                    b.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if (b.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar * b.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + b.satıcıadı + "\nAlınan Ürün: " + b.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + b.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * b.satısfiyatı));
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * b.satısfiyatı);
                    b.satılanmiktar = b.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if (b.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar >= b.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * b.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * b.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");

            if((a.satılanurun == Alıcı.alınacakurun) && (c.satılanmiktar ==0) && (Alıcı.alınacakmiktar != 0))
                if ((Alıcı.alınacakmiktar >= a.satılanmiktar) && (Alıcı.onaylibakiye >= (a.satılanmiktar * a.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + a.satıcıadı + "\nAlınan Ürün: " + a.satılanurun + "\nAlınan Miktar: " + a.satılanmiktar + "\nBirim Fiyatı(Kg): " + a.satısfiyatı + "\nÖdenen Bakiye: " + (a.satılanmiktar * a.satısfiyatı));
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - a.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (a.satılanmiktar * a.satısfiyatı);
                    a.satıcıadı = "";
                    a.satılanurun = "";
                    a.satılanmiktar = 0;
                    a.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if ((a.satılanurun == Alıcı.alınacakurun) && (c.satılanmiktar == 0) && (Alıcı.alınacakmiktar != 0))
                if ((Alıcı.alınacakmiktar < a.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar * a.satısfiyatı)))
                {
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + a.satıcıadı + "\nAlınan Ürün: " + a.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + a.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * a.satısfiyatı));
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * a.satısfiyatı);
                    a.satılanmiktar = a.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if (a.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar >= a.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * a.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye < (Alıcı.alınacakmiktar * a.satısfiyatı)))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
        }
    }
}
