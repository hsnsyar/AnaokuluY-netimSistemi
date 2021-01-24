namespace AnaOkuluYönetimi
{
    partial class FrmOgrtOgretmen
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
            this.GrdCntrl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCntrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdCntrl1
            // 
            this.GrdCntrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCntrl1.Location = new System.Drawing.Point(0, 0);
            this.GrdCntrl1.MainView = this.gridView1;
            this.GrdCntrl1.Name = "GrdCntrl1";
            this.GrdCntrl1.Size = new System.Drawing.Size(945, 691);
            this.GrdCntrl1.TabIndex = 0;
            this.GrdCntrl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GrdCntrl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FrmOgrtOgretmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 691);
            this.Controls.Add(this.GrdCntrl1);
            this.Name = "FrmOgrtOgretmen";
            this.Text = "FrmOgrtOgretmen";
            this.Load += new System.EventHandler(this.FrmOgrtOgretmen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCntrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrdCntrl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}