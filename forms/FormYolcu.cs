using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi;
using UcakBiletiRezervasyonSistemi.Siniflar;
using UcakBiletiRezervayonSistemi;


namespace UcakBiletiRezervasyonSistemi
{
    public partial class FormYolcu : Form
    {
        //giriş yapan yolcuyu tutmak için gerekli olan field
        private Yolcu aktifYolcu;

        //seçilen uçuşu tutmak için gerekli olan field
        private Ucus secilenUcus;

        // Görsel seçimden gelen koltuğu tutar
        private string secilenKoltukNumarasi;

        // ⭐️ GÜÇLENDİRME: Arama sonuçlarını tutmak için form seviyesi field ⭐️
        private List<Ucus> bulunanUcuslarListesi;


        public static List<string> TumSehirler = new List<string>
        {
            "İstanbul (IST)",
            "Ankara (ESB)",
            "İzmir (ADB)",
            "Antalya (AYT)",
            "Adana (ADA)",
        };

        public FormYolcu(Yolcu yolcu)
        {
            InitializeComponent();
            this.aktifYolcu = yolcu;
            this.Text = $"Yolcu Ekranı - Hoş Geldiniz, {aktifYolcu.Ad}";
        }

        private void FormYolcu_Load(object sender, EventArgs e)
        {
            cmbNereden.DataSource = new List<string>(VeriDeposu.TumSehirler);
            cmbNereye.DataSource = new List<string>(VeriDeposu.TumSehirler);

            // Başlangıçta seçim yapmak (opsiyonel)
            if (TumSehirler.Count >= 2)
            {
                cmbNereden.SelectedIndex = 0;
                cmbNereye.SelectedIndex = 1;
            }

            // UI Ayarları
            dtpTarih.MinDate = DateTime.Today;

            // Diğer alanları başlangıçta temizle
            lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";
            txtBoxFiyat.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string kalkisYeri = cmbNereden.SelectedItem?.ToString();
                string varisYeri = cmbNereye.SelectedItem?.ToString();
                DateTime aramaTarihi = dtpTarih.Value.Date;

                if (string.IsNullOrEmpty(kalkisYeri) || string.IsNullOrEmpty(varisYeri) || kalkisYeri == varisYeri)
                {
                    MessageBox.Show("Lütfen kalkış ve varış yeri seçiniz ve farklı olduklarından emin olunuz.", "Uyarı");
                    return;
                }

                // Seçim ve Koltukları sıfırla
                secilenUcus = null;
                secilenKoltukNumarasi = null;
                pnlKoltukDuzeni.Controls.Clear(); // Görsel koltukları temizle
                lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";
                txtBoxFiyat.Clear();

                // SQLYonetici'ye yönlenir
                bulunanUcuslarListesi = SQLYonetici.UcusAra(kalkisYeri, varisYeri, aramaTarihi); // ⭐️ Form field'ına kaydet

                dgvUcuslar.DataSource = null;

                if (bulunanUcuslarListesi.Count > 0)
                {
                    // DataGridView'a anonim tip ile listeyi aktar. (Bu, CellClick'te manuel olarak Ucus nesnesini bulmamızı gerektirecek)
                    dgvUcuslar.DataSource = bulunanUcuslarListesi
                        .Select(u => new
                        {
                            u.UcusNo,
                            u.KalkisYeri,
                            u.VarisYeri,
                            u.KalkisSaati,
                            Fiyat = u.FiyatHesapla(false).ToString("C"),
                            KalanKoltuk = u.Kapasite - u.DoluKoltuklar.Count,
                            // Artık GercekUcusNesnesi'ne gerek yok, liste zaten form field'ında tutuluyor.
                        })
                        .ToList();

                    MessageBox.Show($"{bulunanUcuslarListesi.Count} adet uygun uçuş bulundu. Lütfen listeden bir uçuş seçiniz.", "Bilgi");
                }
                else
                {
                    MessageBox.Show("Seçilen kriterlere uygun uçuş bulunamadı.", "Bilgi");
                    bulunanUcuslarListesi = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında bir hata oluştu: " + ex.Message, "Hata");
            }

        }

        // --- GÖRSEL KOLTUK SEÇİM METOTLARI (YENİ) ---

