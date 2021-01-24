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
using System.Data.Sql;

namespace AnaOkuluYönetimi
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        private void veriler()
        {
            listView1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select * from TBL_GIDERLER", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Elektrik"].ToString();
                ekle.SubItems.Add(oku["Su"].ToString());
                ekle.SubItems.Add(oku["Dogalgaz"].ToString());
                ekle.SubItems.Add(oku["Mutfak"].ToString());
                ekle.SubItems.Add(oku["Okul"].ToString());
                ekle.SubItems.Add(oku["Stok"].ToString());
                listView1.Items.Add(ekle);

            }
            bgl.baglanti().Close();
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            veriler();
        }

        private void BtnFaturaKaydet_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER(Elektrik,Su,Dogalgaz,Mutfak,Okul,Stok) values ('" + TxtElektrik.Text + "','" + TxtSu.Text + "','" + TxtDogalgaz.Text + "','"+TxtMutfak.Text+"','"+TxtOkul.Text+"','"+TxtStok.Text+"')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            veriler();
            MessageBox.Show("YEni Faturalar Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
