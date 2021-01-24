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
    public partial class FrmIstatislik : Form
    {
        public FrmIstatislik()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmIstatislik_Load(object sender, EventArgs e)
        {
            ıstatislikisListele();
        }
        void ıstatislikisListele()
        {
            //Veritabından istatislik tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRTISTATISLIK", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

      
    }
}
