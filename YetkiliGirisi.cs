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
    public partial class YetkiliGirisi : Form
    {
        public YetkiliGirisi()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yetkili Where YetkiliKullaniciAdi=@p1 and YetkiliSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader rd = komut.ExecuteReader();

            if (rd.Read())
            {
                YetkiliModülleri ym = new YetkiliModülleri();
                ym.kullaniciAdi = TxtKullaniciAdi.Text;
                ym.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı & Şifre ");
            }
            bgl.baglanti().Close();

           
        }
    }
}
