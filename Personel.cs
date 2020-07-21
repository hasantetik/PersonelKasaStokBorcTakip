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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlBaglanti bgl = new SqlBaglanti();
        string kullaniciAdi;

        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciAdi = TxtKullaniciAdi.Text;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Personel Where PersonelKullaniciAdi=@p1 and Personelsifre=@p2 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                PersonelModulleri pm = new PersonelModulleri();
                pm.kullaniciAdi = TxtKullaniciAdi.Text;
                
                pm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı & Şifre ");
            }

            bgl.baglanti().Close();

          
        }

        private void Personel_Load(object sender, EventArgs e)
        {

        }
    }
}
