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
    public partial class Veresiyeler : Form
    {
        public Veresiyeler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void Veresiyeler_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Stok  ", bgl.baglanti());
            da.Fill(dt);        
            dataGridView1.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label21.Text = dt.ToLongDateString();
            label22.Text = dt.ToLongTimeString();
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label19.Text = (Convert.ToInt32(label16.Text) * Convert.ToInt32(textBox2.Text)).ToString();
            }
            catch
            {

            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int stok = Convert.ToInt32(label17.Text);
            int adet = Convert.ToInt32(textBox2.Text);
            int up = stok - adet;

            SqlCommand komut = new SqlCommand("insert into Tbl_Veresiye (ad,soyad,malzeme,adet,tutar,telefon,tarih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7) ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",textBox9.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.Parameters.AddWithValue("@p3",label13.Text);
            komut.Parameters.AddWithValue("@p4",textBox2.Text);
            komut.Parameters.AddWithValue("@p5",label19.Text);
            komut.Parameters.AddWithValue("@p6",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p7",label21.Text);
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            SqlCommand komut1 = new SqlCommand("Update Tbl_Stok Set StokMiktari=@a1 where StokNo=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@a1",up);
            komut1.Parameters.AddWithValue("@p1",label11.Text);
            komut1.ExecuteNonQuery();

            bgl.baglanti().Close();

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
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";

            dataGridView1.DataSource = yenile();

        }
    }
}
