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
    public partial class FrmMesajlar : Form
    {
        public FrmMesajlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnMesajKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into TBL_MESAJLAR (AdSoyad,Mesaj) values ('" + comboBox1.Text + "','" + RchTxtMesaj.Text + "')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            verilerigoster();
            MessageBox.Show("Mesaj Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void verilerigoster()
        {
            listView1.Items.Clear();
            SqlCommand komut = new SqlCommand("select*from TBL_MESAJLAR", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MesajID"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());

                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }

        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            verilerigoster();
            ogrtsec();
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

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            RchTxtMesaj.Text = listView1.SelectedItems[0].SubItems[2].Text;
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
