using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AnaOkuluYönetimi
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            //Veritabından öğretmenler tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRETMENLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ogrtsec()
        {
            // veritabanındaki öğretmneleri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_OGRETMENLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();
            ogrtsec();

            //Elektrik Gideri
            
            SqlCommand komut4 = new SqlCommand("select sum(Elektrik) as toplam4 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                LblElektrik.Text = oku4["toplam4"].ToString();

            }
            bgl.baglanti().Close();


            // Su giideri

            SqlCommand komut5 = new SqlCommand("select sum(Su) as toplam5 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                LblSu.Text = oku5["toplam5"].ToString();

            }
            bgl.baglanti().Close();


            // Dogalgaz gideri
            
            SqlCommand komut6 = new SqlCommand("select sum(Dogalgaz) as toplam6 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                LblDogalgaz.Text = oku6["toplam6"].ToString();

            }
            bgl.baglanti().Close();

            // Mutfak gideri

            SqlCommand komut7 = new SqlCommand("select sum(Mutfak) as toplam7 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                LblMutfak.Text = oku7["toplam7"].ToString();

            }
            bgl.baglanti().Close();

            //Okul gideri

            SqlCommand komut8 = new SqlCommand("select sum(Okul) as toplam8 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku8 = komut8.ExecuteReader();
            while (oku8.Read())
            {
                LblOkulMasrafı.Text = oku8["toplam8"].ToString();

            }
            bgl.baglanti().Close();

            // Stok Gider

            SqlCommand komut9 = new SqlCommand("select sum(Stok) as toplam9 from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku9 = komut9.ExecuteReader();
            while (oku9.Read())
            {
                LblStok.Text = oku9["toplam9"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {

            int pernonel;
            pernonel = Convert.ToInt32(comboBox1.Text);
            LblOgrtTutar.Text = (pernonel * 4000).ToString();

            int sonuc;
            sonuc =  (Convert.ToInt32(LblElektrik.Text) + Convert.ToInt32(LblSu.Text) + Convert.ToInt32(LblDogalgaz.Text) + Convert.ToInt32(LblMutfak.Text) + Convert.ToInt32(LblOkulMasrafı.Text) + Convert.ToInt32(LblStok.Text) );
            LblSonuc.Text = sonuc.ToString();
            MessageBox.Show("Toplam Sonuc:" +sonuc,"Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmOgretmenDataGrıpView frm = new FrmOgretmenDataGrıpView();

            if (dr != null)
            {
                frm.ıd = dr["OGRTID"].ToString();
                frm.ad = dr["OGRTAD"].ToString();
                frm.soyad = dr["OGRTSOYAD"].ToString();
                frm.tc = dr["OGRTTC"].ToString();
                frm.brans = dr["OGRTBRANS"].ToString();
                frm.telefon = dr["OGRTTEL"].ToString();
                frm.uzantı = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
            }
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRTID,OGRTSOYAD,OGRTTC From TBL_OGRETMENLER Where OGRTAD= '" + comboBox1.Text + "'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            
            bgl.baglanti().Close();
        }
    }
}
