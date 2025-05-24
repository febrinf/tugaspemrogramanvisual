using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public class BukuQuery
    {
        private koneksi koneksi;

        public BukuQuery()
        {
            koneksi = new koneksi();
        }

        public DataTable GetAll()
        {
            koneksi.mulai();
            var con = koneksi.con;
            string sql = "SELECT * FROM data_buku";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            koneksi.berhenti();
            return dt;
        }

        public bool Insert(Buku buku)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "INSERT INTO data_buku (judul, penulis, penerbit, tahun, jml_buku, jenis_buku) VALUES (@judul, @penulis, @penerbit, @tahun, @jumlah, @jenis)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@judul", buku.Judul);
                cmd.Parameters.AddWithValue("@penulis", buku.Penulis);
                cmd.Parameters.AddWithValue("@penerbit", buku.Penerbit);
                cmd.Parameters.AddWithValue("@tahun", buku.Tahun);
                cmd.Parameters.AddWithValue("@jumlah", buku.Jumlah);
                cmd.Parameters.AddWithValue("@jenis", buku.Jenis);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                koneksi.berhenti();
            }
        }

        public bool Update(string id, Buku buku)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "UPDATE data_buku SET judul = @judul, penulis = @penulis, penerbit = @penerbit, tahun = @tahun, jml_buku = @jumlah, jenis_buku = @jenis WHERE id_buku = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@judul", buku.Judul);
                cmd.Parameters.AddWithValue("@penulis", buku.Penulis);
                cmd.Parameters.AddWithValue("@penerbit", buku.Penerbit);
                cmd.Parameters.AddWithValue("@tahun", buku.Tahun);
                cmd.Parameters.AddWithValue("@jumlah", buku.Jumlah);
                cmd.Parameters.AddWithValue("@jenis", buku.Jenis);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                koneksi.berhenti();
            }
        }

        public bool Delete(string id)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "DELETE FROM data_buku WHERE id_buku = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                koneksi.berhenti();
            }
        }
    }
}
