using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi;
using UcakBiletiRezervasyonSistemi.Siniflar;

namespace UcakBiletiRezervayonSistemi
{
    public partial class FormYolcuKayit : Form
    {
        public FormYolcuKayit()
        {
            InitializeComponent();
        }

        private void btnKaydiTamamla_Click_1(object sender, EventArgs e)
        {
            // --- 1. Veri Toplama ve Temizleme ---
            string kAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();

            // MaskedTextBox'lardan maske karakterlerini temizleme
            string tcKimlikNo = mtxtTcKimlikNo.Text.Replace(" ", "").Replace("-", "").Trim();
            string telefon = mtxtTelefon.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            string cinsiyet = rBtnErkek.Checked ? "Erkek" : (rBtnKadin.Checked ? "Kadın" : string.Empty);

            // --- 2. Zorunlu Alan ve Format Kontrolleri ---
            if (string.IsNullOrEmpty(kAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(cinsiyet))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tcKimlikNo.Length != 11 || !tcKimlikNo.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli rakamlardan oluşmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (telefon.Length != 10 || !telefon.All(char.IsDigit)) // Türkiye'de 10 hane
            {
                MessageBox.Show("Telefon numarası eksiksiz (10 hane) girilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 4. Yeni Yolcu Nesnesini Oluşturma ve SQL'e Ekleme ---
            try
            {
                // HATA DÜZELTİLDİ: Statik ID ataması ve listeye ekleme KODLARI SİLİNDİ.
                // Yeni ID'yi SQL IDENTITY(1,1) otomatik atayacaktır.

                Yolcu yeniYolcu = new Yolcu(0, kAdi, sifre) // ID'yi 0 gönderiyoruz, SQL atayacak
                {
                    Ad = ad,
                    Soyad = soyad,
                    TcKimlikNo = tcKimlikNo,
                    Telefon = telefon,
                    Cinsiyet = cinsiyet
                };

                SQLYonetici.YolcuKaydet(yeniYolcu);

                MessageBox.Show("Yolcu kaydınız başarıyla oluşturuldu. Şimdi giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            // SQL'den gelen UNIQUE KEY hatalarını yakalamak için exception'ı kullanırız.
            catch (SqlException sqlex) when (sqlex.Number == 2627 || sqlex.Number == 2601) // Unique Key Violation kodları
            {
                MessageBox.Show("Bu kullanıcı adı veya TC Kimlik Numarası zaten kayıtlı.", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında beklenmeyen bir hata oluştu: " + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void FormYolcuKayit_Load(object sender, EventArgs e) { }
        private void rBtnErkek_CheckedChanged(object sender, EventArgs e) { }
        private void rBtnKadin_CheckedChanged(object sender, EventArgs e) { }
        private void mtxtTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void lblkullaniciAdi_Click(object sender, EventArgs e)
        {

        }
    }
}

