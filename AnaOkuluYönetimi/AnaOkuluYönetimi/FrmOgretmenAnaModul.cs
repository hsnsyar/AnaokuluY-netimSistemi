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
    public partial class FrmOgretmenAnaModul : Form
    {
        public FrmOgretmenAnaModul()
        {
            InitializeComponent();
        }

        

        FrmOgrtOgretmen frm1;
        FrmOgrtOgrencıler frm2;
        FrmOgrtVeliler frm3;
        FrmOgrtDavranıslar frm4;
        FrmOgrtNotlar frm5;
        FrmOgrtIstatıslık frm6;

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("İnternet Sitemiz Yakında Hizmetinizde.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void BtnOgrencıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ögrencıler formuna gider

                frm2 = new FrmOgrtOgrencıler();
                frm2.Show();
            
        }

        private void BtnOgrtOgretmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm1 = new FrmOgrtOgretmen();
            frm1.Show();
        }

        private void BtnVelıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm3 = new FrmOgrtVeliler();
            frm3.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm4 = new FrmOgrtDavranıslar();
            frm4.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm5 = new FrmOgrtNotlar();
            frm5.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm6 = new FrmOgrtIstatıslık();
            frm6.Show();
        }
    }
}
