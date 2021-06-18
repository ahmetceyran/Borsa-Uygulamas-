using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
                    + "\nOnay bekleyen miktar: " + Alıcı.onaysizbakiye + " " + Alıcı.onaysizbirim);
            

            if ((Kullanıcı.kullanıcıtipi == "Satıcı") && (Satıcı.onaysizurunad != ""))
                MessageBox.Show("Onay Bekleyen Kullanıcılar" + "\n\nKullanıcı Tipi: " + Kullanıcı.kullanıcıtipi + "\nKullanıc Adı: " + Kullanıcı.kullanıcıadı + "\nÜrün Tipi: "
                    + Satıcı.onaysizurunad + "\nMiktar(Kg): " + Satıcı.onaysizmiktar + "\nBirim Fiyatı: " + Satıcı.onaysizfiyat);

            if ((Satıcı.onaysizurunad == "") && (Alıcı.onaysizbakiye == 0))
                MessageBox.Show("Onay Bekleyen Kullanıcı Bulunmamaktadır!!!");
        }

        private void btnonay_Click(object sender, EventArgs e)
        {
            string anlık = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(anlık);
            string abd = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteBuying").InnerXml;
            string euro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteBuying").InnerXml;
            string sterlin = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteBuying").InnerXml;
            double dolar = Convert.ToDouble(abd);
            double Euro = Convert.ToDouble(euro);
            double gbp = Convert.ToDouble(sterlin);

            MessageBox.Show("Anlık Döviz Kurları" + "\nABD Doları : " + abd + "\nEURO : " + euro + "\nİngiliz Sterlini : " + sterlin);
         
            if(Alıcı.onaysizbirim == "ABD Doları")
            {
                Alıcı.onaylibakiye = Alıcı.onaylibakiye + ((Alıcı.onaysizbakiye * dolar)/10000);
            }

            if(Alıcı.onaysizbirim == "EURO")
            {
                Alıcı.onaylibakiye = Alıcı.onaylibakiye + ((Alıcı.onaysizbakiye * Euro)/10000);
            }

            if(Alıcı.onaysizbirim == "Sterlin")
            {
                Alıcı.onaylibakiye = Alıcı.onaylibakiye + ((Alıcı.onaysizbakiye * gbp)/10000);
            }

            if((Alıcı.onaysizbirim == "TL") || (Alıcı.onaysizbirim == ""))
            {
                Alıcı.onaylibakiye = Alıcı.onaylibakiye + Alıcı.onaysizbakiye;
            }

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
