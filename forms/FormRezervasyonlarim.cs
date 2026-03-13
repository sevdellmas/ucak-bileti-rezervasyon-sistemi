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

namespace UcakBiletiRezervayonSistemi
{
    public partial class FormRezervasyonlarim : Form
    {
        private Yolcu aktifYolcu;
        private Rezervasyon secilenRezervasyon;
        private List<Rezervasyon> aktifYolcuRezervasyonlari;
        public FormRezervasyonlarim(Yolcu yolcu)
        {
            InitializeComponent();
            this.aktifYolcu = yolcu;
            this.Text = $"{aktifYolcu.Ad} {aktifYolcu.Soyad} - Rezervasyonlarım";

            // Form açıldığında yolcunun rezervasyonlarını hemen listele.
            RezervasyonlariListele();
        }

        private void RezervasyonlariListele()
        {
            //Çekilen listeyi form içinde tutuyoruz.
            // NOT: Burada 'VeriDeposu' sınıfının hangi namespace'te olduğu varsayılıyor.
            aktifYolcuRezervasyonlari = VeriDeposu.YolcuRezervasyonlariListele(aktifYolcu.ID);

            dgvRezervasyonlar.DataSource = null; // Önceki kaynağı temizle

            if (aktifYolcuRezervasyonlari != null && aktifYolcuRezervasyonlari.Count > 0)
            {
                // DataGridView'a bağlanacak Anonim Tip (Bu, Admin formundaki Listeleme ile uyumluluk sağlar)
                dgvRezervasyonlar.DataSource = aktifYolcuRezervasyonlari
                    .Select(r => new
                    {
                        r.RezervasyonID,
                        UcusNo = r.UcusBilgisi.UcusNo,
                        Kalkis = r.UcusBilgisi.KalkisYeri,
                        Varis = r.UcusBilgisi.VarisYeri,
                        r.KoltukNo,
                        Tarih = r.UcusBilgisi.KalkisTarihi.ToShortDateString(),
                        Fiyat = r.OdenecekFiyat.ToString("C"),
                        RezervasyonTarihi = r.RezervasyonTarihi.ToShortDateString()
                    })
                    .ToList();
            }
            else
            {
                // Rezervasyon yoksa DataGridView'ı temizle ve bilgi mesajı göster
                dgvRezervasyonlar.Rows.Clear();
                MessageBox.Show("Aktif rezervasyonunuz bulunmamaktadır.", "Bilgi");
                lblSecilenUcusBilgi.Text = "Lütfen bir rezervasyon seçiniz.";
            }
        }


        // REZERVASYON İPTAL BUTONU
        private void btnRezervasyonIptal_Click(object sender, EventArgs e)
        {
            if (secilenRezervasyon == null)
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz rezervasyonu listeden seçiniz.", "Uyarı");
                return;
            }

            // Rezervasyonun geçmiş uçuş olup olmadığını kontrol et (İsteğe bağlı ek güvenlik)
            if (secilenRezervasyon.UcusBilgisi.KalkisTarihi.Date < DateTime.Today)
            {
                MessageBox.Show("Geçmiş tarihli uçuşlar iptal edilemez.", "Uyarı");
                return;
            }

            DialogResult onay = MessageBox.Show(
                $"Rezervasyon No: {secilenRezervasyon.RezervasyonID} (Koltuk: {secilenRezervasyon.KoltukNo}) kalıcı olarak iptal edilecektir. Emin misiniz?",
                "Rezervasyon İptali Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (onay == DialogResult.Yes)
            {
                // VeriDeposu'nun RezervasyonIptalEt metodunu çağır
                if (VeriDeposu.RezervasyonIptalEt(secilenRezervasyon.RezervasyonID))
                {
                    MessageBox.Show("Rezervasyon başarıyla iptal edildi ve koltuk boşaltıldı.", "Başarılı");

                    // Seçilen rezervasyon nesnesini sıfırla ve listeyi güncelle
                    secilenRezervasyon = null;
                    lblSecilenUcusBilgi.Text = "Lütfen bir rezervasyon seçiniz.";
                    RezervasyonlariListele();
                }
                else
                {
                    MessageBox.Show("Rezervasyon iptal edilirken bir sorun oluştu.", "Hata");
                }
            }
        }

        private void dgvRezervasyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Geçersiz satır indisi veya başlık satırı ise dur
            if (e.RowIndex < 0 || e.RowIndex >= dgvRezervasyonlar.RowCount)
            {
                secilenRezervasyon = null;
                lblSecilenUcusBilgi.Text = "Lütfen bir rezervasyon seçiniz.";
                return;
            }

            try
            {
                // 1. DataGridView'dan seçilen satırın anonim DataBoundItem'ını al
                DataGridViewRow row = dgvRezervasyonlar.Rows[e.RowIndex];

                // Anonim tipteki RezervasyonID alanına dynamic kullanarak erişiyoruz
                // NOT: Eğer DataGridView'ı direkt Rezervasyon nesneleriyle doldurmadıysanız bu şarttır.
                dynamic selectedItem = row.DataBoundItem;

                if (selectedItem == null) return; // Öğeyi alamazsak çık

                int rezervasyonId = (int)selectedItem.RezervasyonID; // Anonim tipten ID'yi al

                // 2. Mevcut listeden (aktifYolcuRezervasyonlari) asıl Rezervasyon nesnesini bul
                secilenRezervasyon = aktifYolcuRezervasyonlari.FirstOrDefault(r => r.RezervasyonID == rezervasyonId);

                if (secilenRezervasyon != null)
                {
                    lblSecilenUcusBilgi.Text = $"Seçilen Rezervasyon:\n" +
                                               $"Uçuş No: {secilenRezervasyon.UcusBilgisi.UcusNo}\n" +
                                               $"Kalkış/Varış: {secilenRezervasyon.UcusBilgisi.KalkisYeri} -> {secilenRezervasyon.UcusBilgisi.VarisYeri}\n" +
                                               $"Koltuk No: {secilenRezervasyon.KoltukNo} | Fiyat: {secilenRezervasyon.OdenecekFiyat:C}";
                }
                else
                {
                    lblSecilenUcusBilgi.Text = "Seçilen rezervasyon bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon detayları yüklenirken bir hata oluştu: " + ex.Message, "Hata");
                secilenRezervasyon = null;
            }
        }
        private void FormRezervasyonlarim_Load(object sender, EventArgs e) { }
        private void dgvRezervasyonlar_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
