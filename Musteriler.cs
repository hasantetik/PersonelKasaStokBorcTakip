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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        SqlBaglanti bgl = new SqlBaglanti();
        string ad;
        string soyad;
       
        private void Musteriler_Load(object sender, EventArgs e)
        {
            
           
            

           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Musteriid,MusteriAd,MusteriSoyad,MusteriAriza,MusteriTelefon,MusteriEsya,MusteriTarih,MusteriSaat,CihazModeli From Tbl_Musteri where CihazTeslimDurumu=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

         

        }
        DataTable yenile()
        {
         
            SqlDataAdapter adtr = new SqlDataAdapter("Select Musteriid,MusteriAd,MusteriSoyad,MusteriAriza,MusteriTelefon,MusteriEsya,MusteriTarih,MusteriSaat,CihazModeli From Tbl_Musteri where CihazTeslimDurumu=0 ", bgl.baglanti());
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            bgl.baglanti().Close();
            return tablo;

        }
        
       
        int topKasa = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("Select Kasa From Tbl_Kasa  where Tarih=@p1", bgl.baglanti());

            komut4.Parameters.AddWithValue("@p1", LblTarih.Text);
            SqlDataReader dr4 = komut4.ExecuteReader();

            while (dr4.Read())
            {
                topKasa = topKasa + Convert.ToInt32(dr4[0]);
            }
            int netKasa = topKasa + Convert.ToInt32(TxtAlinanUcret.Text);

            bgl.baglanti().Close();


            int ToplamTutar = Convert.ToInt32(TxtToplamTutar.Text);
            int AlinanÜcret = Convert.ToInt32(TxtAlinanUcret.Text);
            int Alinacak = ToplamTutar - AlinanÜcret;

            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("insert into Tbl_Kasa (ToplamTutar,AlinacakTutar,Kasa,Tarih) values (@p1,@p2,@p3,@p4)   ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtToplamTutar.Text);
            komut.Parameters.AddWithValue("@p2", Alinacak);
            komut.Parameters.AddWithValue("@p3", TxtAlinanUcret.Text);
            komut.Parameters.AddWithValue("@p4", LblTarih.Text);
          
            

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            


            if (TxtAlinanUcret.Text == TxtToplamTutar.Text)
            {
                checkBox2.Checked = true;
            }



            



            if (TxtAlinanUcret.Text != TxtToplamTutar.Text)
            {
                
                SqlCommand komut2 = new SqlCommand("insert into Tbl_Borclular (Ad,Soyad,Telefon,BorcMiktari) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1",label11.Text);
                komut2.Parameters.AddWithValue("@p2",label12.Text);
                komut2.Parameters.AddWithValue("@p3",LblTlfn.Text);
                komut2.Parameters.AddWithValue("@p4",Alinacak);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            

                SqlCommand komut1 = new SqlCommand("Update Tbl_Musteri Set CihazTeslimDurumu=@a1,AlinanÜcret=@a2,Yapilanİslem=@a3,TeslimTarihi=@a4,TeslimSaat=@a5,UcretDurumu=@a6 where Musteriid=@p1", bgl.baglanti());

                komut1.Parameters.AddWithValue("@a1", checkBox1.Checked);
                komut1.Parameters.AddWithValue("@a2",TxtAlinanUcret.Text);
                komut1.Parameters.AddWithValue("@a3", richTextBox1.Text);
                komut1.Parameters.AddWithValue("@a4", LblTarih.Text);
                komut1.Parameters.AddWithValue("@a5", LblSaat.Text);
                komut1.Parameters.AddWithValue("@a6", checkBox2.Checked);
                komut1.Parameters.AddWithValue("@p1", textBox2.Text);
           
          
                komut1.ExecuteNonQuery();

            
            bgl.baglanti().Close();
            MessageBox.Show("Müsteri Kapatılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.DataSource= yenile();
            checkBox1.Checked = false;
        }
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
             
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = ad + " " + soyad;
            LblTlfn.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            LblEsyalar.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label11.Text = ad;
            label12.Text = soyad;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            LblTarih.Text = dt.ToLongDateString();
            LblSaat.Text = dt.ToLongTimeString();
        }

        private void label10_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
