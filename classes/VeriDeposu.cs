using System;
using System.Collections.Generic;
using System.Linq;
using UcakBiletiRezervasyonSistemi.Siniflar;
using UcakBiletiRezervayonSistemi;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    public static class VeriDeposu
    {
        // Şehirler listesi veritabanından çekilmesine gerek yoktur.
        public static List<string> TumSehirler = new List<string>
        {
            "Adana (ADA)",
            "Ağrı (AJI)",
            "Ankara (ESB)",
            "Antalya (AYT)",
            "Balıkesir Koca Seyit (EDO)",
            "Bodrum/Milas (BJV)",
            "Bursa (YEI)",
            "Çanakkale (CKZ)",
            "Dalaman (DLM)",
            "Diyarbakır (DIY)",
            "Elazığ (EZS)",
            "Erzurum (ERZ)",
            "Eskişehir (AOE)",
            "Gaziantep (GZT)",
            "Hatay (HTY)",
            "Isparta (ISE)",
            "İstanbul (IST)",
            "İstanbul Sabiha Gökçen (SAW)",
            "İzmir (ADB)",
            "Kars (KSY)",
            "Kayseri (ASR)",
            "Konya (KYA)",
            "Kütahya (KZR)",
            "Malatya (MLX)",
            "Mersin/Tarsus (COV)",
            "Nevşehir (NAV)",
            "Ordu-Giresun (OGU)",
            "Rize-Artvin (RZV)",
            "Samsun (SZF)",
            "Şanlıurfa (GNY)",
            "Trabzon (TZX)",
            "Van (VAN)"
        };

        public static List<Ucus> UcusAra(string kalkis, string varis, DateTime tarih)
        {
            return SQLYonetici.UcusAra(kalkis, varis, tarih);
        }

        public static void UcusEkle(Ucus yeniUcus)
        {
            SQLYonetici.UcusKaydet(yeniUcus);
        }

        public static bool UcusSil(string ucusNo)
        {
            return SQLYonetici.UcusSil(ucusNo);
        }

        public static bool UcusGuncelle(Ucus ucus)
        {
            return SQLYonetici.UcusGuncelle(ucus);
        }

        public static List<Ucus> TumUcuslariGetir()
        {
            return SQLYonetici.TumUcuslariGetir();
        }

        public static bool RezervasyonOlustur(Yolcu yolcu, Ucus ucus, string koltukNo, decimal toplamFiyat)
        {
            return SQLYonetici.RezervasyonOlustur(yolcu, ucus, koltukNo, toplamFiyat);
        }

        public static bool RezervasyonIptalEt(int id)
        {
            return SQLYonetici.RezervasyonIptalEt(id);
        }

        public static List<Rezervasyon> YolcuRezervasyonlariListele(int yolcuID)
        {
            return SQLYonetici.YolcuRezervasyonlariListele(yolcuID);
        }

        public static List<Rezervasyon> TumRezervasyonlariGetir()
        {
            return SQLYonetici.TumRezervasyonlariGetir();
        }
    }
}