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
    public class TransaksiQuery
    {
        private koneksi koneksi;

        public TransaksiQuery()
        {
            koneksi = new koneksi();
        }

        public DataTable GetAll()
        {
            koneksi.mulai();
            var con = koneksi.con;
            string sql = "SELECT * FROM peminjaman";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            koneksi.berhenti();
            return dt;
        }

        public DataTable Search(string keyword)
        {
            koneksi.mulai();
            var con = koneksi.con;
            string sql = "SELECT * FROM peminjaman WHERE nama_pinjam LIKE @keyword OR judul_buku LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            koneksi.berhenti();
            return dt;
        }

        public bool Insert(Transaksi t)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "INSERT INTO peminjaman (nama_pinjam, telepon, judul_buku, kondisi_buku, denda, tgl_pinjam, tgl_kembali, status) " +
                               "VALUES (@nama, @telepon, @judul, @kondisi, @denda, @tglPinjam, @tglKembali, @status)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nama", t.NamaPeminjam);
                cmd.Parameters.AddWithValue("@telepon", t.Telepon);
                cmd.Parameters.AddWithValue("@judul", t.JudulBuku);
                cmd.Parameters.AddWithValue("@kondisi", t.KondisiBuku);
                cmd.Parameters.AddWithValue("@denda", t.Denda);
                cmd.Parameters.AddWithValue("@tglPinjam", t.TanggalPinjam);
                cmd.Parameters.AddWithValue("@tglKembali", t.TanggalKembali);
                cmd.Parameters.AddWithValue("@status", t.Status);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { koneksi.berhenti(); }
        }

        public bool Update(string id, Transaksi t)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "UPDATE peminjaman SET nama_pinjam = @nama, telepon = @telepon, judul_buku = @judul, " +
                               "kondisi_buku = @kondisi, denda = @denda, tgl_kembali = @tglKembali, status = @status WHERE id_pinjam = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nama", t.NamaPeminjam);
                cmd.Parameters.AddWithValue("@telepon", t.Telepon);
                cmd.Parameters.AddWithValue("@judul", t.JudulBuku);
                cmd.Parameters.AddWithValue("@kondisi", t.KondisiBuku);
                cmd.Parameters.AddWithValue("@denda", t.Denda);
                cmd.Parameters.AddWithValue("@tglKembali", t.TanggalKembali);
                cmd.Parameters.AddWithValue("@status", t.Status);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { koneksi.berhenti(); }
        }

        public bool Delete(string id)
        {
            try
            {
                koneksi.mulai();
                var con = koneksi.con;
                string query = "DELETE FROM peminjaman WHERE id_pinjam = @id";
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
