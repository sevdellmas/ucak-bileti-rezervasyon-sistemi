using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi;
using UcakBiletiRezervasyonSistemi.Siniflar;


namespace UcakBiletiRezervayonSistemi
{
    public partial class FormAdmin : Form
    {
        private Admin aktifAdmin;
        private Ucus secilenUcus;
        private List<Ucus> tumUcuslarListesi; 

        //admin formuna giriş yapan kullanıcı için constuctor
        public FormAdmin(Admin admin)
        {
            this.aktifAdmin = admin;
            this.Text = $"Admin Yönetim Ekranı - Hoş Geldiniz, {aktifAdmin.KullaniciAdi}";
            InitializeComponent();
            UcuslariListele(); //form açıldığında sistemdeki tüm uçuşlar listelenir
        }

        //tasarımcı için boş kkurucu metod
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            panelSol.BackColor = Color.FromArgb(125, 255, 255, 255); 

            // Şehir ComboBox'larını doldur
            // VeriDeposu.TumSehirler'i kullanır (bu listede İstanbul (IST) vb. olmalı)
            cmbKalkisYeri.DataSource = VeriDeposu.TumSehirler;
            cmbVarisYeri.DataSource = new List<string>(VeriDeposu.TumSehirler);

            // Tarih ve Saat Ayarları
            dtpTarih.Format = DateTimePickerFormat.Short;
            dtpTarih.MinDate = DateTime.Today;

            dtpSaat.Format = DateTimePickerFormat.Time;
            dtpSaat.ShowUpDown = true;
            dtpSaat.CustomFormat = "HH:mm";

            // NumericUpDown varsayılan değerleri (Örn: Kapasite min 6, Fiyat min 100)
            numKapasite.Minimum = 10;
            numTemelFiyat.Minimum = 100;

            numKapasite.Maximum = 1000;
            numTemelFiyat.Maximum = 99999m; // m: decimal tipini korur (yüksek fiyatlar için)
        }

