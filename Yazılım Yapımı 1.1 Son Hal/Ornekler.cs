using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazılım_Yapımı_1._1
{
    public class Ornekler
    {
        public List<ornekAlıcı> Alıcıs { get; set; }
        public List<ornekSatıcı> Satıcıs { get; set; }

        public Ornekler()
        {
            this.Alıcıs = new List<ornekAlıcı>();
            this.Satıcıs = new List<ornekSatıcı>();
        }

        public string alıcıListele()
        {
            string alıcıbilgi = "";
            foreach(ornekAlıcı a in Alıcıs)
            {
                alıcıbilgi += "\n\nAlıcı Adı: " + a.alıcıadı + "\nAlacağı Ürün: " + a.alacagıurun + "\nAlacağı Miktar(Kg): " + a.alacagımiktar;
            }
            return alıcıbilgi;
        }

        public string satıcıListele()
        {
            string satıcıbilgi = "";
            foreach(ornekSatıcı s in Satıcıs)
            {
                satıcıbilgi += "\n\nSatıcı Adı: " + s.satıcıadı + "\nSatılan Ürün: " + s.satılanurun + "\nMiktar(Kg): " + s.satılanmiktar + "\nBirim Fiyatı: " + s.satısfiyatı;
            }
            return satıcıbilgi;
        }
    }
}
