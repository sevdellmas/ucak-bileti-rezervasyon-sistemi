namespace UcakBiletiRezervayonSistemi
{
    partial class FormRezervasyonlarim
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
            this.dgvRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.lblSecilenUcusBilgi = new System.Windows.Forms.Label();
            this.btnRezervasyonIptal = new System.Windows.Forms.Button();
            this.grpDetay = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).BeginInit();
            this.grpDetay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRezervasyonlar
            // 
            this.dgvRezervasyonlar.AllowUserToResizeColumns = false;
            this.dgvRezervasyonlar.AllowUserToResizeRows = false;
            this.dgvRezervasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervasyonlar.Location = new System.Drawing.Point(29, 48);
            this.dgvRezervasyonlar.Name = "dgvRezervasyonlar";
            this.dgvRezervasyonlar.ReadOnly = true;
            this.dgvRezervasyonlar.RowHeadersWidth = 62;
            this.dgvRezervasyonlar.RowTemplate.Height = 28;
            this.dgvRezervasyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervasyonlar.Size = new System.Drawing.Size(661, 136);
            this.dgvRezervasyonlar.TabIndex = 0;
            this.dgvRezervasyonlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRezervasyonlar_CellClick);
            this.dgvRezervasyonlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRezervasyonlar_CellClick);
            // 
            // lblSecilenUcusBilgi
            // 
            this.lblSecilenUcusBilgi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecilenUcusBilgi.Location = new System.Drawing.Point(19, 31);
            this.lblSecilenUcusBilgi.Name = "lblSecilenUcusBilgi";
            this.lblSecilenUcusBilgi.Size = new System.Drawing.Size(614, 152);
            this.lblSecilenUcusBilgi.TabIndex = 1;
            this.lblSecilenUcusBilgi.Text = "Seçili Uçuş Bilgisi";
            // 
            // btnRezervasyonIptal
            // 
            this.btnRezervasyonIptal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRezervasyonIptal.FlatAppearance.BorderSize = 0;
            this.btnRezervasyonIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyonIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezervasyonIptal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRezervasyonIptal.Location = new System.Drawing.Point(233, 423);
            this.btnRezervasyonIptal.Name = "btnRezervasyonIptal";
            this.btnRezervasyonIptal.Size = new System.Drawing.Size(248, 41);
            this.btnRezervasyonIptal.TabIndex = 2;
            this.btnRezervasyonIptal.Text = "REZERVASYON İPTAL ET";
            this.btnRezervasyonIptal.UseVisualStyleBackColor = false;
            this.btnRezervasyonIptal.Click += new System.EventHandler(this.btnRezervasyonIptal_Click);
            // 
            // grpDetay
            // 
            this.grpDetay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpDetay.Controls.Add(this.lblSecilenUcusBilgi);
            this.grpDetay.Location = new System.Drawing.Point(29, 209);
            this.grpDetay.Name = "grpDetay";
            this.grpDetay.Size = new System.Drawing.Size(661, 199);
            this.grpDetay.TabIndex = 3;
            this.grpDetay.TabStop = false;
            this.grpDetay.Text = "Seçili Rezervasyon Detayı";
            // 
            // FormRezervasyonlarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.BackgroundImage = global::UcakBiletiRezervayonSistemi.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(759, 513);
            this.Controls.Add(this.grpDetay);
            this.Controls.Add(this.btnRezervasyonIptal);
            this.Controls.Add(this.dgvRezervasyonlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRezervasyonlarim";
            this.Text = "sEbilet.com";
            this.Load += new System.EventHandler(this.FormRezervasyonlarim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).EndInit();
            this.grpDetay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRezervasyonlar;
        private System.Windows.Forms.Label lblSecilenUcusBilgi;
        private System.Windows.Forms.Button btnRezervasyonIptal;
        private System.Windows.Forms.GroupBox grpDetay;
    }
}