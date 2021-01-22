namespace YaseminStokTakip
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBKullaniciAdi = new System.Windows.Forms.TextBox();
            this.TBParola = new System.Windows.Forms.TextBox();
            this.BTGiris = new System.Windows.Forms.Button();
            this.LBLUyari = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(228, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(127, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(162, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parola";
            // 
            // TBKullaniciAdi
            // 
            this.TBKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TBKullaniciAdi.Location = new System.Drawing.Point(219, 125);
            this.TBKullaniciAdi.Name = "TBKullaniciAdi";
            this.TBKullaniciAdi.Size = new System.Drawing.Size(165, 24);
            this.TBKullaniciAdi.TabIndex = 3;
            // 
            // TBParola
            // 
            this.TBParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TBParola.Location = new System.Drawing.Point(219, 155);
            this.TBParola.Name = "TBParola";
            this.TBParola.PasswordChar = '*';
            this.TBParola.Size = new System.Drawing.Size(165, 24);
            this.TBParola.TabIndex = 4;
            // 
            // BTGiris
            // 
            this.BTGiris.BackColor = System.Drawing.Color.Gold;
            this.BTGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BTGiris.Location = new System.Drawing.Point(219, 185);
            this.BTGiris.Name = "BTGiris";
            this.BTGiris.Size = new System.Drawing.Size(88, 27);
            this.BTGiris.TabIndex = 5;
            this.BTGiris.Text = "Giriş";
            this.BTGiris.UseVisualStyleBackColor = false;
            this.BTGiris.Click += new System.EventHandler(this.BTGiris_Click);
            // 
            // LBLUyari
            // 
            this.LBLUyari.AutoSize = true;
            this.LBLUyari.BackColor = System.Drawing.Color.Transparent;
            this.LBLUyari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBLUyari.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LBLUyari.Location = new System.Drawing.Point(180, 225);
            this.LBLUyari.Name = "LBLUyari";
            this.LBLUyari.Size = new System.Drawing.Size(0, 18);
            this.LBLUyari.TabIndex = 6;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(553, 298);
            this.Controls.Add(this.LBLUyari);
            this.Controls.Add(this.BTGiris);
            this.Controls.Add(this.TBParola);
            this.Controls.Add(this.TBKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Giris";
            this.Text = "SERAMİK SATIŞ OTOMASYONU";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBKullaniciAdi;
        private System.Windows.Forms.TextBox TBParola;
        private System.Windows.Forms.Button BTGiris;
        private System.Windows.Forms.Label LBLUyari;
    }
}