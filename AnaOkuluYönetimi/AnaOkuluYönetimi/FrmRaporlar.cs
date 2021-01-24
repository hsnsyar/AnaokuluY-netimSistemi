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
using System.IO;

namespace AnaOkuluYönetimi
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
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

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            listele();
            listelerapor();
            ogrtsec();
        }

        public string yeniyol;
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRTID"].ToString();
                comboBox1.Text = dr["OGRTAD"].ToString();
                TxtSoyad.Text = dr["OGRTSOYAD"].ToString();
                MskTC.Text = dr["OGRTTC"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
        }

        private void BtnRaporKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_RAPORLAR (RaporAd,RaporSoyad,RaporTC,RaporBasTarih,RaporFoto,RaporBitTarih) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", dateEdit1.Text);
            komut.Parameters.AddWithValue("@p5", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p6", dateEdit2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Rapor Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listelerapor();
            
        }
        void listelerapor()
        {
            //Veritabından rapor tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_RAPORLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRTID,OGRTSOYAD,OGRTTC From TBL_OGRETMENLER Where OGRTAD= '" + comboBox1.Text + "'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                TxtID.Text = oku["OGRTID"].ToString();
                TxtSoyad.Text = oku["OGRTSOYAD"].ToString();
                MskTC.Text = oku["OGRTTC"].ToString();
                
            }
            bgl.baglanti().Close();
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

       
    }
}
