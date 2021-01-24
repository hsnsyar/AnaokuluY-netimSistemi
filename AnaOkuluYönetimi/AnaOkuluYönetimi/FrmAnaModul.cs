using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaOkuluYönetimi
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmOgretmenler frm1;
        FrmOgrencıler frm2;
        FrmVeliler frm3;
        FrmAyarlar frm4;
        FrmDavranıslar frm5;
        FrmGiderler frm6;
        FrmFaturalar frm7;
        FrmKasa frm8;
        FrmMesajlar frm9;
        FrmIstatislik frm10;
        FrmRaporlar frm11;

        private void BtnOgretmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ögretmenler kısmına tıkladıgında ogretmenler formunu acan kod

            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new FrmOgretmenler();
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        private void BtnOgrencıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ögrencıler formuna gider

            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new FrmOgrencıler();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void BtnVelıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // veliler formuna gider

            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FrmVeliler();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ayarlar formuna gider

            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new FrmAyarlar();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("İnternet Sitemiz Yakında Hizmetinizde.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new FrmDavranıslar();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm6 = new FrmGiderler();
            frm6.MdiParent = this;
            frm6.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm7 = new FrmFaturalar();
            frm7.MdiParent = this;
            frm7.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm8 = new FrmKasa();
            frm8.MdiParent = this;
            frm8.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm9 = new FrmMesajlar();
            frm9.MdiParent = this;
            frm9.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm10 = new FrmIstatislik();
            frm10.MdiParent = this;
            frm10.Show();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm11 = new FrmRaporlar();
            frm11.MdiParent = this;
            frm11.Show();
        }
    }
}
