using System.Collections.Generic;
using UcakBiletiRezervasyonSistemi.Siniflar;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    public class Admin : Kullanici
    {
        public Admin(int id, string kullaniciAdi, string sifre) : base(id, kullaniciAdi, sifre) { }

        public override bool SistemeGirisYap(string girilenKullaniciAdi, string girilenSifre)
        {
            return this.KullaniciAdi == girilenKullaniciAdi && this.Sifre == girilenSifre;
        }

        public void UcusEkle(Ucus yeniUcus)
        {
            VeriDeposu.UcusEkle(yeniUcus);
        }

        public bool UcusSil(string ucusNo)
        {
            return VeriDeposu.UcusSil(ucusNo);
        }

        public List<Ucus> UcusListele()
        {
            return VeriDeposu.TumUcuslariGetir();
        }

        public List<Rezervasyon> TumRezervasyonlariListele()
        {
            return VeriDeposu.TumRezervasyonlariGetir();
        }
    }
}