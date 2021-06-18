using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazılım_Yapımı_1._1
{
    public partial class AliciEkrani : Form
    {
        private iTextSharp.text.Rectangle pageSize;

        public AliciEkrani()
        {
            InitializeComponent();
        }

        private void btnbakiye_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bakiye Bilgileriniz:\nOnaylanmamis Bakiyeniz:" + Alıcı.onaysizbakiye + " " + Alıcı.onaysizbirim +"\nOnaylanmis Bakiyeniz:" + Alıcı.onaylibakiye + " TL");
        }

        private void btnyükle_Click(object sender, EventArgs e)
        {
            Alıcı.onaysizbakiye = Alıcı.onaysizbakiye + Convert.ToDouble(txtyüklenecek.Text);
            Alıcı.onaysizbirim = cmbbirim.SelectedItem.ToString();
        }

        private void btnal_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtmiktar.Text == "")
            {
                Alıcı.alınacakmiktar = i;
                Alıcı.alımfiyatı = i;
            }
            else
            {
                Alıcı.alınacakmiktar = Convert.ToInt32(txtmiktar.Text);
                Alıcı.alımfiyatı = Convert.ToInt32(txtalım.Text);
            }
            
            Alıcı.alınacakurun = txtürün.Text;
            

            Ornekler satıcılar = new Ornekler();

            ornekSatıcı a = new ornekSatıcı();
            a.satıcıadı = "Nail Tütüncü";
            a.satılanurun = "bulgur";
            a.satılanmiktar = 150;
            a.satısfiyatı = 5;

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

            if ((c.satısfiyatı > Alıcı.alımfiyatı) && (a.satısfiyatı > Alıcı.alımfiyatı) && (b.satısfiyatı > Alıcı.alımfiyatı))
                MessageBox.Show("Almak İstediğiniz Fiyata Ürün Bulunmamaktadır!!!");

            if ((c.satılanurun == Alıcı.alınacakurun) && (c.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar >= c.satılanmiktar) && (Alıcı.onaylibakiye >= (c.satılanmiktar * c.satısfiyatı)))
                {
                    Aracı.aracıpayı = (c.satılanmiktar * c.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = c.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + c.satılanmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + c.satıcıadı + "\nAlınan Ürün: " + c.satılanurun + "\nAlınan Miktar: " + c.satılanmiktar + "\nBirim Fiyatı(Kg): " + c.satısfiyatı + "\nÖdenen Bakiye: " + (c.satılanmiktar * c.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - c.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (c.satılanmiktar * c.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    c.satıcıadı = "";
                    c.satılanurun = "";
                    c.satılanmiktar = 0;
                    c.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if((c.satılanurun == Alıcı.alınacakurun) && (c.satısfiyatı <= Alıcı.alımfiyatı))
                if((Alıcı.alınacakmiktar < c.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar*c.satısfiyatı)))
                {
                    Aracı.aracıpayı = (Alıcı.alınacakmiktar * c.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = c.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + Alıcı.alınacakmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + c.satıcıadı + "\nAlınan Ürün: " + c.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + c.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * c.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * c.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    c.satılanmiktar = c.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if ((c.satılanurun == Alıcı.alınacakurun) && (c.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar >= c.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * c.satısfiyatı) + ((c.satılanmiktar * c.satısfiyatı)/100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < c.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * c.satısfiyatı) + ((Alıcı.alınacakmiktar * c.satısfiyatı) / 100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");

            if((b.satılanurun == Alıcı.alınacakurun) && (b.satısfiyatı <= Alıcı.alımfiyatı))
                if((Alıcı.alınacakmiktar >= b.satılanmiktar) && (Alıcı.onaylibakiye >= (b.satılanmiktar*b.satısfiyatı)))
                {
                    Aracı.aracıpayı = (b.satılanmiktar * b.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = b.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + b.satılanmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + b.satıcıadı + "\nAlınan Ürün: " + b.satılanurun + "\nAlınan Miktar: " + b.satılanmiktar + "\nBirim Fiyatı(Kg): " + b.satısfiyatı + "\nÖdenen Bakiye: " + (b.satılanmiktar * b.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - b.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (b.satılanmiktar * b.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    b.satıcıadı = "";
                    b.satılanurun = "";
                    b.satılanmiktar = 0;
                    b.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if ((b.satılanurun == Alıcı.alınacakurun) && (b.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar * b.satısfiyatı)))
                {
                    Aracı.aracıpayı = (Alıcı.alınacakmiktar * b.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = b.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + Alıcı.alınacakmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + b.satıcıadı + "\nAlınan Ürün: " + b.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + b.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * b.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * b.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    b.satılanmiktar = b.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if ((b.satılanurun == Alıcı.alınacakurun) && (b.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar >= b.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * b.satısfiyatı) + ((b.satılanmiktar * b.satısfiyatı) / 100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * b.satısfiyatı) + ((Alıcı.alınacakmiktar * b.satısfiyatı) / 100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");

            if((a.satılanurun == Alıcı.alınacakurun) && (c.satılanmiktar ==0) && (Alıcı.alınacakmiktar != 0) && (a.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar >= a.satılanmiktar) && (Alıcı.onaylibakiye >= (a.satılanmiktar * a.satısfiyatı)))
                {
                    Aracı.aracıpayı = (a.satılanmiktar * a.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = a.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + a.satılanmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + a.satıcıadı + "\nAlınan Ürün: " + a.satılanurun + "\nAlınan Miktar: " + a.satılanmiktar + "\nBirim Fiyatı(Kg): " + a.satısfiyatı + "\nÖdenen Bakiye: " + (a.satılanmiktar * a.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.alınacakmiktar = Alıcı.alınacakmiktar - a.satılanmiktar;
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (a.satılanmiktar * a.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    a.satıcıadı = "";
                    a.satılanurun = "";
                    a.satılanmiktar = 0;
                    a.satısfiyatı = 0;
                    MessageBox.Show("Satıcılar\n" + satıcılar.satıcıListele().ToString());
                }
            if ((a.satılanurun == Alıcı.alınacakurun) && (c.satılanmiktar == 0) && (Alıcı.alınacakmiktar != 0) && (a.satısfiyatı <= Alıcı.alımfiyatı))
                if ((Alıcı.alınacakmiktar < a.satılanmiktar) && (Alıcı.onaylibakiye >= (Alıcı.alınacakmiktar * a.satısfiyatı)))
                {
                    Aracı.aracıpayı = (Alıcı.alınacakmiktar * a.satısfiyatı) / 100;
                    Ürün.ürüntipi = Alıcı.alınacakurun;
                    Ürün.birimfiyatı = a.satısfiyatı;
                    Ürün.alınanmiktar = Ürün.alınanmiktar + Alıcı.alınacakmiktar;
                    Ürün.alımtarihi = DateTime.Now;
                    MessageBox.Show("Alım İşlemi Bilgileri\n\n" + "İşlem Tarihi: " + DateTime.Now + "\nAlınan Kullanıcı: " + a.satıcıadı + "\nAlınan Ürün: " + a.satılanurun + "\nAlınan Miktar: " + Alıcı.alınacakmiktar + "\nBirim Fiyatı(Kg): " + a.satısfiyatı + "\nÖdenen Bakiye: " + (Alıcı.alınacakmiktar * a.satısfiyatı));
                    MessageBox.Show(Aracı.aracıpayı + " TL Aracı Payı kesilmiştir!!");
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - (Alıcı.alınacakmiktar * a.satısfiyatı);
                    Alıcı.onaylibakiye = Alıcı.onaylibakiye - Aracı.aracıpayı;
                    a.satılanmiktar = a.satılanmiktar - Alıcı.alınacakmiktar;
                    Alıcı.alınacakurun = "";
                    Alıcı.alınacakmiktar = 0;
                }
            if (a.satılanurun == Alıcı.alınacakurun)
                if ((Alıcı.alınacakmiktar >= a.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * a.satısfiyatı) + ((a.satılanmiktar * a.satısfiyatı) / 100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
                else if ((Alıcı.alınacakmiktar < b.satılanmiktar) && (Alıcı.onaylibakiye < ((Alıcı.alınacakmiktar * a.satısfiyatı) + +((Alıcı.alınacakmiktar * a.satısfiyatı) / 100))))
                    MessageBox.Show("İstenilen Miktarda Ürünü Alacak Bakiye Bulunmamaktadır");
        }

        private void btnrapor_Click(object sender, EventArgs e)
        {
            if((dateTimePickerbaslangic.Value > Ürün.alımtarihi) || (dateTimePickerbitis.Value < Ürün.alımtarihi))
            {
                MessageBox.Show("Girilen Tarihler Arasında Alım İşlemi Bulunamadı!!!");
            }
            else
            {
                Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 42, 35);
                PdfWriter w = PdfWriter.GetInstance(doc, new FileStream("Alim Raporu.pdf", FileMode.Create));
                doc.Open();
                Paragraph p = new Paragraph("\t\tAlim Raporu");
                Paragraph p2 = new Paragraph("Alim Tarihi : " + Ürün.alımtarihi);
                Paragraph p3 = new Paragraph("Alinan Urun : " + Ürün.ürüntipi);
                Paragraph p4 = new Paragraph("Alis Fiyati : " + Ürün.birimfiyatı + " TL");
                Paragraph p5 = new Paragraph("Alinan Miktar : " + Ürün.alınanmiktar + " KG");
                Ürün.alınanmiktar = 0;
                doc.AddAuthor("Ahmet");
                doc.AddCreator("Visual Studio");
                doc.AddSubject("Rapor");
                doc.AddTitle("Alım/Satım Raporu");
                doc.Add(p);
                doc.Add(p2);
                doc.Add(p3);
                doc.Add(p4);
                doc.Add(p5);
                doc.Close();
                MessageBox.Show("Rapor Başarıyla Oluşturuldu!!!");
            }
        }
    }
}
