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
using System.Runtime.Hosting;

namespace Silver_Computer
{
    public partial class YetkiliModülleri : Form
    {
        public YetkiliModülleri()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersonelKayıt pk = new PersonelKayıt();
            pk.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelList pl = new PersonelList();
            pl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler();
            m.Show();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();
        }
        public String kullaniciAdi;
        SqlBaglanti bgl = new SqlBaglanti();
        private void YetkiliModülleri_Load(object sender, EventArgs e)
        {
            label2.Text = kullaniciAdi;
            label2.Visible = false;
            SqlCommand komut = new SqlCommand("Select YetkiliAd,YetkiliSoyad From Tbl_Yetkili Where YetkiliKullaniciAdi=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Alacaklar a = new Alacaklar();
            a.Show();
        }

        private void hIZLIERİŞİMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mÜŞTERİEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();
        }

        private void sTOKEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokEkle se = new StokEkle();
            se.Show();
        }

        private void sTOKGİRİŞİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokGirişi sg = new StokGirişi();
            sg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stok s = new Stok();
            s.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OdenenBorclar ob = new OdenenBorclar();
            ob.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MusteriDurumlari md = new MusteriDurumlari();
            md.Show();
        }

        private void hESAPMAKİNESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            EkGiderler ek = new EkGiderler();
            ek.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kasa k = new Kasa();
            k.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AlinacakMallar a = new AlinacakMallar();
            a.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VeresiyeList v = new VeresiyeList();
            v.Show();
        }

        private void vERESİYEVERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Veresiyeler v = new Veresiyeler();
            v.Show();
        }

        private void vERESİYELİSTESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeresiyeList vl = new VeresiyeList();
            vl.Show();
        }

        private void hIZLIERİŞİMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void vERESİYEKAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeresiyeKapat vk = new VeresiyeKapat();
            vk.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BursaTakip bt = new BursaTakip();
            bt.Show();
        }

        private void cİHAZGÖNDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BursaGönder bt = new BursaGönder();
            bt.Show();
        }
    }
}
