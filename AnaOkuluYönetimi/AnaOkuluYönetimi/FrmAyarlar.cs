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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        DbOkulEntities db = new DbOkulEntities();

        void ogrtlistele()
        {
            // ögretmen listeleme
            gridControl1.DataSource = db.AyarlarOgretmenler();
        }
        void ogrlistele()
        {
            //öğrenci listeleme
            gridControl2.DataSource = db.AyarlarOgrencıler();
        }

        void ogretmenlistesi()
        {
            var deger1 = from item in db.TBL_OGRETMENLER
                         select new
                         {
                             OGRTID = item.OGRTID,
                             OGRTADSOYAD = item.OGRTAD + " " + item.OGRTSOYAD,
                             OGRTBRANS = item.OGRTBRANS,
                         };
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.DataSource = deger1.ToList();
        }

        void ogrencılıstesı()
        {
            var deger2=from item in db.TBL_OGRENCILER
                      select new
                      {
                          OGRID = item.OGRID,
                          OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                          OGRSINIF=item.OGRSINIF,
                      };
            lookUpEdit2.Properties.ValueMember = "OGRID";
            lookUpEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
            lookUpEdit2.Properties.DataSource = deger2.ToList();
        }
        void temizle()
        {
            TxtOgrtID.Text = "";
            TxtOgrID.Text = "";
            TxtBrans.Text = "";
            TxtOgrSınıf.Text = "";
            TxtOgrtSıfre.Text = "";
            TxtSıfre.Text = "";
            MskOgrtTC.Text = "";
            MskOgrTC.Text = "";
            pictureEdit1.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
            lookUpEdit1.Properties.NullText = "Öğretmen Şeçiniz";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            ogrtlistele();
            ogrlistele();
            ogretmenlistesi();
            ogrencılıstesı();
        }

        public string yeniyol;

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            //secilen ögrencinin gridview gösterimi
            TxtOgrID.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID").ToString();
            lookUpEdit2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRADSOYAD").ToString();
            TxtOgrSınıf.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSINIF").ToString();
            MskOgrTC.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRTC").ToString();
            TxtSıfre.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSIFRE").ToString();
            string uzantı = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRFOTO").ToString();
            yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + uzantı;
            pictureEdit2.Image = Image.FromFile(yeniyol);
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            //secilen ögretmenin gridview gösterimi
            TxtOgrtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AYARLARID").ToString();
            lookUpEdit1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OGRTADSOYAD").ToString();
            TxtBrans.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OGRTBRANS").ToString();
            MskOgrtTC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OGRTTC").ToString();
            TxtOgrtSıfre.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OGRTSIFRE").ToString();
            string uzantı = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OGRTFOTO").ToString();
            yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + uzantı;
            pictureEdit1.Image = Image.FromFile(yeniyol);
        }

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtSıfre.Text = "";

            //lookupedıtede secilen kişilerin bilgilerini gösterir öğrenciler kısmı
            using(DbOkulEntities db=new DbOkulEntities())
            {
                TBL_OGRENCILER sorgu2 = db.TBL_OGRENCILER.Find(lookUpEdit2.ItemIndex + 1);
                TxtOgrID.Text = sorgu2.OGRID.ToString();
                TxtOgrSınıf.Text = sorgu2.OGRSINIF;
                MskOgrTC.Text = sorgu2.OGRTC;
                yeniyol = "C:\\Users\\hüsnü\\Desktop\\C# AnaOkulu\\AnaOkuluYönetimi\\AnaOkuluYönetimi" + "\\resimler\\" + sorgu2.OGRFOTO;
                pictureEdit2.Image = Image.FromFile(yeniyol);
            }
        }

        private void BtnOgrKaydet_Click(object sender, EventArgs e)
        {
            //ogrencı sıfre kaydetme
            TBL_OGRAYARLAR komut = new TBL_OGRAYARLAR();
            komut.AYARLAROGRID = Convert.ToInt32(TxtOgrID.Text);
            komut.OGRSIFRE = TxtSıfre.Text;
            db.TBL_OGRAYARLAR.Add(komut);
            db.SaveChanges();
            MessageBox.Show("Şifre Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();
        }

        private void BtnOgrtKaydet_Click(object sender, EventArgs e)
        {
            //ogrt şifre kaydetme
            TBL_AYARLAR komut = new TBL_AYARLAR();
            komut.AYARLARID= Convert.ToInt32(TxtOgrtID.Text);
            komut.OGRTSIFRE = TxtOgrtSıfre.Text;
            db.TBL_AYARLAR.Add(komut);
            db.SaveChanges();
            MessageBox.Show("Şifre Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrtlistele();
            temizle();
        }

        private void BtnOgrGuncelle_Click(object sender, EventArgs e)
        {
            // ogrencıler güncelleme işlememi
            int id =Convert.ToInt32( gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID"));
            var item = db.TBL_OGRAYARLAR.FirstOrDefault(x => x.AYARLAROGRID == id);
            item.OGRSIFRE = TxtSıfre.Text;
            db.SaveChanges();
            MessageBox.Show("Şifre Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();

        }

        private void BtnOgrtGuncelle_Click(object sender, EventArgs e)
        {
            // ogretmenler güncelleme işlememi
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AYARLARID"));
            var item = db.TBL_AYARLAR.FirstOrDefault(x => x.AYARLARID == id);
            item.OGRTSIFRE = TxtOgrtSıfre.Text;
            db.SaveChanges();
            MessageBox.Show("Şifre Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrtlistele();
            temizle();
            

        }

        private void BtnOgrtTemızle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnOgrTemızle_Click(object sender, EventArgs e)
        {
            temizle();
        }

    
    }
}
