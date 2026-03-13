using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi.Siniflar;
using UcakBiletiRezervayonSistemi;

namespace UcakBiletiRezervasyonSistemi
{
    public partial class FormAcilis : Form
    {
        public FormAcilis()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string girilenKullaniciAdi = txtKullaniciAdi.Text.Trim();
            string girilenSifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(girilenKullaniciAdi) || string.IsNullOrEmpty(girilenSifre))
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre alanlarını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bu metot SQL'den kullanıcıyı çeker, rolüne göre Admin/Yolcu nesnesi döndürür.
            Kullanici girisYapanKullanici = SQLYonetici.KullaniciDogrula(girilenKullaniciAdi, girilenSifre);

            if (girisYapanKullanici != null)
            {
                // 1. Admin Kontrolü
                if (girisYapanKullanici is Admin admin)
                {
                    MessageBox.Show("Admin girişi başarılı!", "Başarılı");
                    // Admin nesnesini FormAdmin'e gönderiyoruz.
                    FormAdmin adminFormu = new FormAdmin(admin);
                    adminFormu.Show();
                    this.Hide();
                }
                // 2. Yolcu Kontrolü
                else if (girisYapanKullanici is Yolcu aktifYolcu)
                {
                    MessageBox.Show($"Hoş geldiniz, {aktifYolcu.KullaniciAdi}. Uçuş arama bölümüne yönlendiriliyorsunuz.", "Başarılı");

                    // Yolcu nesnesini FormYolcu'ya gönderiyoruz
                    FormYolcu yolcuFormu = new FormYolcu(aktifYolcu);
                    yolcuFormu.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya parola!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btUyeOl_Click(object sender, EventArgs e)
        {
            FormYolcuKayit kayitFormu = new FormYolcuKayit();
            // ShowDialog(), bu form kapanana kadar ana form ile etkileşimi engeller.
            kayitFormu.ShowDialog();
        }

        private void FormAcilis_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtsifre_TextChanged(object sender, EventArgs e) { }
        private void FormAcilis_Load(object sender, EventArgs e) { }
        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e) { }

    }
}
