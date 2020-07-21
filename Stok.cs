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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void Stok_Load(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Stok ", bgl.baglanti());          
            da.Fill(dt);         
            dataGridView1.DataSource = dt;
            


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label11.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            label12.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            label13.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            label14.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label15.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            label16.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label17.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label18.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

        }
        DataTable yenile()
        {

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_Stok  ", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int miktar = Convert.ToInt32(textBox9.Text);
                int birimFiyat = Convert.ToInt32(label16.Text);
                int topFiyat = miktar * birimFiyat;
                label19.Text = topFiyat.ToString()+" TL" ;
            }
            catch
            {

            }
          
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Kasa (ToplamTutar,Kasa,Tarih) values (@p1,@p2,@p3)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",textBox9.Text);
            komut2.Parameters.AddWithValue("@p2",textBox9.Text);
            komut2.Parameters.AddWithValue("@p3",label21.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();

           /* SqlCommand komut4 = new SqlCommand("insert into Tbl_Kasa (Kasa,Tarih) values (@p1,@p2)", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", textBox1.Text);
            komut4.Parameters.AddWithValue("@p2", label9.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();

            */
            SqlCommand komut1 = new SqlCommand("Update Tbl_Stok Set StokMiktari=@a1 where StokNo=@p1", bgl.baglanti());

            int stokMiktari= Convert.ToInt32(label17.Text);
            int satişMiktari = Convert.ToInt32(textBox9.Text);
            int net = stokMiktari - satişMiktari;

            komut1.Parameters.AddWithValue("@a1", net);
            komut1.Parameters.AddWithValue("@p1", label11.Text);
            

            komut1.ExecuteNonQuery();
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            textBox9.Text = "";

            dataGridView1.DataSource = yenile();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label21.Text = dt.ToLongDateString();
            label23.Text = dt.ToLongTimeString();
        }
    }
}