        private void KoltuklariGorselOlarakOlustur(Ucus ucus)
        {
            pnlKoltukDuzeni.Controls.Clear();
            secilenKoltukNumarasi = null;
            lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";

            // Varsayım: Tek sırada 6 koltuk
            int siraSayisi = ucus.Kapasite / 6;
            if (ucus.Kapasite % 6 != 0) siraSayisi++;

            int yOffset = 10;
            List<string> doluKoltuklar = ucus.DoluKoltuklar.ToList();

            for (int i = 1; i <= siraSayisi; i++)
            {
                int xOffset = 10;

                for (char c = 'A'; c <= 'F'; c++)
                {
                    string koltukNo = $"{i}{c}";

                    // Kapasite aşımını kontrol et (koltuk numarası geçerli sırada mı?)
                    if (ucus.Kapasite < (i - 1) * 6 + (c - 'A' + 1))
                    {
                        // Bu satırın devamında koltuk oluşturmayı durdur ve sıradaki satıra geç
                        goto NextRow;
                    }

                    Button koltukButton = new Button();
                    koltukButton.Text = koltukNo;
                    koltukButton.Width = 40;
                    koltukButton.Height = 30;
                    koltukButton.Tag = koltukNo;
                    koltukButton.Location = new Point(xOffset, yOffset);

                    if (doluKoltuklar.Contains(koltukNo))
                    {
                        koltukButton.BackColor = Color.Red; // Dolu
                        koltukButton.Enabled = false;
                    }
                    else
                    {
                        koltukButton.BackColor = Color.LightGreen; // Boş
                        koltukButton.Click += KoltukButonu_Click;
                    }

                    pnlKoltukDuzeni.Controls.Add(koltukButton);

                    // Koridor boşluğunu bırak
                    if (c == 'C')
                    {
                        xOffset += 50;
                    }

                    xOffset += 50;
                }
            NextRow:
                yOffset += 40;
            }
        }

        private void KoltukButonu_Click(object sender, EventArgs e)
        {
            Button secilenButton = sender as Button;
            if (secilenButton == null) return;

            string yeniKoltukNo = secilenButton.Tag.ToString(); // Örn: "1A"

            // 1. Önceki sarı (seçili) koltuğu eski rengine (Yeşil) döndür
            foreach (Control c in pnlKoltukDuzeni.Controls)
            {
                if (c is Button btn && btn.BackColor == Color.Yellow)
                {
                    btn.BackColor = Color.LightGreen;
                }
            }

            // 2. Yeni seçimi sarı yaparak görselleştir ve değişkeni güncelle
            secilenButton.BackColor = Color.Yellow;
            secilenKoltukNumarasi = yeniKoltukNo;

            // 3. Bilgi etiketini güncelle 
            lblSecilenKoltuk.Text = $"Seçilen Koltuk: {secilenKoltukNumarasi}";

            //FİYAT HESAPLAMA MANTIĞI
            if (secilenUcus != null)
            {
                // Koltuk numarasının sonu A veya F ile bitiyorsa cam kenarıdır
                bool camKenariMi = yeniKoltukNo.EndsWith("A") || yeniKoltukNo.EndsWith("F");

                // FiyatHesapla metoduna cam kenarı bilgisini gönderiyoruz [cite: 41]
                decimal hesaplananFiyat = secilenUcus.FiyatHesapla(camKenariMi);

                // Hesaplanan tutarı TextBox içerisinde para birimi formatında göster [cite: 16]
                txtBoxFiyat.Text = hesaplananFiyat.ToString("C");
            }
        }

