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
    public partial class Alacaklar : Form
    {
        public Alacaklar()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void Alacaklar_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Borclular where BorcMiktari !=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void bORÇÖDEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString().ToUpper();
            label5.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString().ToUpper();
            label6.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString().ToUpper();
            
            label7.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString().ToUpper();
            label8.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString().ToUpper();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (textBox1.Text==null)
                {
                    textBox2.Text = label8.Text;
                }
                else
                {
                    int borc = Convert.ToInt32(label8.Text);
                    int ödenecek = Convert.ToInt32(textBox1.Text);
                    int kalanTutar = borc - ödenecek;
                    textBox2.Text = kalanTutar.ToString();
                }
            }
            catch
            {

            }
    
        }
        DataTable yenile()
        {

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_Borclular where BorcMiktari !=0", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }
       
        int alinan;
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut9 = new SqlCommand("Select AlinanÜcret From Tbl_Musteri", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                 alinan = Convert.ToInt32(dr9[0]);
            }
            int up = alinan + Convert.ToInt32(textBox1.Text);

            bgl.baglanti().Close();

            SqlCommand komutz = new SqlCommand("Update Tbl_Musteri Set AlinanÜcret=@a1 where MusteriAd=@p1 and MusteriSoyad=@p2", bgl.baglanti());
            komutz.Parameters.AddWithValue("@p1", label5.Text);
            komutz.Parameters.AddWithValue("@p2", label6.Text);
            komutz.Parameters.AddWithValue("@a1", up);
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();






            if (textBox2.Text == "0")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            SqlCommand komut1 = new SqlCommand("Update Tbl_Borclular Set BorcMiktari=@a1 where Borcluid=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",label4.Text);
            
            komut1.Parameters.Add("@a1", SqlDbType.SmallInt);
            komut1.Parameters["@a1"].Value = textBox2.Text;

         //   komut1.Parameters.AddWithValue("@a1",textBox2.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand komut5 = new SqlCommand("Update Tbl_Musteri Set UcretDurumu=@a1 where MusteriAd=@p1 and MusteriSoyad=@p2 ", bgl.baglanti());
           
            komut5.Parameters.AddWithValue("@a1", checkBox1.Checked);
            komut5.Parameters.AddWithValue("@p1", label5.Text);
            komut5.Parameters.AddWithValue("@p2", label6.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();




            SqlCommand komut3 = new SqlCommand("insert into Tbl_ÖdenenBorclar (Ad,Soyad,Telefon,ÖdenenTutar,Tarih,Saat) values (@p1,@p2,@p3,@p4,@p5,@p6) ", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",label5.Text);
            komut3.Parameters.AddWithValue("@p2",label6.Text);
            komut3.Parameters.AddWithValue("@p3",label7.Text);
            komut3.Parameters.AddWithValue("@p4",textBox1.Text);
            komut3.Parameters.AddWithValue("@p5",label9.Text);
            komut3.Parameters.AddWithValue("@p6", label10.Text);
            komut3.ExecuteNonQuery();

            bgl.baglanti().Close();

            
            int a = Convert.ToInt32(textBox1.Text);
            int b = 0 - a;
            SqlCommand komut6 = new SqlCommand("insert into Tbl_Kasa (Kasa,Tarih,AlinacakTutar) values (@p1,@p2,@p3) ", bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1", textBox1.Text);
            komut6.Parameters.AddWithValue("@p2", label9.Text);
            komut6.Parameters.AddWithValue("@p3", b);

            komut6.ExecuteNonQuery();

            bgl.baglanti().Close();

         
            MessageBox.Show( label5.Text.ToUpper()+" "+label6.Text.ToUpper()+" "+textBox1.Text+" TL"+" ALINMIŞTIR.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label4.Text = "Null";
            label5.Text = "Null";
            label6.Text = "Null";
            label7.Text = "Null";
            label8.Text = "Null";
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = yenile();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label9.Text = dt.ToLongDateString();
            label10.Text = dt.ToLongTimeString();
        }
    }
}
