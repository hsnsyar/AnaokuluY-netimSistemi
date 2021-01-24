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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            //Veritabından öğretmenler tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRENCILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            listele();
            ogrtsec();
        }

        void ogrtsec()
        {
            // veritabanındaki öğrencileri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_OGRENCILER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        private void BtnOgrHesapla_Click(object sender, EventArgs e)
        {
            int ogrencı;
            ogrencı = Convert.ToInt32(comboBox1.Text);
            LblSonuc.Text = (ogrencı * 8500).ToString();
            MessageBox.Show("Toplam:" + ogrencı * 8500, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRTID,OGRTSOYAD,OGRTTC From TBL_OGRETMENLER Where OGRTAD= '" + comboBox1.Text + "'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())

                bgl.baglanti().Close();
        }
    }
}
