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
    public partial class PersonelModulleri : Form
    {
        public PersonelModulleri()
        {
            InitializeComponent();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler();
            m.Show();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        Personel p = new Personel();
        public String kullaniciAdi;
       
        
        private void PersonelModulleri_Load(object sender, EventArgs e)
        {
            label2.Text = kullaniciAdi;
            label2.Visible = false;
            SqlCommand komut = new SqlCommand("Select PersonelAd,PersonelSoyad From Tbl_Personel Where PersonelKullaniciAdi=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",label2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Alacaklar a = new Alacaklar();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdenenBorclar ob = new OdenenBorclar();
            ob.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MusteriDurumlari md = new MusteriDurumlari();
            md.Show();
        }

        private void eKLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StokEkle se = new StokEkle();
            se.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stok s = new Stok();
            s.Show();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void sTOKEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void çIKISToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hESAPMAKİNESİToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void sTOKEKLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StokEkle se = new StokEkle();
            se.Show();
        }

        private void mÜŞTERİEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();
        }

        private void sTOKGİRİŞİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokGirişi sg = new StokGirişi();
            sg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EkGiderler eg = new EkGiderler();
            eg.Show();
        }
    }
}
