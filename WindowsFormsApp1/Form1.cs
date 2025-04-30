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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        koneksi con;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con = new koneksi();
            try
            {
                con.mulai();
                var kon = con.con;
                string stm = "SELECT username, password FROM user WHERE username = @Username AND password = @Password";
                using (var cmd = new MySqlCommand(stm, kon))
                {
                    cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", tbPassword.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Login berhasil!");

                            // Ini MEMANG pakai Form2 kamu yang sudah ada
                            Form2 f2 = new Form2();
                            f2.Show();
                            this.Hide(); // Hide Form1
                        }
                        else
                        {
                            MessageBox.Show("Login gagal: username atau password salah");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat login: " + ex.Message);
            }
            con.berhenti();
        }
    }
    }

