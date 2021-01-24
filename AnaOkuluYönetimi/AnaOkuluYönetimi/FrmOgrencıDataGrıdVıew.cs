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
    public partial class FrmOgrencıDataGrıdVıew : Form
    {
        public FrmOgrencıDataGrıdVıew()
        {
            InitializeComponent();
        }

        public string ıd,ad, soyad, tc, sınıf, dogtarihi, uzantı;

        private void FrmOgrencıDataGrıdVıew_Load(object sender, EventArgs e)
        {
            textBox1.Text=ıd;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = tc;
            textBox5.Text = sınıf;
            textBox7.Text = dogtarihi;
            pictureEdit1.Image = Image.FromFile(uzantı);

        }
    }
}
