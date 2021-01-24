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
    public partial class FrmOgrencıler : Form
    {
        public FrmOgrencıler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            // mibik mucitler

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute MınıkMUcıtler", bgl.baglanti());
            da1.Fill(dt1);
            GrdCtrl5.DataSource = dt1;

            //mink eller

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute MınıkEller", bgl.baglanti());
            da2.Fill(dt2);
            GrdCtrl6.DataSource = dt2;

            //minik kelebekler

            DataTable dt3= new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute MınıkKelebekler", bgl.baglanti());
            da3.Fill(dt3);
            GrdCtrl7.DataSource = dt3;

            //minik dahiler

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Execute MınıkDahıler", bgl.baglanti());
            da4.Fill(dt4);
            GrdCtrl8.DataSource = dt4;
        }

        void velilistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select VELIID,(VELIANNE+' | '+VELIBABA) as 'VELI ANNE BABA' from TBL_VELILER", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELI ANNE BABA";
            lookUpEdit1.Properties.DataSource = dt;

        }

        void sehirekle()
        {
            // veritabanındaki illeri cmb ekler

            SqlCommand komut = new SqlCommand("select * from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        
        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskOgrencıNo.Text = "";
            MskTC.Text = "";
            RdBtnErkek.Text = "";
            RdBtnKız.Text = "";
            CmbSinif.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            dateEdit1.Text = "";
            RchAdres.Text = "";
            pictureEdit1.Text = "";
        }
        private void FrmOgrencıler_Load(object sender, EventArgs e)
        {
            listele();
            sehirekle();
            temizle();
            velilistesi();
        }

               
        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // scilern ilin ilcelerini ekler ve il degiştiginde ilcelerde degişir

            Cmbilce.Properties.Items.Clear();
            Cmbilce.Text = "";

            SqlCommand komut = new SqlCommand("select * from TBL_ILCELER where sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void gridView0_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView0.GetDataRow(gridView0.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTC.Text = dr["OGRTC"].ToString();
                MskOgrencıNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RdBtnErkek.Checked = true;
                }
                else
                {
                    RdBtnKız.Checked = true;
                }
                Cmbil.Text = dr["OGRIL"].ToString();
                Cmbilce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTC.Text = dr["OGRTC"].ToString();
                MskOgrencıNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RdBtnErkek.Checked = true;
                }
                else
                {
                    RdBtnKız.Checked = true;
                }
                Cmbil.Text = dr["OGRIL"].ToString();
                Cmbilce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTC.Text = dr["OGRTC"].ToString();
                MskOgrencıNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RdBtnErkek.Checked = true;
                }
                else
                {
                    RdBtnKız.Checked = true;
                }
                Cmbil.Text = dr["OGRIL"].ToString();
                Cmbilce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);

            if (dr != null)
            {
                TxtID.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTC.Text = dr["OGRTC"].ToString();
                MskOgrencıNo.Text = dr["OGRNO"].ToString();
                CmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RdBtnErkek.Checked = true;
                }
                else
                {
                    RdBtnKız.Checked = true;
                }
                Cmbil.Text = dr["OGRIL"].ToString();
                Cmbilce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        public string cinsiyet;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // veritabanına ögrencılerı kaydeden kod

            SqlCommand komut = new SqlCommand("Insert into TBL_OGRENCILER (OGRAD,OGRSOYAD,OGRNO,OGRSINIF,OGRDOGTAR,OGRCINSIYET,OGRTC,OGRIL,OGRILCE,OGRADRES,OGRFOTO,OGRVELIID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",MskOgrencıNo.Text);
            komut.Parameters.AddWithValue("@p4",CmbSinif.Text);
            komut.Parameters.AddWithValue("@p5",dateEdit1.Text);
            if (RdBtnErkek.Checked==true)
            {
                komut.Parameters.AddWithValue("@p6",cinsiyet="E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6",cinsiyet="K");
            }
            komut.Parameters.AddWithValue("@p7",MskTC.Text);
            komut.Parameters.AddWithValue("@p8",Cmbil.Text);
            komut.Parameters.AddWithValue("@p9",Cmbilce.Text);
            komut.Parameters.AddWithValue("@p10",RchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ögrenci Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        public string yeniyol;

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim dosyası |*.jpg;*.png;*.nef |Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\"+Guid.NewGuid().ToString()+".jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureEdit1.Image = Image.FromFile(yeniyol);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_OGRENCILER set OGRAD=@p1,OGRSOYAD=@p2,OGRNO=@p3,OGRSINIF=@p4,OGRDOGTAR=@p5,OGRCINSIYET=@p6,OGRTC=@p7,OGRIL=@p8,OGRILCE=@p9,OGRADRES=@p10,OGRFOTO=@p11,OGRVELIID=@p12 where OGRID=@p13", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskOgrencıNo.Text);
            komut.Parameters.AddWithValue("@p4", CmbSinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (RdBtnErkek.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "K");
            }
            komut.Parameters.AddWithValue("@p7", MskTC.Text);
            komut.Parameters.AddWithValue("@p8", Cmbil.Text);
            komut.Parameters.AddWithValue("@p9", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p10", RchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p13", TxtID.Text);
            komut.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ögrenci Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_OGRENCILER where OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ögrenci Bilgileri Silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView0_DoubleClick(object sender, EventArgs e)
        {
            // Burası grıd vıewsde kişi üzerine çift tıklandıgında öğrenci bilgileri ayrı bir formda gösterecek.

            DataRow dr = gridView0.GetDataRow(gridView0.FocusedRowHandle);
            FrmOgrencıDataGrıdVıew frm = new FrmOgrencıDataGrıdVıew();

            if (dr!=null)
            {
                frm.ıd = dr["OGRID"].ToString();
                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.sınıf = dr["OGRSINIF"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzantı= "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + dr["OGRFOTO"].ToString();
            }
            frm.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
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

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
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

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
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
