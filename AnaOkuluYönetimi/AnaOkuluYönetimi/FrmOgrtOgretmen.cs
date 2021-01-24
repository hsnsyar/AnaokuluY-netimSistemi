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
    public partial class FrmOgrtOgretmen : Form
    {
        public FrmOgrtOgretmen()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            //Veritabından öğretmenler tablosunu getirir

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRETMENLER", bgl.baglanti());
            da.Fill(dt);
            GrdCntrl1.DataSource = dt;
        }

        private void FrmOgrtOgretmen_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
