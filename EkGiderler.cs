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
    public partial class EkGiderler : Form
    {
        public EkGiderler()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label3.Text = dt.ToLongDateString();
            label4.Text = dt.ToLongTimeString();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = 0 - a;
            SqlCommand komut = new SqlCommand("insert into Tbl_Gider (GiderAciklama,Gider,Tarih) values (@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",richTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.Parameters.AddWithValue("@p3", label3.Text);
            MessageBox.Show("Gider Eklendi");
            komut.ExecuteNonQuery();
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Kasa (Kasa,Tarih) values (@p1,@p2)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", b);
            komut1.Parameters.AddWithValue("@p2", label3.Text);
            komut1.ExecuteNonQuery();
            richTextBox1.Text = "";
            textBox1.Text = "";
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = 0 - a;
            SqlCommand komut = new SqlCommand("insert into Tbl_Gider (GiderAcıklama,Gider,Tarih) values (@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.Parameters.AddWithValue("@p3", label3.Text);
            komut.ExecuteNonQuery();
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Kasa (Kasa,Tarih) values (@p1,@p2)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", b);
            komut1.Parameters.AddWithValue("@p2", label3.Text);

            komut1.ExecuteNonQuery();
            MessageBox.Show("Gider Eklendi");
            this.Hide();
        }

        private void EkGiderler_Load(object sender, EventArgs e)
        {

        }
    }
}
