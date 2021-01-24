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
    public partial class FrmOgrencıAnaModul : Form
    {
        public FrmOgrencıAnaModul()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();



        

        private void FrmOgrencıAnaModul_Load(object sender, EventArgs e)
        {
            

            davraisListele();
            ıstatislikisListele();
            ogrsec();


        }

        void davraisListele()
        {
            //Veritabından Davranışları tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_DAVRANISLAR ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ıstatislikisListele()
        {
            //Veritabından istatislik tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRTISTATISLIK", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void ogrsec()
        {
            // veritabanındaki öğretmneleri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_OGRENCILER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRSOYAD,OGRTC,OGRSINIF,OGRFOTO From TBL_OGRENCILER Where OGRAD= '" + comboBox1.Text + "'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                
                TxtSoyad.Text = oku["OGRSOYAD"].ToString();
                TxtTC.Text = oku["OGRTC"].ToString();
                TxtSınıf.Text = oku["OGRSINIF"].ToString();
               
            }
            bgl.baglanti().Close();
        }
    }
}
