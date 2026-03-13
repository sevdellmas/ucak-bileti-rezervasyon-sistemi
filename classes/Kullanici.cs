using System;

namespace UcakBiletiRezervasyonSistemi.Siniflar
{
    //abstract sınıf tanımlamasında "abstract" ifadesi kullanılır.
    public abstract class Kullanici
    {
        private int _id;
        private string _kullaniciAdi;
        private string _sifre;

        public int ID { get { return _id; } set { _id = value; } }
        public string KullaniciAdi { get { return _kullaniciAdi; } set { _kullaniciAdi = value; } }
        public string Sifre { get { return _sifre; } set { _sifre = value; } }

        // Constructor
        // Alt sınıflardan ID, kullanıcı adı ve şifre zorunlu olarak alınır.
        public Kullanici(int id, string kullaniciAdi, string sifre)
        {
            this._id = id;
            this._kullaniciAdi = kullaniciAdi;
            this._sifre = sifre;
        }

        //admin ve yolcu turetilmis sınıflarının kendi içinde override ederek kullanması için abstract method olusturdum.
        //polymorphisim icin de temel olusturuyor.
        public abstract bool SistemeGirisYap(string girilenKullaniciAdi, string girilenSifre);
    }
}
