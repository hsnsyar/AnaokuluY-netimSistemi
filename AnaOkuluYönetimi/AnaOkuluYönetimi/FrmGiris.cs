using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AnaOkuluYönetimi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnYonetıcı_Click(object sender, EventArgs e)
        {
            // yönetici giriş paneli
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE From TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID where OGRTTC=@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSıfre2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul frm1 = new FrmAnaModul();
                frm1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre.");
                MskTC.Text = "";
                TxtSıfre2.Text = "";
            }
            bgl.baglanti().Close();
        }

        private void BtnOgretmen_Click(object sender, EventArgs e)
        {
            // öğretmen giriş panelı
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE From TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID where OGRTTC=@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSıfre2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmOgretmenAnaModul frm2 = new FrmOgretmenAnaModul();
                frm2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre.");
                MskTC.Text = "";
                TxtSıfre2.Text = "";
            }
            bgl.baglanti().Close();
        }

        private void BtnOgrencı_Click(object sender, EventArgs e)
        {
            // öğrenci giriş panelı
            SqlCommand komut = new SqlCommand("select OGRTC,OGRSIFRE From TBL_OGRAYARLAR inner join TBL_OGRENCILER on TBL_OGRAYARLAR.AYARLAROGRID=TBL_OGRENCILER.OGRID where OGRTC=@p1 and OGRSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSıfre2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrencıAnaModul frm3 = new FrmOgrencıAnaModul();
                frm3.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre.");
                MskTC.Text = "";
                TxtSıfre2.Text = "";
            }
            bgl.baglanti().Close();
        }
    }
}
