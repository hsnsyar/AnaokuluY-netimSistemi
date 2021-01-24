namespace AnaOkuluYönetimi
{
    partial class FrmGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSıfre2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.MskTC = new System.Windows.Forms.MaskedTextBox();
            this.BtnYonetıcı = new System.Windows.Forms.Button();
            this.BtnOgretmen = new System.Windows.Forms.Button();
            this.BtnOgrencı = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSıfre2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(125, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 42);
            this.panel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(487, 35);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "SAYAR ANAOKULU GİRİŞ PANELİ";
            // 
            // TxtSıfre2
            // 
            this.TxtSıfre2.Location = new System.Drawing.Point(494, 449);
            this.TxtSıfre2.Name = "TxtSıfre2";
            this.TxtSıfre2.Properties.UseSystemPasswordChar = true;
            this.TxtSıfre2.Size = new System.Drawing.Size(121, 20);
            this.TxtSıfre2.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(99, 450);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Kullanıcı:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(444, 447);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 19);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Şifre:";
            // 
            // MskTC
            // 
            this.MskTC.Location = new System.Drawing.Point(180, 449);
            this.MskTC.Mask = "00000000000";
            this.MskTC.Name = "MskTC";
            this.MskTC.Size = new System.Drawing.Size(100, 20);
            this.MskTC.TabIndex = 5;
            this.MskTC.ValidatingType = typeof(int);
            // 
            // BtnYonetıcı
            // 
            this.BtnYonetıcı.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnYonetıcı.BackgroundImage")));
            this.BtnYonetıcı.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnYonetıcı.Location = new System.Drawing.Point(117, 472);
            this.BtnYonetıcı.Name = "BtnYonetıcı";
            this.BtnYonetıcı.Size = new System.Drawing.Size(163, 110);
            this.BtnYonetıcı.TabIndex = 6;
            this.BtnYonetıcı.UseVisualStyleBackColor = true;
            this.BtnYonetıcı.Click += new System.EventHandler(this.BtnYonetıcı_Click);
            // 
            // BtnOgretmen
            // 
            this.BtnOgretmen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnOgretmen.BackgroundImage")));
            this.BtnOgretmen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOgretmen.Location = new System.Drawing.Point(286, 472);
            this.BtnOgretmen.Name = "BtnOgretmen";
            this.BtnOgretmen.Size = new System.Drawing.Size(159, 110);
            this.BtnOgretmen.TabIndex = 6;
            this.BtnOgretmen.UseVisualStyleBackColor = true;
            this.BtnOgretmen.Click += new System.EventHandler(this.BtnOgretmen_Click);
            // 
            // BtnOgrencı
            // 
            this.BtnOgrencı.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnOgrencı.BackgroundImage")));
            this.BtnOgrencı.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOgrencı.Location = new System.Drawing.Point(451, 472);
            this.BtnOgrencı.Name = "BtnOgrencı";
            this.BtnOgrencı.Size = new System.Drawing.Size(164, 110);
            this.BtnOgrencı.TabIndex = 6;
            this.BtnOgrencı.UseVisualStyleBackColor = true;
            this.BtnOgrencı.Click += new System.EventHandler(this.BtnOgrencı_Click);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 581);
            this.Controls.Add(this.BtnOgrencı);
            this.Controls.Add(this.BtnOgretmen);
            this.Controls.Add(this.BtnYonetıcı);
            this.Controls.Add(this.MskTC);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtSıfre2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Paneli";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSıfre2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtSıfre2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.MaskedTextBox MskTC;
        private System.Windows.Forms.Button BtnYonetıcı;
        private System.Windows.Forms.Button BtnOgretmen;
        private System.Windows.Forms.Button BtnOgrencı;
    }
}