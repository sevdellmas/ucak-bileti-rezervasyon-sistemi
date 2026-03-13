namespace UcakBiletiRezervayonSistemi
{
    partial class FormYolcuKayit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblkullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.mtxtTcKimlikNo = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelefon = new System.Windows.Forms.MaskedTextBox();
            this.lblTC = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.rBtnKadin = new System.Windows.Forms.RadioButton();
            this.btnKaydiTamamla = new System.Windows.Forms.Button();
            this.rBtnErkek = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblkullaniciAdi
            // 
            this.lblkullaniciAdi.AutoSize = true;
            this.lblkullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.lblkullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkullaniciAdi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblkullaniciAdi.Location = new System.Drawing.Point(37, 267);
            this.lblkullaniciAdi.Name = "lblkullaniciAdi";
            this.lblkullaniciAdi.Size = new System.Drawing.Size(111, 20);
            this.lblkullaniciAdi.TabIndex = 0;
            this.lblkullaniciAdi.Text = "Kullanıcı Adı:";
            this.lblkullaniciAdi.Click += new System.EventHandler(this.lblkullaniciAdi_Click);
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSifre.Location = new System.Drawing.Point(96, 304);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(52, 20);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(160, 264);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(167, 26);
            this.txtKullaniciAdi.TabIndex = 2;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(160, 301);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(167, 26);
            this.txtSifre.TabIndex = 2;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.BackColor = System.Drawing.Color.Transparent;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAd.Location = new System.Drawing.Point(112, 124);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(36, 20);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "Ad:";
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.BackColor = System.Drawing.Color.Transparent;
            this.lblSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSoyad.Location = new System.Drawing.Point(84, 159);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(64, 20);
            this.lblSoyad.TabIndex = 1;
            this.lblSoyad.Text = "Soyad:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(160, 121);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(167, 26);
            this.txtAd.TabIndex = 2;
            this.txtAd.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(160, 156);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(167, 26);
            this.txtSoyad.TabIndex = 2;
            // 
            // mtxtTcKimlikNo
            // 
            this.mtxtTcKimlikNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtxtTcKimlikNo.Location = new System.Drawing.Point(160, 191);
            this.mtxtTcKimlikNo.Mask = "00000000000";
            this.mtxtTcKimlikNo.Name = "mtxtTcKimlikNo";
            this.mtxtTcKimlikNo.Size = new System.Drawing.Size(110, 26);
            this.mtxtTcKimlikNo.TabIndex = 3;
            // 
            // mtxtTelefon
            // 
            this.mtxtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtxtTelefon.Location = new System.Drawing.Point(160, 228);
            this.mtxtTelefon.Mask = "(000) 000 00 00";
            this.mtxtTelefon.Name = "mtxtTelefon";
            this.mtxtTelefon.Size = new System.Drawing.Size(122, 26);
            this.mtxtTelefon.TabIndex = 3;
            this.mtxtTelefon.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtTelefon_MaskInputRejected);
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.BackColor = System.Drawing.Color.Transparent;
            this.lblTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTC.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTC.Location = new System.Drawing.Point(34, 193);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(114, 20);
            this.lblTC.TabIndex = 0;
            this.lblTC.Text = "TC Kimlik No:";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTelefon.Location = new System.Drawing.Point(47, 230);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(101, 20);
            this.lblTelefon.TabIndex = 1;
            this.lblTelefon.Text = "Telefon No:";
            // 
            // rBtnKadin
            // 
            this.rBtnKadin.AutoSize = true;
            this.rBtnKadin.BackColor = System.Drawing.Color.Transparent;
            this.rBtnKadin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnKadin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rBtnKadin.Location = new System.Drawing.Point(160, 346);
            this.rBtnKadin.Name = "rBtnKadin";
            this.rBtnKadin.Size = new System.Drawing.Size(79, 24);
            this.rBtnKadin.TabIndex = 4;
            this.rBtnKadin.TabStop = true;
            this.rBtnKadin.Text = "Kadın";
            this.rBtnKadin.UseVisualStyleBackColor = false;
            this.rBtnKadin.CheckedChanged += new System.EventHandler(this.rBtnKadin_CheckedChanged);
            // 
            // btnKaydiTamamla
            // 
            this.btnKaydiTamamla.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnKaydiTamamla.FlatAppearance.BorderSize = 0;
            this.btnKaydiTamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydiTamamla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydiTamamla.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnKaydiTamamla.Location = new System.Drawing.Point(160, 376);
            this.btnKaydiTamamla.Name = "btnKaydiTamamla";
            this.btnKaydiTamamla.Size = new System.Drawing.Size(153, 48);
            this.btnKaydiTamamla.TabIndex = 5;
            this.btnKaydiTamamla.Text = "Kaydı Tamamla";
            this.btnKaydiTamamla.UseVisualStyleBackColor = false;
            this.btnKaydiTamamla.Click += new System.EventHandler(this.btnKaydiTamamla_Click_1);
            // 
            // rBtnErkek
            // 
            this.rBtnErkek.AutoSize = true;
            this.rBtnErkek.BackColor = System.Drawing.Color.Transparent;
            this.rBtnErkek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnErkek.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rBtnErkek.Location = new System.Drawing.Point(247, 346);
            this.rBtnErkek.Name = "rBtnErkek";
            this.rBtnErkek.Size = new System.Drawing.Size(80, 24);
            this.rBtnErkek.TabIndex = 4;
            this.rBtnErkek.TabStop = true;
            this.rBtnErkek.Text = "Erkek";
            this.rBtnErkek.UseVisualStyleBackColor = false;
            this.rBtnErkek.CheckedChanged += new System.EventHandler(this.rBtnKadin_CheckedChanged);
            // 
            // FormYolcuKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.BackgroundImage = global::UcakBiletiRezervayonSistemi.Properties.Resources.Gemini_Generated_Image_n5dxz1n5dxz1n5dx;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(591, 531);
            this.Controls.Add(this.btnKaydiTamamla);
            this.Controls.Add(this.rBtnErkek);
            this.Controls.Add(this.rBtnKadin);
            this.Controls.Add(this.mtxtTelefon);
            this.Controls.Add(this.mtxtTcKimlikNo);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.lblTC);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblkullaniciAdi);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormYolcuKayit";
            this.Text = "sEbilet.com";
            this.Load += new System.EventHandler(this.FormYolcuKayit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblkullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.MaskedTextBox mtxtTcKimlikNo;
        private System.Windows.Forms.MaskedTextBox mtxtTelefon;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.RadioButton rBtnKadin;
        private System.Windows.Forms.Button btnKaydiTamamla;
        private System.Windows.Forms.RadioButton rBtnErkek;
    }
}