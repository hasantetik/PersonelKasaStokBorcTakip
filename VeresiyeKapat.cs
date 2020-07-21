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
    public partial class VeresiyeKapat : Form
    {
        public VeresiyeKapat()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        private void VeresiyeKapat_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Veresiye where tutar!=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        DataTable yenile()
        {

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_Veresiye where tutar!=0  ", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tutar = Convert.ToInt32(label16.Text);
                int ötutar = Convert.ToInt32(textBox1.Text);
                int net = tutar - ötutar;
                textBox2.Text = net.ToString();
            }
            catch
            {

            }
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            label17.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            label12.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            label11.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            label10.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label16.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label15.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label14.Text = dt.ToLongDateString();
            label13.Text = dt.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Veresiye Set tutar=@a1 where id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1",textBox2.Text);
            komut.Parameters.AddWithValue("@p1",label17.Text);
            komut.ExecuteNonQuery();
            label11.Text = "";
            label12.Text = "";
            label9.Text = "";
            label10.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
        
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = yenile();
        }
    }
}
