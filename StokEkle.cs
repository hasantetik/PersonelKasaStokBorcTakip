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
    public partial class StokEkle : Form
    {
        public StokEkle()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void StokEkle_Load(object sender, EventArgs e)
        {

        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            StokEkleMetodu();
            this.Hide();


        }
       
        public void StokEkleMetodu()
        {
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Stok (BarkodNo,StokAdi,Ozelligi,Markasi,StokMiktari,BirimFiyat,RafYeri,AltSınır) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", textBox3.Text);
            komut1.Parameters.AddWithValue("@p4", textBox4.Text);
            komut1.Parameters.AddWithValue("@p5", textBox5.Text);
            komut1.Parameters.AddWithValue("@p6", textBox6.Text);
            komut1.Parameters.AddWithValue("@p7", textBox7.Text);
            komut1.Parameters.AddWithValue("@p8", textBox8.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StokEkleMetodu();
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StokEkleMetodu();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            Stok s = new Stok();
            s.Show();
        }
    }
}
