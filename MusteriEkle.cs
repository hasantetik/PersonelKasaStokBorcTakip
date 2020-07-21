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
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("insert into Tbl_Musteri (MusteriAriza,MusteriAd,MusteriSoyad,MusteriTelefon,MusteriEsya,MusteriTarih,MusteriSaat,CihazModeli) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", RchAriza.Text);
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut.Parameters.AddWithValue("@p3", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", RchEsyalar.Text);
            komut.Parameters.AddWithValue("@p6",label8.Text);
            komut.Parameters.AddWithValue("@p7",label9.Text);
            komut.Parameters.AddWithValue("@p8",TxtModel.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müsteri Kaydı Gerçekleşmiştir. İsim : "+TxtAd.Text+" "+TxtSoyad.Text );

            this.Hide();
        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label8.Text = dt.ToLongDateString();
            label9.Text = dt.ToLongTimeString();
        }
    }
}
