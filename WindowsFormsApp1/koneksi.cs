using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class koneksi
    {
        string cs = "server=localhost;username=root;password=;database=peminjamanbuku";
        public MySqlConnection con;

        public void mulai()
        {
            con = new MySqlConnection(cs);
            con.Open();
        }

        public void berhenti()
        {
            con = new MySqlConnection(cs);
            con.Close();
        }
    }
}