        private void UcuslariListele()
        {
            dgvUcuslar.DataSource = null;
            tumUcuslarListesi = aktifAdmin.UcusListele(); 

            // UcusListele metodu VeriDeposu üzerinden tüm uçuşları çeker.
            dgvUcuslar.DataSource = tumUcuslarListesi
                .Select(u => new
                {
                    u.UcusNo,
                    u.KalkisYeri,
                    u.VarisYeri,
                    Tarih = u.KalkisTarihi.ToShortDateString(),
                    Saat = u.KalkisSaati.ToString(@"hh\:mm"),
                    u.Kapasite,
                    u.BosKoltukSayisi,
                    u.TemelFiyat
                })
                .ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Veri alımı
                string ucusNo = txtUcusNo.Text.Trim();
                string kalkisYeri = cmbKalkisYeri.Text.Trim();
                string varisYeri = cmbVarisYeri.Text.Trim();
                int kapasite = (int)numKapasite.Value;
                decimal temelFiyat = numTemelFiyat.Value;
                DateTime tarih = dtpTarih.Value.Date;
                TimeSpan saat = dtpSaat.Value.TimeOfDay;

                // Kontroller
                if (string.IsNullOrEmpty(ucusNo) || kalkisYeri == varisYeri || kapasite <= 0 || temelFiyat <= 0)
                {
                    MessageBox.Show("Tüm alanları doğru doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime kalkisZamani = tarih.Add(saat);

                // Uçuş nesnesini oluştur ve ekle
                Ucus yeniUcus = new Ucus(
                    ucusNo, kalkisYeri, varisYeri, kalkisZamani, saat, kapasite, temelFiyat
                );

                VeriDeposu.UcusEkle(yeniUcus);

                MessageBox.Show($"Uçuş ({ucusNo}) başarıyla sisteme eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcuslariListele();
                AlanlariTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uçuş eklenirken bir hata oluştu: " + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'dan seçilen satırdaki Uçuş No'yu al
                if (dgvUcuslar.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz uçuşu listeden seçiniz.", "Uyarı");
                    return;
                }

                string secilenUcusNo = dgvUcuslar.SelectedRows[0].Cells["UcusNo"].Value.ToString();

                DialogResult onay = MessageBox.Show($"Uçuş No: {secilenUcusNo} kalıcı olarak silinecektir. Emin misiniz?",
                                                  "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (onay == DialogResult.Yes)
                {
                    if (VeriDeposu.UcusSil(secilenUcusNo)) // VeriDeposu metodu SQL'e yönlenir
                    {
                        MessageBox.Show($"Uçuş ({secilenUcusNo}) başarıyla silindi.", "Başarılı");
                        UcuslariListele();
                        AlanlariTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Uçuş bulunamadı veya silinemedi.", "Hata");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız: Bu uçuşa ait rezervasyonlar bulunabilir. " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Temizleme işlemi
        private void AlanlariTemizle()
        {
            txtUcusNo.Clear();
            txtUcusNo.ReadOnly = false; // Yeni ekleme yapılabilmesi için aç
            numKapasite.Value = numKapasite.Minimum;
            numTemelFiyat.Value = numTemelFiyat.Minimum;
            dtpTarih.Value = DateTime.Today;

            // Sıfırlama sırasında listenin dolu olduğundan emin ol (opsiyonel)
            if (cmbKalkisYeri.DataSource is List<string> && ((List<string>)cmbKalkisYeri.DataSource).Count > 1)
            {
                cmbKalkisYeri.SelectedIndex = 0;
                cmbVarisYeri.SelectedIndex = 1;
            }
            secilenUcus = null;
        }

        private void TumRezervasyonlariListele()
        {
            // Tüm Rezervasyonları VeriDeposu üzerinden çek
            List<Rezervasyon> tumRezervasyonlar = aktifAdmin.TumRezervasyonlariListele();

            // Güvenlik kontrolü
            if (dgvTumRezervasyonlar == null) return;

            dgvTumRezervasyonlar.DataSource = null;

            if (tumRezervasyonlar != null && tumRezervasyonlar.Count > 0)
            {
                // İlişkili bilgileri göster
                dgvTumRezervasyonlar.DataSource = tumRezervasyonlar
                    .Select(r => new
                    {
                        r.RezervasyonID,
                        UcusNo = r.UcusBilgisi.UcusNo,
                        YolcuAdi = r.YolcuBilgisi.Ad,
                        YolcuSoyadi = r.YolcuBilgisi.Soyad,
                        Kalkis = r.UcusBilgisi.KalkisYeri,
                        Varis = r.UcusBilgisi.VarisYeri,
                        r.KoltukNo,
                        Fiyat = r.OdenecekFiyat.ToString("C"),
                        RezervasyonTarihi = r.RezervasyonTarihi.ToShortDateString()
                    })
                    .ToList();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            AlanlariTemizle();
            MessageBox.Show("Giriş alanları temizlendi.", "Bilgi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TumRezervasyonlariListele();
            MessageBox.Show("Tüm rezervasyonlar listesi güncellendi.", "Bilgi");
        }

        private void btnUcusGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenUcus == null || txtUcusNo.ReadOnly == false)
            {
                MessageBox.Show("Lütfen önce listeden güncellemek istediğiniz bir uçuş seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Güncel Veri Alımı
                string kalkisYeri = cmbKalkisYeri.Text.Trim();
                string varisYeri = cmbVarisYeri.Text.Trim();
                int yeniKapasite = (int)numKapasite.Value; // Yeni kapasite
                decimal temelFiyat = numTemelFiyat.Value;
                DateTime tarih = dtpTarih.Value.Date;
                TimeSpan saat = dtpSaat.Value.TimeOfDay;

                // secilenUcus.DoluKoltuklar.Count, koltuk listesinin güncel sayısını verir.
                int mevcutDoluKoltukSayisi = secilenUcus.Kapasite - secilenUcus.BosKoltukSayisi;

                if (yeniKapasite < mevcutDoluKoltukSayisi)
                {
                    MessageBox.Show($"Yeni kapasite ({yeniKapasite}), mevcut dolu koltuk sayısından ({mevcutDoluKoltukSayisi}) az olamaz.", "Kapasite Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mevcut Uçuş Nesnesini Güncel Verilerle Doldur
                secilenUcus.KalkisYeri = kalkisYeri;
                secilenUcus.VarisYeri = varisYeri;
                secilenUcus.KalkisTarihi = tarih;
                secilenUcus.KalkisSaati = saat;

                // Kapasiteyi ayarla
                secilenUcus.Kapasite = yeniKapasite;

                // Yeni kapasiteye göre boş koltuk sayısını yeniden hesapla
                secilenUcus.BosKoltukSayisi = yeniKapasite - mevcutDoluKoltukSayisi;

                secilenUcus.TemelFiyat = temelFiyat;

                // Veritabanında Güncelleme
                if (VeriDeposu.UcusGuncelle(secilenUcus))
                {
                    MessageBox.Show($"Uçuş ({secilenUcus.UcusNo}) başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcuslariListele();
                    AlanlariTemizle();
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız oldu. Veritabanı hatası veya uçuş bulunamadı.", "Hata");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uçuş güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUcuslar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tumUcuslarListesi != null)
            {
                // 1. Seçilen satırdaki UcusNo'yu al
                DataGridViewRow row = dgvUcuslar.Rows[e.RowIndex];

                // UcusNo sütun adını DataGridView'daki sütun adıyla eşleştiğinden emin olun.
                string ucusNo = row.Cells["UcusNo"].Value.ToString();

                // 2. Gerçek Ucus nesnesini form seviyesinde tutulan listeden bul
                Ucus secilenUcusGecici = tumUcuslarListesi.FirstOrDefault(u => u.UcusNo == ucusNo);

                if (secilenUcusGecici != null)
                {
                    // 3. Global değişkeni ayarla (Güncelleme butonunun algılaması için HAYATİ)
                    this.secilenUcus = secilenUcusGecici;

                    // 4. Formdaki kontrol kutularını seçilen uçuşun bilgileriyle doldur

                    // Metin Kutuları
                    txtUcusNo.Text = secilenUcus.UcusNo;
                    // NumericUpDown kontrollerine değer ataması
                    numKapasite.Value = secilenUcus.Kapasite;
                    numTemelFiyat.Value = secilenUcus.TemelFiyat;

                    // ComboBox'lar
                    cmbKalkisYeri.SelectedItem = secilenUcus.KalkisYeri;
                    cmbVarisYeri.SelectedItem = secilenUcus.VarisYeri;

                    // 5. DateTimePicker Kontrolleri
                    dtpTarih.Value = secilenUcus.KalkisTarihi;
                    dtpSaat.Value = DateTime.Today.Date.Add(secilenUcus.KalkisSaati);

                    // 6. Güncelleme ve Silme işlemleri için Uçuş No alanını kilitle
                    txtUcusNo.ReadOnly = true;
                }
            }
        }

        private void dgvTumUcuslar_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dtpSaat_ValueChanged(object sender, EventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvUcuslar_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}