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
    public partial class StokGirişi : Form
    {
        public StokGirişi()
        {
            InitializeComponent();
        }
        DataTable yenile()
        {

            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_Stok  ", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Stok Set StokMiktari=@a1 where StokNo=@p1", bgl.baglanti());

            int stokMiktari = Convert.ToInt32(label17.Text);
            int ekleMiktari = Convert.ToInt32(textBox1.Text);
            int net = stokMiktari + ekleMiktari;

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
            textBox1.Text = "";

            dataGridView1.DataSource = yenile();
        }

        private void StokGirişi_Load(object sender, EventArgs e)
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
    }
}
