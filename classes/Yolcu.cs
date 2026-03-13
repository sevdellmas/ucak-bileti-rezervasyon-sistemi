using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    public class Yolcu : Kullanici
    {   
        private string _tcKimlikNo;
        private string _ad;
        private string _soyad;
        private string _telefon;
        private string _cinsiyet;

        public string TcKimlikNo { get { return _tcKimlikNo; } set { _tcKimlikNo = value; } }
        public string Ad { get { return _ad; } set { _ad = value; } }
        public string Soyad { get { return _soyad; } set { _soyad = value; } }
        public string Telefon { get { return _telefon; } set { _telefon = value; } }
        public string Cinsiyet { get { return _cinsiyet; } set { _cinsiyet = value; } }
        

        // Constructor : Üst sınıftan gelen değerleri alır.
        public Yolcu(int id, string kullaniciAdi, string sifre) : base(id, kullaniciAdi, sifre){}

        // Polymorphism: Kullanici abstract metodun imzasına uygun override edildi.
        public override bool SistemeGirisYap(string girilenKullaniciAdi, string girilenSifre)
        {
            // Temel kontrolü üst sınıftan miras alınan özelliklerle yapar.
            return this.KullaniciAdi == girilenKullaniciAdi && this.Sifre == girilenSifre;
        }

        public List<Ucus> UcusAra(string kalkisYeri, string varisYeri, DateTime tarih)
        {
            return VeriDeposu.UcusAra(kalkisYeri, varisYeri, tarih);
        }

        public List<Rezervasyon> RezervasyonlariGoruntule()
        {
            return VeriDeposu.YolcuRezervasyonlariListele(this.ID);
        }

        public bool RezervasyonOlustur(Ucus ucus, string koltukNo, decimal toplamFiyat)
        {
            return VeriDeposu.RezervasyonOlustur(this, ucus, koltukNo, toplamFiyat);
        }

        public bool RezervasyonIptalEt(int rezervasyonID)
        {
            return VeriDeposu.RezervasyonIptalEt(rezervasyonID);
        }

    }
}
