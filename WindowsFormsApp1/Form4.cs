using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        koneksi koneksi;
        public Form4()
        {
            InitializeComponent();
        }

        private void LoadDataBuku()
        {
            koneksi = new koneksi();
            DataSet ds = new DataSet();
            DataTable dt;

            koneksi.mulai();
            var con = koneksi.con;

            string sql = "SELECT * FROM data_buku";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            koneksi.berhenti();
        }


        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 formTransaksi = new Form2();
            formTransaksi.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 formBuku = new Form4();
            formBuku.Show();
            this.Hide(); // Jika ingin menyembunyikan Form2
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi = new koneksi();

            koneksi.mulai();
            var con = koneksi.con;
            
            string judul = textBoxJudul.Text;
            string penulis = textBoxPenulis.Text;
            string penerbit = textBoxPenerbit.Text;
            string tahun = textBoxTahun.Text;
            string jumlah = textBoxJumlah.Text;
            string jenis = textBoxJenis.Text;

            string query = "INSERT INTO data_buku (judul, penulis, penerbit, tahun, jml_buku, jenis_buku) VALUES (@judul, @penulis, @penerbit, @tahun, @jumlah, @jenis)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@judul", judul);
            cmd.Parameters.AddWithValue("@penulis", penulis);
            cmd.Parameters.AddWithValue("@penerbit", penerbit);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            cmd.Parameters.AddWithValue("@jumlah", jumlah);
            cmd.Parameters.AddWithValue("@jenis", jenis);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                LoadDataBuku();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }

            koneksi.berhenti();
        }
        private void ResetForm()
        {
            
            textBoxJudul.Clear();
            textBoxPenulis.Clear();
            textBoxPenerbit.Clear();
            textBoxTahun.Clear();
            textBoxJumlah.Clear();
            textBoxJenis.Clear();

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                koneksi.mulai();
                var con = koneksi.con;

                string id_buku = dataGridView1.SelectedRows[0].Cells["id_buku"].Value.ToString();
                string query = "UPDATE data_buku SET judul = @judul, penulis = @penulis, penerbit = @penerbit, tahun = @tahun, jml_buku = @jumlah, jenis_buku = @jenis WHERE id_buku = @id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id_buku);
                cmd.Parameters.AddWithValue("@judul", textBoxJudul.Text);
                cmd.Parameters.AddWithValue("@penulis", textBoxPenulis.Text);
                cmd.Parameters.AddWithValue("@penerbit", textBoxPenerbit.Text);
                cmd.Parameters.AddWithValue("@tahun", textBoxTahun.Text);
                cmd.Parameters.AddWithValue("@jumlah", textBoxJumlah.Text);
                cmd.Parameters.AddWithValue("@jenis", textBoxJenis.Text);


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate!");
                    LoadDataBuku();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }

                koneksi.berhenti();
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diupdate!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                koneksi.mulai();
                var con = koneksi.con;

                string id_buku = dataGridView1.SelectedRows[0].Cells["id_buku"].Value.ToString();
                string query = "DELETE FROM data_buku WHERE id_buku = @kode";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@kode", id_buku);

                var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil dihapus!");
                        LoadDataBuku();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                    }
                }

                koneksi.berhenti();
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadDataBuku();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                //id_buku = row.Cells["kode_buku"].Value.ToString();
                textBoxJudul.Text = row.Cells["judul"].Value.ToString();
                textBoxPenulis.Text = row.Cells["penulis"].Value.ToString();
                textBoxPenerbit.Text = row.Cells["penerbit"].Value.ToString();
                textBoxTahun.Text = row.Cells["tahun"].Value.ToString();
                textBoxJumlah.Text = row.Cells["jml_buku"].Value.ToString();
                textBoxJenis.Text = row.Cells["jenis_buku"].Value.ToString();


            }
        }
    }
}
