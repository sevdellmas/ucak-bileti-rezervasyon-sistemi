using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using UcakBiletiRezervasyonSistemi.Siniflar;
using System.Windows.Forms;
using System.Data;

namespace UcakBiletiRezervayonSistemi
{
    public static class SQLYonetici
    {
        private static string ConnectionString = "Server=HUAWEI\\SQLEXPRESS;Database=sEBiletDB;Trusted_Connection=True;";

        // *** YARDIMCI VE NESNE OLUŞTURMA METOTLARI ***
        
        public static Ucus UcusBul(string ucusNo)
        {
            Ucus ucus = null;
            string query = "SELECT UcusNo, KalkisYeri, VarisYeri, KalkisZamani, Kapasite, BosKoltukSayisi, TemelFiyat, DoluKoltuklar FROM Ucuslar WHERE UcusNo = @UcusNo";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UcusNo", ucusNo);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ucus = UcusNesnesiOlustur(reader);
                }
                reader.Close();
            }
            return ucus;
        }

        public static Yolcu YolcuBul(int yolcuID)
        {
            Yolcu yolcu = null;
            // Admin için sadece zorunlu 4 sütunu çeken sade sorgu
            string query = "SELECT ID, KullaniciAdi, Sifre, Rol, Ad, Soyad, TcKimlikNo, Telefon, Cinsiyet FROM Kullanicilar WHERE ID = @ID AND Rol = 'Yolcu'";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", yolcuID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    yolcu = YolcuNesnesiOlustur(reader);
                }
                reader.Close();
            }
            return yolcu;
        }

        private static Ucus UcusNesnesiOlustur(SqlDataReader reader, int startIndex = 0)
        {
            string ucusNo = reader.GetString(reader.GetOrdinal("UcusNo"));
            string kalkis = reader.GetString(reader.GetOrdinal("KalkisYeri"));
            string varis = reader.GetString(reader.GetOrdinal("VarisYeri"));
            DateTime kalkisZamani = reader.GetDateTime(reader.GetOrdinal("KalkisZamani"));

            // ⭐️ KRİTİK: FİYAT VE KAPASİTE YANLIŞ OKUNUYOR OLABİLİR. SÜTUN ADI KULLANALIM.
            int kapasite = reader.GetInt32(reader.GetOrdinal("Kapasite"));
            int bosKoltuk = reader.GetInt32(reader.GetOrdinal("BosKoltukSayisi"));
            decimal fiyat = reader.GetDecimal(reader.GetOrdinal("TemelFiyat")); // <-- SÜTUN ADI KULLANILDI

            string doluKoltuklarStr = reader.IsDBNull(reader.GetOrdinal("DoluKoltuklar")) ? string.Empty : reader.GetString(reader.GetOrdinal("DoluKoltuklar"));

            Ucus ucus = new Ucus(
                ucusNo, kalkis, varis, kalkisZamani.Date, kalkisZamani.TimeOfDay, kapasite, fiyat
            );

            ucus.BosKoltukSayisi = bosKoltuk; // Veritabanından gelen güncel sayı nesneye atanır

            if (!string.IsNullOrEmpty(doluKoltuklarStr))
            {
                string[] koltuklar = doluKoltuklarStr.Split(',');
                foreach (var koltuk in koltuklar)
                {
                    // Eğer DoluKoltuklar bir List ise Add ile ekliyoruz
                    // Bu sayede "salt okunur" hatası almayız
                    ucus.DoluKoltuklar.Add(koltuk);
                }
            }
            return ucus;
        }

        private static Yolcu YolcuNesnesiOlustur(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("ID"));
            string kAdi = reader.GetString(reader.GetOrdinal("KullaniciAdi"));
            string sifre = reader.GetString(reader.GetOrdinal("Sifre"));

            Yolcu yolcu = new Yolcu(id, kAdi, sifre);

            // KRİTİK: DBNull kontrolü ile okuma
            yolcu.Ad = reader.IsDBNull(reader.GetOrdinal("Ad")) ? null : reader.GetString(reader.GetOrdinal("Ad"));
            yolcu.Soyad = reader.IsDBNull(reader.GetOrdinal("Soyad")) ? null : reader.GetString(reader.GetOrdinal("Soyad"));
            yolcu.TcKimlikNo = reader.IsDBNull(reader.GetOrdinal("TcKimlikNo")) ? null : reader.GetString(reader.GetOrdinal("TcKimlikNo"));
            yolcu.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) ? null : reader.GetString(reader.GetOrdinal("Telefon"));
            yolcu.Cinsiyet = reader.IsDBNull(reader.GetOrdinal("Cinsiyet")) ? null : reader.GetString(reader.GetOrdinal("Cinsiyet"));

            return yolcu;
        }

        // *** KULLANICI GİRİŞ/ROL DOĞRULAMA (NULL HATASI ÇÖZÜMÜ) ***

        public static Kullanici KullaniciDogrula(string kAdi, string sifre)
        {
            Kullanici kullanici = null;

            // Admin ve Yolcu sorgularını ayrı çalıştırarak NULL hatalarını engelleme
            string adminQuery = "SELECT ID, KullaniciAdi, Sifre, Rol FROM Kullanicilar WHERE KullaniciAdi = @KAdi AND Sifre = @Sifre AND Rol = 'Admin'";
            string yolcuQuery = "SELECT ID, KullaniciAdi, Sifre, Rol, Ad, Soyad, TcKimlikNo, Telefon, Cinsiyet FROM Kullanicilar WHERE KullaniciAdi = @KAdi AND Sifre = @Sifre AND Rol = 'Yolcu'";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // 1. Admin'i Dene (Sadeleştirilmiş Sorgu)
                using (SqlCommand adminCmd = new SqlCommand(adminQuery, conn))
                {
                    adminCmd.Parameters.AddWithValue("@KAdi", kAdi);
                    adminCmd.Parameters.AddWithValue("@Sifre", sifre);
                    SqlDataReader reader = adminCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Admin Bulundu: Sadece zorunlu sütunları okur.
                        kullanici = new Admin(reader.GetInt32(reader.GetOrdinal("ID")), reader.GetString(reader.GetOrdinal("KullaniciAdi")), reader.GetString(reader.GetOrdinal("Sifre")));
                        reader.Close();
                        return kullanici;
                    }
                    reader.Close();
                }

                // 2. Yolcu'yu Dene (Tüm Detayları Çeken Sorgu)
                using (SqlCommand yolcuCmd = new SqlCommand(yolcuQuery, conn))
                {
                    yolcuCmd.Parameters.AddWithValue("@KAdi", kAdi);
                    yolcuCmd.Parameters.AddWithValue("@Sifre", sifre);
                    SqlDataReader reader = yolcuCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Yolcu Bulundu: YolcuNesnesiOlustur metodu DBNull kontrolü yapar.
                        kullanici = YolcuNesnesiOlustur(reader);
                    }
                    reader.Close();
                }
            }
            return kullanici;
        }

        public static void YolcuKaydet(Yolcu yeniYolcu)
        {
            string query = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol, Ad, Soyad, TcKimlikNo, Telefon, Cinsiyet) " +
                           "VALUES (@KAdi, @Sifre, 'Yolcu', @Ad, @Soyad, @TcKimlikNo, @Telefon, @Cinsiyet)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@KAdi", yeniYolcu.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", yeniYolcu.Sifre);
                cmd.Parameters.AddWithValue("@Ad", (object)yeniYolcu.Ad ?? DBNull.Value); // Null değer gönderme
                cmd.Parameters.AddWithValue("@Soyad", (object)yeniYolcu.Soyad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TcKimlikNo", (object)yeniYolcu.TcKimlikNo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefon", (object)yeniYolcu.Telefon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Cinsiyet", (object)yeniYolcu.Cinsiyet ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // --- UÇUŞ İŞLEMLERİ ---
        public static void UcusKaydet(Ucus yeniUcus)
        {
            string query = @"INSERT INTO Ucuslar 
                     (UcusNo, KalkisYeri, VarisYeri, KalkisZamani, Kapasite, BosKoltukSayisi, TemelFiyat, DoluKoltuklar) 
                     VALUES 
                     (@UcusNo, @Kalkis, @Varis, @Zaman, @Kapasite, @BosKoltuk, @Fiyat, @DoluKoltuklar)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UcusNo", yeniUcus.UcusNo);

                // C# kodundaki adlarla eşleşen parametreler
                cmd.Parameters.AddWithValue("@Kalkis", yeniUcus.KalkisYeri);
                cmd.Parameters.AddWithValue("@Varis", yeniUcus.VarisYeri);
                cmd.Parameters.AddWithValue("@Zaman", yeniUcus.KalkisTarihi.Add(yeniUcus.KalkisSaati));

                // ⭐️ KRİTİK ALANLAR ⭐️
                cmd.Parameters.AddWithValue("@Kapasite", yeniUcus.Kapasite);
                // Yeni uçuşta tüm koltuklar boştur, Kapasite değeri kullanılmalıdır.
                cmd.Parameters.AddWithValue("@BosKoltuk", yeniUcus.Kapasite);

                cmd.Parameters.AddWithValue("@Fiyat", yeniUcus.TemelFiyat);

                // Yeni uçuşta dolu koltuklar boş bir string olmalıdır
                cmd.Parameters.AddWithValue("@DoluKoltuklar", "");

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Uçuş ekleme sırasında veritabanı hatası oluştu: " + ex.Message, ex);
                }
            }
        }

        public static bool UcusGuncelle(Ucus ucus)
        {
            string query = @"UPDATE Ucuslar SET 
                             KalkisYeri = @Kalkis, 
                             VarisYeri = @Varis, 
                             KalkisZamani = @Zaman, 
                             Kapasite = @Kapasite, 
                             BosKoltukSayisi = @BosKoltuk, 
                             TemelFiyat = @Fiyat, 
                             DoluKoltuklar = @DoluKoltuklar
                             WHERE UcusNo = @UcusNo";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // ⭐️ KRİTİK DÜZELTME: Sorgu ve parametreler artık eşleşiyor ⭐️
                cmd.Parameters.AddWithValue("@UcusNo", ucus.UcusNo);
                cmd.Parameters.AddWithValue("@Kalkis", ucus.KalkisYeri);
                cmd.Parameters.AddWithValue("@Varis", ucus.VarisYeri);
                cmd.Parameters.AddWithValue("@Zaman", ucus.KalkisTarihi.Add(ucus.KalkisSaati));

                // Kapasite ve Boş Koltuk parametreleri (Doğru adlar ve değerler)
                cmd.Parameters.AddWithValue("@Kapasite", ucus.Kapasite);
                cmd.Parameters.AddWithValue("@BosKoltuk", ucus.BosKoltukSayisi);

                cmd.Parameters.AddWithValue("@Fiyat", ucus.TemelFiyat);
                cmd.Parameters.AddWithValue("@DoluKoltuklar", string.Join(",", ucus.DoluKoltuklar));

                try
                {
                    conn.Open();
                    int etkilenenSatir = cmd.ExecuteNonQuery();
                    return etkilenenSatir > 0;
                }
                catch (Exception ex)
                {
                    // Hata fırlatmak, FormAdmin'de MessageBox ile detaylı hata mesajı görmenizi sağlar.
                    throw new Exception("Uçuş güncelleme sırasında veritabanı hatası oluştu: " + ex.Message, ex);
                }
            }
        }

        public static bool UcusSil(string ucusNo)
        {
            string query = "DELETE FROM Ucuslar WHERE UcusNo = @UcusNo";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UcusNo", ucusNo);
                conn.Open();
                int etkilenenSatir = cmd.ExecuteNonQuery();
                return etkilenenSatir > 0;
            }
        }
            public static List<Ucus> TumUcuslariGetir()
            {
                List<Ucus> ucusListesi = new List<Ucus>();
                string query = "SELECT UcusNo, KalkisYeri, VarisYeri, KalkisZamani, Kapasite, BosKoltukSayisi, TemelFiyat, DoluKoltuklar FROM Ucuslar";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ucusListesi.Add(UcusNesnesiOlustur(reader));
                    }
                    reader.Close();
                }
                return ucusListesi;
            }

        public static List<Ucus> UcusAra(string kalkisYeri, string varisYeri, DateTime tarih)
        {
            List<Ucus> ucusListesi = new List<Ucus>();
            string query = "SELECT UcusNo, KalkisYeri, VarisYeri, KalkisZamani, Kapasite, BosKoltukSayisi, TemelFiyat, DoluKoltuklar FROM Ucuslar " +
                           "WHERE KalkisYeri = @Kalkis AND VarisYeri = @Varis AND CAST(KalkisZamani AS DATE) = @Tarih AND BosKoltukSayisi > 0 " +
                           "ORDER BY KalkisZamani ASC";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Kalkis", kalkisYeri);
                cmd.Parameters.AddWithValue("@Varis", varisYeri);
                cmd.Parameters.AddWithValue("@Tarih", tarih.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ucusListesi.Add(UcusNesnesiOlustur(reader));
                }
                reader.Close();
            }
            return ucusListesi;
        }


        // --- REZERVASYON İŞLEMLERİ ---

        public static bool RezervasyonOlustur(Yolcu yolcu, Ucus ucus, string koltukNo, decimal toplamFiyat)
        {
            // Transaction ile koltuk güncelleme ve rezervasyon ekleme (Atomik işlem)
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Uçuş nesnesindeki koltuk bilgisini güncelle (OOP mantığı)
                    if (!ucus.KoltukSec(koltukNo))
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // 2. Ucuslar tablosunu güncelle
                    string ucusGuncelleQuery = @"UPDATE Ucuslar SET 
                                                 BosKoltukSayisi = @BosKoltuk, DoluKoltuklar = @DoluKoltuklar
                                                 WHERE UcusNo = @UcusNo";
                    using (SqlCommand ucusCmd = new SqlCommand(ucusGuncelleQuery, conn, transaction))
                    {
                        ucusCmd.Parameters.AddWithValue("@BosKoltuk", ucus.BosKoltukSayisi);
                        ucusCmd.Parameters.AddWithValue("@DoluKoltuklar", string.Join(",", ucus.DoluKoltuklar));
                        ucusCmd.Parameters.AddWithValue("@UcusNo", ucus.UcusNo);
                        ucusCmd.ExecuteNonQuery();
                    }

                    // 3. Rezervasyonlar tablosuna yeni kaydı ekle
                    string rezervasyonEkleQuery = @"INSERT INTO Rezervasyonlar (YolcuID, UcusNo, KoltukNo, OdenecekFiyat, RezervasyonTarihi) 
                                                    VALUES (@YolcuID, @UcusNo, @KoltukNo, @Fiyat, @Tarih)";
                    using (SqlCommand rezervasyonCmd = new SqlCommand(rezervasyonEkleQuery, conn, transaction))
                    {
                        rezervasyonCmd.Parameters.AddWithValue("@YolcuID", yolcu.ID);
                        rezervasyonCmd.Parameters.AddWithValue("@UcusNo", ucus.UcusNo);
                        rezervasyonCmd.Parameters.AddWithValue("@KoltukNo", koltukNo);
                        rezervasyonCmd.Parameters.AddWithValue("@Fiyat", toplamFiyat);
                        rezervasyonCmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                        rezervasyonCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Rezervasyon oluşturulurken veritabanı hatası: " + ex.Message, ex);
                }
            }
        }

        // Rezervasyon iptali işlemini transaction ile güvence altına alır.
        public static bool RezervasyonIptalEt(int rezervasyonID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                string koltukNo = "";
                string ucusNo = "";

                try
                {
                    // 1. Rezervasyon bilgisini al (KoltukNo ve UcusNo gerekli)
                    string selectQuery = "SELECT KoltukNo, UcusNo FROM Rezervasyonlar WHERE RezervasyonID = @RezID";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction))
                    {
                        selectCmd.Parameters.AddWithValue("@RezID", rezervasyonID);
                        SqlDataReader reader = selectCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            koltukNo = reader.GetString(0);
                            ucusNo = reader.GetString(1);
                        }
                        reader.Close();
                    }

                    if (string.IsNullOrEmpty(ucusNo))
                    {
                        transaction.Rollback();
                        return false; // Rezervasyon bulunamadı
                    }

                    // 2. Uçuş nesnesini çek (UcusBul yardımcı metodu kullanılır) ve koltuğu boşalt
                    Ucus ilgiliUcus = UcusBul(ucusNo);
                    if (ilgiliUcus == null)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // Koltuğu boşalt (Ucus nesnesindeki mantığı kullanır)
                    ilgiliUcus.KoltukIptalEt(koltukNo);

                    // 3. Ucuslar tablosunu güncelle
                    string ucusGuncelleQuery = @"UPDATE Ucuslar SET 
                                                 BosKoltukSayisi = @BosKoltuk, DoluKoltuklar = @DoluKoltuklar
                                                 WHERE UcusNo = @UcusNo";
                    using (SqlCommand ucusCmd = new SqlCommand(ucusGuncelleQuery, conn, transaction))
                    {
                        ucusCmd.Parameters.AddWithValue("@BosKoltuk", ilgiliUcus.BosKoltukSayisi);
                        ucusCmd.Parameters.AddWithValue("@DoluKoltuklar", string.Join(",", ilgiliUcus.DoluKoltuklar));
                        ucusCmd.Parameters.AddWithValue("@UcusNo", ucusNo);
                        ucusCmd.ExecuteNonQuery();
                    }

                    // 4. Rezervasyonlar tablosundan kaydı sil
                    string deleteQuery = "DELETE FROM Rezervasyonlar WHERE RezervasyonID = @RezID";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@RezID", rezervasyonID);
                        int etkilenenSatir = deleteCmd.ExecuteNonQuery();

                        if (etkilenenSatir > 0)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Rezervasyon iptal edilirken veritabanı hatası: " + ex.Message, ex);
                }
            }
        }

        public static List<Rezervasyon> YolcuRezervasyonlariListele(int yolcuID)
        {
            List<Rezervasyon> list = new List<Rezervasyon>();
            // Yolcu ve Uçuş bilgilerini JOIN ile çekeriz.
            string query = @"SELECT R.RezervasyonID, R.KoltukNo, R.OdenecekFiyat, R.RezervasyonTarihi, 
                                   U.UcusNo, U.KalkisYeri, U.VarisYeri, U.KalkisZamani, U.Kapasite, U.BosKoltukSayisi, U.TemelFiyat, U.DoluKoltuklar 
                            FROM Rezervasyonlar R 
                            JOIN Ucuslar U ON R.UcusNo = U.UcusNo 
                            WHERE R.YolcuID = @YolcuID 
                            ORDER BY R.RezervasyonTarihi DESC";

            // Aktif yolcuyu ayrı bir sorgu ile çek (ilişkiyi kurmak için)
            Yolcu aktifYolcu = YolcuBul(yolcuID);
            if (aktifYolcu == null) return list;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@YolcuID", yolcuID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Ucus bilgileri 4. sütundan başlar (Rezervasyon bilgileri 0,1,2,3)
                    Ucus ucus = UcusNesnesiOlustur(reader, 4);

                    Rezervasyon rezervasyon = new Rezervasyon(
                        rezervasyonID: reader.GetInt32(0),
                        yolcu: aktifYolcu,
                        ucus: ucus,
                        koltukNo: reader.GetString(1),
                        fiyat: reader.GetDecimal(2)
                    );
                    rezervasyon.RezervasyonTarihi = reader.GetDateTime(3);

                    list.Add(rezervasyon);
                }
            }
            return list;
        }

        public static List<Rezervasyon> TumRezervasyonlariGetir()
        {
            List<Rezervasyon> list = new List<Rezervasyon>();
            // Tüm Rezervasyon, Uçuş ve Yolcu bilgilerini JOIN ile çekeriz.
            string query = @"SELECT R.RezervasyonID, R.KoltukNo, R.OdenecekFiyat, R.RezervasyonTarihi, 
                                   U.UcusNo, U.KalkisYeri, U.VarisYeri, U.KalkisZamani, U.Kapasite, U.BosKoltukSayisi, U.TemelFiyat, U.DoluKoltuklar,
                                   K.ID, K.KullaniciAdi, K.Sifre, K.Ad, K.Soyad, K.TcKimlikNo, K.Telefon, K.Cinsiyet
                            FROM Rezervasyonlar R 
                            JOIN Ucuslar U ON R.UcusNo = U.UcusNo 
                            JOIN Kullanicilar K ON R.YolcuID = K.ID
                            ORDER BY R.RezervasyonTarihi DESC";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Ucus bilgileri 4. sütundan başlar
                    Ucus ucus = UcusNesnesiOlustur(reader, 4);

                    // Yolcu bilgileri 12. sütundan başlar
                    // ID, KullaniciAdi ve Sifre zorunlu alan olduğu için DBNull kontrolü gerekmez
                    Yolcu yolcu = new Yolcu(reader.GetInt32(12), reader.GetString(13), reader.GetString(14))
                    {
                        // DBNull KONTROLÜ İLE GÜNCELLENEN KISIM 
                        Ad = reader.IsDBNull(15) ? null : reader.GetString(15),
                        Soyad = reader.IsDBNull(16) ? null : reader.GetString(16),
                        TcKimlikNo = reader.IsDBNull(17) ? null : reader.GetString(17),
                        Telefon = reader.IsDBNull(18) ? null : reader.GetString(18),
                        Cinsiyet = reader.IsDBNull(19) ? null : reader.GetString(19)
                    };
                    // ⭐️ KONTROL SONU ⭐️

                    Rezervasyon rezervasyon = new Rezervasyon(
                        rezervasyonID: reader.GetInt32(0),
                        yolcu: yolcu,
                        ucus: ucus,
                        koltukNo: reader.GetString(1),
                        fiyat: reader.GetDecimal(2)
                    );
                    rezervasyon.RezervasyonTarihi = reader.GetDateTime(3);

                    list.Add(rezervasyon);
                }
            }
            return list;
        }
    }
}