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
    public partial class MusteriDurumlari : Form
    {
        public MusteriDurumlari()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        private void MusteriDurumlari_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Musteriid,MusteriAd,MusteriSoyad,MusteriAriza,MusteriTelefon,MusteriEsya,MusteriTarih,MusteriSaat,CihazModeli,AlinanÜcret,UcretDurumu,Yapilanİslem,TeslimTarihi,TeslimSaat From Tbl_Musteri where CihazTeslimDurumu=1 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
