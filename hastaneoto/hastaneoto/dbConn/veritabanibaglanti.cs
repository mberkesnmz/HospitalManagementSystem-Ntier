using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;


namespace hastaneoto.dbConn
{
    public class veritabanibaglanti
    {

        public SqlDataAdapter dataAdapter;
        public SqlConnection baglanti;
        public SqlCommand komut;

        public veritabanibaglanti() // DB Bağlantı
        {
            dataAdapter = new SqlDataAdapter();
            baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\dbHastane.mdf;Integrated Security=True;User Instance=True");
            //baglanti = new SqlConnection(@"Data Source=DESKTOP-019C24Q\SQLEXPRESS;Initial Catalog=hastane;Integrated Security=True");
        }
    }
}
