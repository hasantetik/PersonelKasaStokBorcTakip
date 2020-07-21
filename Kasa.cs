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

namespace Silver_Computer
{
    public partial class Kasa : Form
    {
        public Kasa()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        int kasa = 0;
        int alinacak = 0;
        int topTutar = 0;
        int gider = 0;
        int veresiye = 0;
        private void Kasa_Load(object sender, EventArgs e)
        {
            DateTime dtt = DateTime.Now;
            LblTarih.Text = dtt.ToLongDateString();
            SqlCommand komut4 = new SqlCommand("Select Tarih From Tbl_Kasa", bgl.baglanti());

            komut4.Parameters.AddWithValue("@p1", LblTarih.Text);
            SqlDataReader dr4 = komut4.ExecuteReader();

            while (dr4.Read())
            {
                if (comboBox1.Items.IndexOf(dr4[0]) != -1)
                {

                }
                else
                {
                    comboBox1.Items.Add(dr4[0]);
                }



            }




            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Gider,GiderAciklama From Tbl_Gider where Tarih='" + LblTarih.Text+"' ", bgl.baglanti());           
            da.Fill(dt);
      //    SqlDataAdapter da = new SqlDataAdapter("Select Tarih,Acıklama From Tbl_Gider where Tarih='" + LblTarih.Text + "' ", bgl.baglanti());
            dataGridView1.DataSource = dt;



            SqlCommand komut9 = new SqlCommand("Select Kasa,ToplamTutar,AlinacakTutar From Tbl_Kasa", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                kasa += Convert.ToInt32(dr9[0]);
                topTutar += Convert.ToInt32(dr9[1]);
                alinacak += Convert.ToInt32(dr9[2]);
            }
            bgl.baglanti().Close();

            SqlCommand komut8 = new SqlCommand("Select Gider From Tbl_Gider", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                gider += Convert.ToInt32(dr8[0]);
               
            }
            bgl.baglanti().Close();

            SqlCommand komut7 = new SqlCommand("Select tutar From Tbl_Veresiye", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                veresiye += Convert.ToInt32(dr7[0]);

            }
            bgl.baglanti().Close();




            chart1.Series["Kasa"].IsValueShownAsLabel = true;
            chart1.Series["Kasa"].Points.AddXY("Kasa", kasa);
            chart1.Series["Kasa"].Points.AddXY("Toplam Tutar", topTutar);
            chart1.Series["Kasa"].Points.AddXY("Alinacak Tutar", alinacak);
            chart1.Series["Kasa"].Points.AddXY("Gider", gider);
            chart1.Series["Kasa"].Points.AddXY("Veresiye", veresiye);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
           
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
