using System;
using System.Collections.Generic;
using System.Linq;
using UcakBiletiRezervasyonSistemi.Siniflar;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    public class Ucus
    {
        public string UcusNo { get; set; }
        public string KalkisYeri { get; set; }
        public string VarisYeri { get; set; }
        public DateTime KalkisTarihi { get; set; }
        public TimeSpan KalkisSaati { get; set; }
        public int Kapasite { get; set; }
        public int BosKoltukSayisi { get; set; }
        public decimal TemelFiyat { get; set; }

        // DoluKoltuklar özelliği SQL'den okunurken atanacak.
        public HashSet<string> DoluKoltuklar { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public Ucus(string ucusNo, string kalkis, string varis, DateTime tarih, TimeSpan saat, int kapasite, decimal temelFiyat)
        {
            UcusNo = ucusNo;
            KalkisYeri = kalkis;
            VarisYeri = varis;
            KalkisTarihi = tarih;
            KalkisSaati = saat;
            Kapasite = kapasite;
            BosKoltukSayisi = kapasite;
            TemelFiyat = temelFiyat;
        }

        public bool KoltukSec(string koltukNo)
        {
            if (BosKoltukSayisi > 0 && !DoluKoltuklar.Contains(koltukNo))
            {
                DoluKoltuklar.Add(koltukNo);
                BosKoltukSayisi--;
                return true;
            }
            return false;
        }

        public void KoltukIptalEt(string koltukNo)
        {
            if (DoluKoltuklar.Remove(koltukNo))
            {
                if (BosKoltukSayisi < Kapasite)
                    BosKoltukSayisi++;
            }
        }

        public decimal FiyatHesapla(bool camKenariMi)
        {
            decimal guncelFiyat = TemelFiyat;

            // Cast işlemi yaparak ondalıklı hesaplama sağlıyoruz
            decimal dolulukOrani = 100 - ((decimal)BosKoltukSayisi * 100 / (decimal)Kapasite);

            // Doluluk etkisi 
            if (dolulukOrani > 80)
            {
                guncelFiyat *= 1.25m; // %25 zam
            }
            else if (dolulukOrani > 50)
            {
                guncelFiyat *= 1.10m; // %10 zam
            }

            // Uçuşa kalan gün sayısı etkisi 
            TimeSpan kalanSure = KalkisTarihi - DateTime.Today;
            if (kalanSure.TotalDays >= 0 && kalanSure.TotalDays < 7)
            {
                guncelFiyat *= 1.15m; // Son hafta %15 zam
            }

            if (camKenariMi)
            {
                guncelFiyat += 100; // Cam kenarı ise 100 TL ekle
            }

            return guncelFiyat;
        }
    }
}
