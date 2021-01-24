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
using System.IO;

namespace AnaOkuluYönetimi
{
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            //Veritabından öğretmenler tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRETMENLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ilekle()
        {
            // Veritabanındaki iller tablosunu getirir

            SqlCommand komut = new SqlCommand("select * from TBL_ILLER",bgl.baglanti());
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            bransgetir();
            temizle();
            
        }

        void bransgetir()
        {  
            // veritabanından braşları combobox getiren kod

            SqlCommand komut = new SqlCommand("select * from TBL_BRANSLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbBrans.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTC.Text ="";
            MskTelefon.Text = "";
            TxtMail.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            RchAdres.Text = "";
            CmbBrans.Text = "";
            pictureEdit.Text = "";
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Veritabanındaki ilçeler tablosunu getirir ve seçilen ilçeyi temizler

            Cmbilce.Properties.Items.Clear();
            Cmbilce.Text = "";

            SqlCommand komut = new SqlCommand("select * from TBL_ILCELER where sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // ögretmen tablosundan  veritabnına kayıt ekleme kaydetme işlemi

            SqlCommand komut = new SqlCommand("Insert into TBL_OGRETMENLER (OGRTAD,OGRTSOYAD,OGRTTC,OGRTTEL,OGRTMAIL,OGRTIL,OGRTILCE,OGRTADRES,OGRTBRANS,OGRTFOTO) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", Cmbil.Text);
            komut.Parameters.AddWithValue("@p7", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            // datagridview e tıklayınca bilgileri gösterme

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtID.Text = dr["OGRTID"].ToString();
                TxtAd.Text = dr["OGRTAD"].ToString();
                TxtSoyad.Text = dr["OGRTSOYAD"].ToString();
                MskTC.Text = dr["OGRTTC"].ToString();
                MskTelefon.Text = dr["OGRTTEL"].ToString();
                TxtMail.Text = dr["OGRTMAIL"].ToString();
                Cmbil.Text = dr["OGRTIL"].ToString();
                Cmbilce.Text = dr["OGRTILCE"].ToString();
                RchAdres.Text = dr["OGRTADRES"].ToString();
                CmbBrans.Text = dr["OGRTBRANS"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
                pictureEdit.Image = Image.FromFile(yeniyol);
            }
        }

        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // Ogretmenler tablosundaki bilgileri günceller

            SqlCommand komut = new SqlCommand("Update TBL_OGRETMENLER set OGRTAD=@p1,OGRTSOYAD=@p2,OGRTTC=@p3,OGRTTEL=@p4,OGRTMAIL=@p5,OGRTIL=@p6,OGRTILCE=@p7,OGRTADRES=@p8,OGRTBRANS=@p9,OGRTFOTO=@p10 where OGRTID=@p11",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", Cmbil.Text);
            komut.Parameters.AddWithValue("@p7", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // İd ye göre silme işlemi

            SqlCommand komut = new SqlCommand("Delete from TBL_OGRETMENLER where OGRTID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public string yeniyol;
        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim dosyası |*.jpg;*.png;*.nef |Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureEdit.Image = Image.FromFile(yeniyol);
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
                frm.telefon= dr["OGRTTEL"].ToString();
                frm.uzantı = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
            }
            frm.Show();
        }
    }
}
