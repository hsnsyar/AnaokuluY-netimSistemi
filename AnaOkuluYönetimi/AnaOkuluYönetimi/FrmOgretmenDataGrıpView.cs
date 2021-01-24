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
    public partial class FrmOgretmenDataGrıpView : Form
    {
        public FrmOgretmenDataGrıpView()
        {
            InitializeComponent();
        }

        public string ıd, ad, soyad, tc, telefon, brans, uzantı;
        private void FrmOgretmenDataGrıpView_Load(object sender, EventArgs e)
        {
            textBox1.Text = ıd;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = tc;
            textBox5.Text = telefon;
            textBox7.Text = brans;
            pictureEdit1.Image = Image.FromFile(uzantı);

        }
    }
}
