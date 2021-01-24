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
    public partial class FrmOgrtIstatıslık : Form
    {
        public FrmOgrtIstatıslık()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            //Veritabından ögrenciler tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRENCILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void istatisliklistele()
        {
            //Veritabından istatislik tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRTISTATISLIK", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void ogrsec()
        {
            // veritabanındaki illeri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_OGRENCILER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        private void FrmOgrtIstatıslık_Load(object sender, EventArgs e)
        {
            listele();
            istatisliklistele();
            ogrsec();
        }

        public string yeniyol;
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRID"].ToString();
                comboBox1.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTC.Text = dr["OGRTC"].ToString();
                MskOgrencıNo.Text = dr["OGRNO"].ToString();
                
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
        }

        public string cinsiyet;

        private void BtnIstKaydet_Click(object sender, EventArgs e)
        {
            // veritabanına davranış kaydeden kod

            SqlCommand komut = new SqlCommand("Insert into TBL_OGRTISTATISLIK(OgrIstAdi,OgrIstSoyadi,OgrIstNo,OgrIstTC,Ogrıstatıslık,OgrIstFoto) values (@p1,@p2,@p3,@p7,@p8,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskOgrencıNo.Text);
            
            komut.Parameters.AddWithValue("@p7", MskTC.Text);
            komut.Parameters.AddWithValue("@p8", richTextBox1.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ögrenci İstatisliği Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        void temizle()
        {
            TxtID.Text = "";
            comboBox1.Text = "";
            TxtSoyad.Text = "";
            MskOgrencıNo.Text = "";
            MskTC.Text = "";
            richTextBox1.Text = "";
            pictureEdit1.Text = "";
        }

        private void BtnIstTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRID,OGRSOYAD,OGRTC,OGRNO From TBL_OGRENCILER Where OGRAD= '" + comboBox1.Text+"'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                TxtID.Text = oku["OGRID"].ToString();
                TxtSoyad.Text = oku["OGRSOYAD"].ToString();
                MskTC.Text = oku["OGRTC"].ToString();
                MskOgrencıNo.Text = oku["OGRNO"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmOgrencıDataGrıdVıew frm = new FrmOgrencıDataGrıdVıew();

            if (dr != null)
            {
                frm.ıd = dr["OGRID"].ToString();
                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.sınıf = dr["OGRSINIF"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzantı = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
            }
            frm.Show();
        }
    }
}
