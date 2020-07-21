using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Silver_Computer
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            BaglantiSinif bg = new BaglantiSinif();
            SqlConnection baglan = new SqlConnection(bg.Adres);
            baglan.Open();
            return baglan;
        }


    }
}
