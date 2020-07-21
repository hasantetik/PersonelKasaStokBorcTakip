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
    public partial class BursaTakip : Form
    {
        public BursaTakip()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void BursaTakip_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select id,Ad,Soyad,Telefon,CihazModeli,Ariza From Tbl_Bursa where CihazDurumu=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        DataTable yenile()
        {

            SqlDataAdapter adtr = new SqlDataAdapter("Select id,Ad,Soyad,Telefon,CihazModeli,Ariza From Tbl_Bursa where CihazDurumu=0  ", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            label5.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label11.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label13.Text = dt.ToLongDateString();
            label15.Text = dt.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int topTutar = Convert.ToInt32(textBox1.Text);
            int alinanTutar = Convert.ToInt32(textBox2.Text);
            int borc = topTutar - alinanTutar;
            

            SqlCommand komut2 = new SqlCommand("insert into Tbl_Kasa (ToplamTutar,AlinacakTutar,Kasa,Tarih) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",topTutar);
            komut2.Parameters.AddWithValue("@p2",borc);
            komut2.Parameters.AddWithValue("@p3",alinanTutar);
            komut2.Parameters.AddWithValue("@p4",label13.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();


            SqlCommand komut1 = new SqlCommand("Update Tbl_Bursa Set CihazDurumu=@a1 where id=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@a1",checkBox1.Checked);
            komut1.Parameters.AddWithValue("@p1", label1.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (label20.Text!="0")
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Borclular (Ad,Soyad,Telefon,BorcMiktari) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",label2.Text);
                komut.Parameters.AddWithValue("@p2",label5.Text);
                komut.Parameters.AddWithValue("@p3",label7.Text);
                komut.Parameters.AddWithValue("@p4",label20.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();


            }
            dataGridView1.DataSource = yenile();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int topTutar = Convert.ToInt32(textBox1.Text);
                int alinanTutar = Convert.ToInt32(textBox2.Text);
                int up = topTutar - alinanTutar;
                label20.Text = up.ToString();
            }
            catch
            {

            }
           
        }
    }
}
