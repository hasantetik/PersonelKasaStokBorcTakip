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
    public partial class BursaGönder : Form
    {
        public BursaGönder()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        private void BursaTakip_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Bursa (Ad,Soyad,Telefon,CihazModeli,Ariza) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",MskTelefon.Text);
            komut.Parameters.AddWithValue("@p4",TxtModel.Text);
            komut.Parameters.AddWithValue("@p5",richTextBox1.Text);
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            this.Hide();

        }

        private void TxtModel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
