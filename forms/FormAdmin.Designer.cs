namespace UcakBiletiRezervayonSistemi
{
    partial class FormAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUcusNo = new System.Windows.Forms.TextBox();
            this.cmbKalkisYeri = new System.Windows.Forms.ComboBox();
            this.cmbVarisYeri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSaat = new System.Windows.Forms.DateTimePicker();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numKapasite = new System.Windows.Forms.NumericUpDown();
            this.numTemelFiyat = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvUcuslar = new System.Windows.Forms.DataGridView();
            this.btnRezervasyonListele = new System.Windows.Forms.Button();
            this.dgvTumRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.btnUcusGuncelle = new System.Windows.Forms.Button();
            this.panelSol = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numKapasite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemelFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcuslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTumRezervasyonlar)).BeginInit();
            this.panelSol.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uçuş No";
            // 
            // txtUcusNo
            // 
            this.txtUcusNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtUcusNo.Location = new System.Drawing.Point(144, 17);
            this.txtUcusNo.Name = "txtUcusNo";
            this.txtUcusNo.Size = new System.Drawing.Size(120, 26);
            this.txtUcusNo.TabIndex = 1;
            // 
            // cmbKalkisYeri
            // 
            this.cmbKalkisYeri.FormattingEnabled = true;
            this.cmbKalkisYeri.Location = new System.Drawing.Point(144, 49);
            this.cmbKalkisYeri.Name = "cmbKalkisYeri";
            this.cmbKalkisYeri.Size = new System.Drawing.Size(121, 28);
            this.cmbKalkisYeri.TabIndex = 2;
            this.cmbKalkisYeri.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbVarisYeri
            // 
            this.cmbVarisYeri.FormattingEnabled = true;
            this.cmbVarisYeri.Location = new System.Drawing.Point(144, 83);
            this.cmbVarisYeri.Name = "cmbVarisYeri";
            this.cmbVarisYeri.Size = new System.Drawing.Size(121, 28);
            this.cmbVarisYeri.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Varış Yeri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kalkış Yeri";
            // 
            // dtpSaat
            // 
            this.dtpSaat.CustomFormat = "HH:mm";
            this.dtpSaat.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSaat.Location = new System.Drawing.Point(143, 147);
            this.dtpSaat.Name = "dtpSaat";
            this.dtpSaat.ShowUpDown = true;
            this.dtpSaat.Size = new System.Drawing.Size(94, 26);
            this.dtpSaat.TabIndex = 4;
            this.dtpSaat.ValueChanged += new System.EventHandler(this.dtpSaat_ValueChanged);
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(144, 118);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(120, 26);
            this.dtpTarih.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kalkış Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kalkış Saati";
            // 
            // numKapasite
            // 
            this.numKapasite.Location = new System.Drawing.Point(144, 179);
            this.numKapasite.Name = "numKapasite";
            this.numKapasite.Size = new System.Drawing.Size(120, 26);
            this.numKapasite.TabIndex = 5;
            // 
            // numTemelFiyat
            // 
            this.numTemelFiyat.Location = new System.Drawing.Point(144, 211);
            this.numTemelFiyat.Name = "numTemelFiyat";
            this.numTemelFiyat.Size = new System.Drawing.Size(120, 26);
            this.numTemelFiyat.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Uçak Kapasitesi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bilet fİyatı";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEkle.FlatAppearance.BorderSize = 0;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEkle.Location = new System.Drawing.Point(359, 24);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(138, 41);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "UÇUŞ EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSil.Location = new System.Drawing.Point(503, 25);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(144, 40);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "UÇUŞ SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTemizle.Location = new System.Drawing.Point(135, 293);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(134, 40);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgvUcuslar
            // 
            this.dgvUcuslar.AllowUserToResizeColumns = false;
            this.dgvUcuslar.AllowUserToResizeRows = false;
            this.dgvUcuslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUcuslar.Location = new System.Drawing.Point(359, 75);
            this.dgvUcuslar.Name = "dgvUcuslar";
            this.dgvUcuslar.RowHeadersWidth = 62;
            this.dgvUcuslar.RowTemplate.Height = 28;
            this.dgvUcuslar.Size = new System.Drawing.Size(853, 212);
            this.dgvUcuslar.TabIndex = 8;
            this.dgvUcuslar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUcuslar_CellClick);
            this.dgvUcuslar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUcuslar_CellContentClick);
            // 
            // btnRezervasyonListele
            // 
            this.btnRezervasyonListele.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRezervasyonListele.FlatAppearance.BorderSize = 0;
            this.btnRezervasyonListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyonListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezervasyonListele.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRezervasyonListele.Location = new System.Drawing.Point(64, 401);
            this.btnRezervasyonListele.Name = "btnRezervasyonListele";
            this.btnRezervasyonListele.Size = new System.Drawing.Size(264, 47);
            this.btnRezervasyonListele.TabIndex = 10;
            this.btnRezervasyonListele.Text = "Rezervasyonları Listele";
            this.btnRezervasyonListele.UseVisualStyleBackColor = false;
            this.btnRezervasyonListele.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTumRezervasyonlar
            // 
            this.dgvTumRezervasyonlar.AllowUserToResizeColumns = false;
            this.dgvTumRezervasyonlar.AllowUserToResizeRows = false;
            this.dgvTumRezervasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTumRezervasyonlar.Location = new System.Drawing.Point(45, 454);
            this.dgvTumRezervasyonlar.Name = "dgvTumRezervasyonlar";
            this.dgvTumRezervasyonlar.RowHeadersWidth = 62;
            this.dgvTumRezervasyonlar.RowTemplate.Height = 28;
            this.dgvTumRezervasyonlar.Size = new System.Drawing.Size(1167, 173);
            this.dgvTumRezervasyonlar.TabIndex = 11;
            this.dgvTumRezervasyonlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTumUcuslar_CellContentClick);
            // 
            // btnUcusGuncelle
            // 
            this.btnUcusGuncelle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUcusGuncelle.FlatAppearance.BorderSize = 0;
            this.btnUcusGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUcusGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUcusGuncelle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUcusGuncelle.Location = new System.Drawing.Point(653, 25);
            this.btnUcusGuncelle.Name = "btnUcusGuncelle";
            this.btnUcusGuncelle.Size = new System.Drawing.Size(181, 40);
            this.btnUcusGuncelle.TabIndex = 12;
            this.btnUcusGuncelle.Text = "UÇUŞ GÜNCELLE";
            this.btnUcusGuncelle.UseVisualStyleBackColor = false;
            this.btnUcusGuncelle.Click += new System.EventHandler(this.btnUcusGuncelle_Click);
            // 
            // panelSol
            // 
            this.panelSol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSol.Controls.Add(this.txtUcusNo);
            this.panelSol.Controls.Add(this.cmbKalkisYeri);
            this.panelSol.Controls.Add(this.label1);
            this.panelSol.Controls.Add(this.cmbVarisYeri);
            this.panelSol.Controls.Add(this.label2);
            this.panelSol.Controls.Add(this.dtpSaat);
            this.panelSol.Controls.Add(this.label3);
            this.panelSol.Controls.Add(this.dtpTarih);
            this.panelSol.Controls.Add(this.label4);
            this.panelSol.Controls.Add(this.label7);
            this.panelSol.Controls.Add(this.label5);
            this.panelSol.Controls.Add(this.numKapasite);
            this.panelSol.Controls.Add(this.numTemelFiyat);
            this.panelSol.Controls.Add(this.label6);
            this.panelSol.Location = new System.Drawing.Point(63, 18);
            this.panelSol.Name = "panelSol";
            this.panelSol.Size = new System.Drawing.Size(290, 269);
            this.panelSol.TabIndex = 13;
            this.panelSol.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.BackgroundImage = global::UcakBiletiRezervayonSistemi.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1248, 647);
            this.Controls.Add(this.panelSol);
            this.Controls.Add(this.btnUcusGuncelle);
            this.Controls.Add(this.dgvTumRezervasyonlar);
            this.Controls.Add(this.btnRezervasyonListele);
            this.Controls.Add(this.dgvUcuslar);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdmin";
            this.Text = "sEbilet.com";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numKapasite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemelFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcuslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTumRezervasyonlar)).EndInit();
            this.panelSol.ResumeLayout(false);
            this.panelSol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUcusNo;
        private System.Windows.Forms.ComboBox cmbKalkisYeri;
        private System.Windows.Forms.ComboBox cmbVarisYeri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSaat;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numKapasite;
        private System.Windows.Forms.NumericUpDown numTemelFiyat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvUcuslar;
        private System.Windows.Forms.Button btnRezervasyonListele;
        private System.Windows.Forms.DataGridView dgvTumRezervasyonlar;
        private System.Windows.Forms.Button btnUcusGuncelle;
        private System.Windows.Forms.Panel panelSol;
    }
}