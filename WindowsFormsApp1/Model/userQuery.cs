using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public class userQuery
    {
        private readonly koneksi con = new koneksi();

        public bool AuthenticateUser(User user)
        {
            con.mulai();
            string sql = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
            MySqlCommand cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.berhenti();

            return count > 0;
        }
    }
}