        // Rezervasyon Kaydetme Metodu
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // --- Ön Kontroller ---
            if (secilenUcus == null)
            {
                MessageBox.Show("Lütfen önce uçuş listesinden bir uçuş seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Görsel seçimden gelen koltuk numarasını kontrol et
            if (string.IsNullOrEmpty(secilenKoltukNumarasi))
            {
                MessageBox.Show("Lütfen görsel koltuk düzeninden bir koltuk seçimi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Veri Toplama ve Kontrol ---
            string ad = txtBoxAd.Text.Trim();
            string soyad = txtBoxSoyad.Text.Trim();
            string tcKimlikNo = mskdTxtBoxTC.Text.Trim();
            string cinsiyet = rBtnKiz.Checked ? "Kız" : (rBtnErkek.Checked ? "Erkek" : string.Empty);

            // Telefon Numarası Temizliği
            string tel = mskdTxtBoxTel.Text.Trim();
            string temizTelefonNo = new string(tel.Where(char.IsDigit).ToArray());

            // 1. Zorunlu Alan Kontrolleri
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(cinsiyet))
            {
                MessageBox.Show("Lütfen tüm Ad, Soyad ve Cinsiyet alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (temizTelefonNo.Length != 10)
            {
                MessageBox.Show("Lütfen telefon numarasını eksiksiz (10 hane) giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskdTxtBoxTel.Focus();
                return;
            }
            if (tcKimlikNo.Length != 11 || !tcKimlikNo.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli rakamlardan oluşmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskdTxtBoxTC.Focus();
                return;
            }


            // 2. Yolcu Nesnesini Güncelleme
            aktifYolcu.Ad = ad;
            aktifYolcu.Soyad = soyad;
            aktifYolcu.Telefon = temizTelefonNo;
            aktifYolcu.Cinsiyet = cinsiyet;
            aktifYolcu.TcKimlikNo = tcKimlikNo;

            // 3. Fiyat Hesaplama
            bool camKenariKayit = secilenKoltukNumarasi.EndsWith("A") || secilenKoltukNumarasi.EndsWith("F");
            decimal toplamFiyat = secilenUcus.FiyatHesapla(camKenariKayit);
            

            // 4. Rezervasyon İşlemini Başlatma (SQLYonetici'ye yönlenir)
            // NOT: secilenKoltukNumarasi field'ı kullanılıyor.
            bool basariliMi = SQLYonetici.RezervasyonOlustur(aktifYolcu, secilenUcus, secilenKoltukNumarasi, toplamFiyat);


            if (basariliMi)
            {
                MessageBox.Show($"Rezervasyonunuz başarıyla oluşturuldu!\nUçuş No: {secilenUcus.UcusNo}\nKoltuk No: {secilenKoltukNumarasi}\nFiyat: {toplamFiyat:C}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle ve sıfırla
                txtBoxAd.Clear();
                txtBoxSoyad.Clear();
                mskdTxtBoxTel.Clear();
                mskdTxtBoxTC.Clear();
                txtBoxFiyat.Clear();
                pnlKoltukDuzeni.Controls.Clear();
                secilenUcus = null;
                secilenKoltukNumarasi = null;
                lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";

                // Uçuşlar listesini temizle (Opsiyonel: Kullanıcı yeni arama yapsın diye)
                dgvUcuslar.DataSource = null;
                bulunanUcuslarListesi = null; // Listeyi de sıfırla
            }
            else
            {
                MessageBox.Show("Rezervasyon oluşturulurken bir sorun oluştu. (Koltuk başka biri tarafından seçilmiş veya veritabanı hatası olmuş olabilir)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUcuslar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bulunanUcuslarListesi != null)
            {
                DataGridViewRow row = dgvUcuslar.Rows[e.RowIndex];

                // 1. Seçilen UcusNo'yu al (DataBoundItem anonim tip olduğu için UcusNo sütunundan erişiyoruz)
                // UcusNo sütun adını DataGridView'daki sütun adıyla eşleştiğinden emin olun.
                string ucusNo = row.Cells["UcusNo"].Value.ToString();

                // 2. Gerçek Ucus nesnesini bulunan listeden UcusNo'ya göre bul
                Ucus secilenUcusGecici = bulunanUcuslarListesi.FirstOrDefault(u => u.UcusNo == ucusNo);

                if (secilenUcusGecici != null)
                {
                    // Global değişkeni ayarla
                    this.secilenUcus = secilenUcusGecici;

                    // Önceki koltuk seçimlerini sıfırla
                    this.secilenKoltukNumarasi = null;
                    lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";
                    txtBoxFiyat.Clear(); // Fiyat alanını temizle

                    // Koltuk düzenini çiz
                    KoltuklariGorselOlarakOlustur(this.secilenUcus);
                }
            }
        }

        // ⭐️ İSTENEN METOT: REZERVASYON FORMU GEÇİŞİ ⭐️
        // (FormYolcu.Designer.cs dosyanızda bu olayı tetikleyen btnRezervasyonlarim adında bir buton olduğunu varsayıyorum)
        private void btnRezervasyonlarim_Click(object sender, EventArgs e)
        {
            // aktifYolcu nesnesini FormRezervasyonlarim'a göndererek yeni formu oluşturur.
            FormRezervasyonlarim rezervasyonFormu = new FormRezervasyonlarim(this.aktifYolcu);

            // Yeni formu aç
            rezervasyonFormu.Show();
        }

        // Diğer event metodları (Değiştirilmedi)
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void txtBoxSoyad_TextChanged(object sender, EventArgs e) { }
        private void mskdtxtBoxtel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void nudFiyat_ValueChanged(object sender, EventArgs e) { }
        private void mskdTxtBoxTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void txtBoxAd_TextChanged(object sender, EventArgs e) { }
        private void grpKoltukSecimi_Enter(object sender, EventArgs e) { }
        private void lblSecilenKoltuk_Click(object sender, EventArgs e) { }
        private void pnlKoltukDuzeni_Paint(object sender, PaintEventArgs e) { }
        private void txtBoxFiyat_TextChanged(object sender, EventArgs e) { }
        private void lblFiyat_Click(object sender, EventArgs e) { }
    }
}