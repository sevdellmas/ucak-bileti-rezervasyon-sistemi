using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi.Siniflar;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    public class Rezervasyon
    {
        public Yolcu YolcuBilgisi { get; set; }
        public Ucus UcusBilgisi { get; set; }
        public int RezervasyonID { get; set; }
        public string KoltukNo { get; set; }
        public decimal OdenecekFiyat { get; set; }
        public DateTime RezervasyonTarihi { get; set; }

        public Rezervasyon(int rezervasyonID, Yolcu yolcu, Ucus ucus, string koltukNo, decimal fiyat)
        {
            this.RezervasyonID = rezervasyonID;
            this.YolcuBilgisi = yolcu;
            this.UcusBilgisi = ucus;
            this.KoltukNo = koltukNo;
            this.OdenecekFiyat = fiyat;
            this.RezervasyonTarihi = DateTime.Now;
        }

        public string RezervasyonGoruntule()
        {
            return $"Rezervasyon ID: {RezervasyonID}\n" +
                   $"Rezervasyon Tarihi: {RezervasyonTarihi:dd.MM.yyyy HH:mm}\n" +
                   $"Yolcu Adı: {YolcuBilgisi.Ad} {YolcuBilgisi.Soyad} ({YolcuBilgisi.TcKimlikNo})\n" +
                   $"Uçuş No: {UcusBilgisi.UcusNo} ({UcusBilgisi.KalkisYeri} -> {UcusBilgisi.VarisYeri})\n" +
                   $"Koltuk No: {KoltukNo}\n" +
                   $"Ödenecek Fiyat: {OdenecekFiyat:C}";
        }
    }
}
