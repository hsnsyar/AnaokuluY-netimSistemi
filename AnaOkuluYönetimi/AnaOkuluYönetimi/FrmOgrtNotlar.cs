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
    public partial class FrmOgrtNotlar : Form
    {
        public FrmOgrtNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        private void verilerigoster()
        {
            listView1.Items.Clear();
            SqlCommand komut = new SqlCommand("select*from TBL_OGRTNOTLAR", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["NotID"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Notlar"].ToString());

                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        private void FrmOgrtNotlar_Load(object sender, EventArgs e)
        {
            verilerigoster();
            ogrtsec();
        }

        void ogrtsec()
        {
            // veritabanındaki ogretmenleri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_OGRETMENLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnOgrtNotKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_OGRTNOTLAR (AdSoyad,Notlar) values ('" + comboBox1.Text + "','" + RchTxtNot.Text + "')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Kayıt Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verilerigoster();
        }

        int id = 0;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            RchTxtNot.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRTTC From TBL_OGRETMENLER Where OGRTAD= '" + comboBox1.Text + "'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                
                textBox1.Text = oku["OGRTTC"].ToString();
               
            }
            bgl.baglanti().Close();
        }
    }
}
