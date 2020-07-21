using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silver_Computer
{
    public partial class PersonelKayıt : Form
    {
        public PersonelKayıt()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PersonelAd,PersonelSoyad,Personelsifre,PersonelKullaniciAdi,PersonelTelefon) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtSifre.Text);
          //  komut.Parameters.AddWithValue("@p4", Email.Text);
            komut.Parameters.AddWithValue("@p4", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p5", MskTelefon.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Kaydı Gerçekleşmiştir  Kullanıcı Adı : " + TxtKullaniciAdi.Text + "  Şifreniz :" + TxtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
