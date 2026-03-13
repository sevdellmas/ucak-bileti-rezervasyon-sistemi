namespace UcakBiletiRezervasyonSistemi
{
    partial class FormYolcu
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNereden = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNereye = new System.Windows.Forms.ComboBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUcusAra = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSoyad = new System.Windows.Forms.TextBox();
            this.mskdTxtBoxTel = new System.Windows.Forms.MaskedTextBox();
            this.rBtnErkek = new System.Windows.Forms.RadioButton();
            this.rBtnKiz = new System.Windows.Forms.RadioButton();
            this.mskdTxtBoxTC = new System.Windows.Forms.MaskedTextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtBoxAd = new System.Windows.Forms.TextBox();
            this.dgvUcuslar = new System.Windows.Forms.DataGridView();
            this.grpKoltukSecimi = new System.Windows.Forms.GroupBox();
            this.pnlKoltukDuzeni = new System.Windows.Forms.Panel();
            this.lblSecilenKoltuk = new System.Windows.Forms.Label();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.txtBoxFiyat = new System.Windows.Forms.TextBox();
            this.btnRezervasyonlarim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcuslar)).BeginInit();
            this.pnlKoltukDuzeni.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(36, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nereden";
            this.label2.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cmbNereden
            // 
            this.cmbNereden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.Items.AddRange(new object[] {
            "Adana",
            "Ankara",
            "Antalya",
            "Alanya",
            "Balıkesir",
            "Bursa",
            "Çanakkale",
            "Denizli",
            "Diyarbakır",
            "Elazığ",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Hatay",
            "Isparta",
            "İstanbulx2",
            "İzmir",
            "Kars",
            "Kayseri",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Muğlax2",
            "Mersin",
            "Nevşehir",
            "Ordu-Giresun",
            "Rize-artvin",
            "Samsun",
            "Sinop",
            "Sivas",
            "Şanlıurfa",
            "Tekirdağ",
            "Trabzon",
            "Uşak",
            "Van",
            "Zonguldak"});
            this.cmbNereden.Location = new System.Drawing.Point(119, 34);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(160, 28);
            this.cmbNereden.TabIndex = 4;
            this.cmbNereden.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(48, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nereye";
            this.label3.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cmbNereye
            // 
            this.cmbNereye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.Items.AddRange(new object[] {
            "Adana",
            "Ankara",
            "Antalya",
            "Alanya",
            "Balıkesir",
            "Bursa",
            "Çanakkale",
            "Denizli",
            "Diyarbakır",
            "Elazığ",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Hatay",
            "Isparta",
            "İstanbulx2",
            "İzmir",
            "Kars",
            "Kayseri",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Muğlax2",
            "Mersin",
            "Nevşehir",
            "Ordu-Giresun",
            "Rize-artvin",
            "Samsun",
            "Sinop",
            "Sivas",
            "Şanlıurfa",
            "Tekirdağ",
            "Trabzon",
            "Uşak",
            "Van",
            "Zonguldak"});
            this.cmbNereye.Location = new System.Drawing.Point(119, 68);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(160, 28);
            this.cmbNereye.TabIndex = 4;
            this.cmbNereye.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(119, 102);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(141, 26);
            this.dtpTarih.TabIndex = 5;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(64, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarih";
            this.label4.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnUcusAra
            // 
            this.btnUcusAra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUcusAra.FlatAppearance.BorderSize = 0;
            this.btnUcusAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUcusAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUcusAra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUcusAra.Location = new System.Drawing.Point(131, 134);
            this.btnUcusAra.Name = "btnUcusAra";
            this.btnUcusAra.Size = new System.Drawing.Size(119, 36);
            this.btnUcusAra.TabIndex = 20;
            this.btnUcusAra.Text = "UÇUŞ ARA";
            this.btnUcusAra.UseVisualStyleBackColor = false;
            this.btnUcusAra.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(749, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "TC No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(776, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(748, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(738, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Telefon";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // txtBoxSoyad
            // 
            this.txtBoxSoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSoyad.Location = new System.Drawing.Point(813, 324);
            this.txtBoxSoyad.Name = "txtBoxSoyad";
            this.txtBoxSoyad.Size = new System.Drawing.Size(159, 26);
            this.txtBoxSoyad.TabIndex = 13;
            this.txtBoxSoyad.TextChanged += new System.EventHandler(this.txtBoxSoyad_TextChanged);
            // 
            // mskdTxtBoxTel
            // 
            this.mskdTxtBoxTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskdTxtBoxTel.Location = new System.Drawing.Point(813, 366);
            this.mskdTxtBoxTel.Mask = "(999) 000-0000";
            this.mskdTxtBoxTel.Name = "mskdTxtBoxTel";
            this.mskdTxtBoxTel.Size = new System.Drawing.Size(122, 26);
            this.mskdTxtBoxTel.TabIndex = 15;
            this.mskdTxtBoxTel.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskdtxtBoxtel_MaskInputRejected);
            // 
            // rBtnErkek
            // 
            this.rBtnErkek.AutoSize = true;
            this.rBtnErkek.BackColor = System.Drawing.Color.Transparent;
            this.rBtnErkek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnErkek.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rBtnErkek.Location = new System.Drawing.Point(859, 455);
            this.rBtnErkek.Name = "rBtnErkek";
            this.rBtnErkek.Size = new System.Drawing.Size(80, 24);
            this.rBtnErkek.TabIndex = 16;
            this.rBtnErkek.Text = "Erkek";
            this.rBtnErkek.UseVisualStyleBackColor = false;
            // 
            // rBtnKiz
            // 
            this.rBtnKiz.AutoSize = true;
            this.rBtnKiz.BackColor = System.Drawing.Color.Transparent;
            this.rBtnKiz.Checked = true;
            this.rBtnKiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBtnKiz.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rBtnKiz.Location = new System.Drawing.Point(780, 455);
            this.rBtnKiz.Name = "rBtnKiz";
            this.rBtnKiz.Size = new System.Drawing.Size(58, 24);
            this.rBtnKiz.TabIndex = 17;
            this.rBtnKiz.TabStop = true;
            this.rBtnKiz.Text = "Kız";
            this.rBtnKiz.UseVisualStyleBackColor = false;
            // 
            // mskdTxtBoxTC
            // 
            this.mskdTxtBoxTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskdTxtBoxTC.HidePromptOnLeave = true;
            this.mskdTxtBoxTC.Location = new System.Drawing.Point(813, 409);
            this.mskdTxtBoxTC.Mask = "00000000000";
            this.mskdTxtBoxTC.Name = "mskdTxtBoxTC";
            this.mskdTxtBoxTC.Size = new System.Drawing.Size(108, 26);
            this.mskdTxtBoxTC.TabIndex = 21;
            this.mskdTxtBoxTC.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskdTxtBoxTc_MaskInputRejected);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnKaydet.Location = new System.Drawing.Point(804, 508);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(117, 38);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtBoxAd
            // 
            this.txtBoxAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxAd.Location = new System.Drawing.Point(813, 281);
            this.txtBoxAd.Name = "txtBoxAd";
            this.txtBoxAd.Size = new System.Drawing.Size(159, 26);
            this.txtBoxAd.TabIndex = 14;
            this.txtBoxAd.TextChanged += new System.EventHandler(this.txtBoxAd_TextChanged);
            // 
            // dgvUcuslar
            // 
            this.dgvUcuslar.AllowUserToResizeColumns = false;
            this.dgvUcuslar.AllowUserToResizeRows = false;
            this.dgvUcuslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUcuslar.Location = new System.Drawing.Point(307, 27);
            this.dgvUcuslar.Name = "dgvUcuslar";
            this.dgvUcuslar.ReadOnly = true;
            this.dgvUcuslar.RowHeadersWidth = 62;
            this.dgvUcuslar.RowTemplate.Height = 28;
            this.dgvUcuslar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUcuslar.Size = new System.Drawing.Size(720, 181);
            this.dgvUcuslar.TabIndex = 24;
            this.dgvUcuslar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUcuslar_CellClick);
            this.dgvUcuslar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUcuslar_CellClick);
            // 
            // grpKoltukSecimi
            // 
            this.grpKoltukSecimi.Location = new System.Drawing.Point(20, 16);
            this.grpKoltukSecimi.Name = "grpKoltukSecimi";
            this.grpKoltukSecimi.Size = new System.Drawing.Size(524, 382);
            this.grpKoltukSecimi.TabIndex = 25;
            this.grpKoltukSecimi.TabStop = false;
            this.grpKoltukSecimi.Text = "Koltuk Seçimi";
            this.grpKoltukSecimi.Enter += new System.EventHandler(this.grpKoltukSecimi_Enter);
            // 
            // pnlKoltukDuzeni
            // 
            this.pnlKoltukDuzeni.AutoScroll = true;
            this.pnlKoltukDuzeni.BackColor = System.Drawing.Color.White;
            this.pnlKoltukDuzeni.Controls.Add(this.grpKoltukSecimi);
            this.pnlKoltukDuzeni.Location = new System.Drawing.Point(36, 261);
            this.pnlKoltukDuzeni.Name = "pnlKoltukDuzeni";
            this.pnlKoltukDuzeni.Size = new System.Drawing.Size(561, 416);
            this.pnlKoltukDuzeni.TabIndex = 26;
            this.pnlKoltukDuzeni.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKoltukDuzeni_Paint);
            // 
            // lblSecilenKoltuk
            // 
            this.lblSecilenKoltuk.AutoSize = true;
            this.lblSecilenKoltuk.BackColor = System.Drawing.Color.Transparent;
            this.lblSecilenKoltuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecilenKoltuk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSecilenKoltuk.Location = new System.Drawing.Point(109, 700);
            this.lblSecilenKoltuk.Name = "lblSecilenKoltuk";
            this.lblSecilenKoltuk.Size = new System.Drawing.Size(169, 20);
            this.lblSecilenKoltuk.TabIndex = 27;
            this.lblSecilenKoltuk.Text = "Seçilen Koltuk: YOK";
            this.lblSecilenKoltuk.Click += new System.EventHandler(this.lblSecilenKoltuk_Click);
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.BackColor = System.Drawing.Color.Transparent;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiyat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFiyat.Location = new System.Drawing.Point(317, 697);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(48, 20);
            this.lblFiyat.TabIndex = 28;
            this.lblFiyat.Text = "Fiyat";
            this.lblFiyat.Click += new System.EventHandler(this.lblFiyat_Click);
            // 
            // txtBoxFiyat
            // 
            this.txtBoxFiyat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxFiyat.Location = new System.Drawing.Point(371, 694);
            this.txtBoxFiyat.Name = "txtBoxFiyat";
            this.txtBoxFiyat.ReadOnly = true;
            this.txtBoxFiyat.Size = new System.Drawing.Size(87, 26);
            this.txtBoxFiyat.TabIndex = 29;
            this.txtBoxFiyat.TextChanged += new System.EventHandler(this.txtBoxFiyat_TextChanged);
            // 
            // btnRezervasyonlarim
            // 
            this.btnRezervasyonlarim.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRezervasyonlarim.FlatAppearance.BorderSize = 0;
            this.btnRezervasyonlarim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyonlarim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezervasyonlarim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRezervasyonlarim.Location = new System.Drawing.Point(744, 632);
            this.btnRezervasyonlarim.Name = "btnRezervasyonlarim";
            this.btnRezervasyonlarim.Size = new System.Drawing.Size(217, 45);
            this.btnRezervasyonlarim.TabIndex = 30;
            this.btnRezervasyonlarim.Text = "REZERVASYONLARIM";
            this.btnRezervasyonlarim.UseVisualStyleBackColor = false;
            this.btnRezervasyonlarim.Click += new System.EventHandler(this.btnRezervasyonlarim_Click);
            // 
            // FormYolcu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::UcakBiletiRezervayonSistemi.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 732);
            this.Controls.Add(this.btnRezervasyonlarim);
            this.Controls.Add(this.txtBoxFiyat);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.lblSecilenKoltuk);
            this.Controls.Add(this.pnlKoltukDuzeni);
            this.Controls.Add(this.dgvUcuslar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mskdTxtBoxTC);
            this.Controls.Add(this.btnUcusAra);
            this.Controls.Add(this.rBtnKiz);
            this.Controls.Add(this.rBtnErkek);
            this.Controls.Add(this.mskdTxtBoxTel);
            this.Controls.Add(this.txtBoxSoyad);
            this.Controls.Add(this.txtBoxAd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbNereye);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNereden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormYolcu";
            this.Text = "sEbilet.com";
            this.Load += new System.EventHandler(this.FormYolcu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUcuslar)).EndInit();
            this.pnlKoltukDuzeni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNereden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNereye;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUcusAra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSoyad;
        private System.Windows.Forms.MaskedTextBox mskdTxtBoxTel;
        private System.Windows.Forms.RadioButton rBtnErkek;
        private System.Windows.Forms.RadioButton rBtnKiz;
        private System.Windows.Forms.MaskedTextBox mskdTxtBoxTC;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtBoxAd;
        private System.Windows.Forms.DataGridView dgvUcuslar;
        private System.Windows.Forms.GroupBox grpKoltukSecimi;
        private System.Windows.Forms.Panel pnlKoltukDuzeni;
        private System.Windows.Forms.Label lblSecilenKoltuk;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.TextBox txtBoxFiyat;
        private System.Windows.Forms.Button btnRezervasyonlarim;
    }
}