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
    public partial class Form2 : Form
    {
        koneksi koneksi;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            search_txt.Text = "Cari Data...  ";
            search_txt.ForeColor = Color.Gray;

            LoadData();
            // Tambahkan data ke ComboBox kondisi buku
            comboBoxKondisi.Items.Clear();
            comboBoxKondisi.Items.Add("Baik");
            comboBoxKondisi.Items.Add("Rusak");
            comboBoxKondisi.Items.Add("Hilang");
        }

        private void LoadData()
        {
            koneksi = new koneksi();

            DataSet ds = new DataSet();
            DataTable dt;

            koneksi.mulai();
            var con = koneksi.con;

            string sql = "select * from peminjaman";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            koneksi.berhenti();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.mulai();
            var con = koneksi.con;

            string namaPeminjam = textBoxNama.Text;
            string telepon = textBoxTelepon.Text;
            string judulBuku = textBoxJudul.Text;
            string kondisiBuku = comboBoxKondisi.Text;
            string denda = textBoxDenda.Text;
            string tanggalPinjam = dateTimePickerPinjam.Value.ToString("yyyy-MM-dd");
            string tanggalKembali = dateTimePickerKembali.Value.ToString("yyyy-MM-dd");
            string status = radioButton1.Checked ? "Belum dikembalikan" : "Sudah dikembalikan";


            string query = "INSERT INTO peminjaman (nama_pinjam, telepon, judul_buku, kondisi_buku, denda, tgl_pinjam, tgl_kembali, status) " +
                           "VALUES (@nama, @telepon, @judul, @kondisi, @denda, @tglPinjam, @tglKembali, @status)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nama", namaPeminjam);
            cmd.Parameters.AddWithValue("@telepon", telepon);
            cmd.Parameters.AddWithValue("@judul", judulBuku);
            cmd.Parameters.AddWithValue("@kondisi", kondisiBuku);
            cmd.Parameters.AddWithValue("@denda", denda);
            cmd.Parameters.AddWithValue("@tglPinjam", tanggalPinjam);
            cmd.Parameters.AddWithValue("@tglKembali", tanggalKembali);
            cmd.Parameters.AddWithValue("@status", status);


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
                LoadData(); // Refresh datagrid
                resetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            koneksi.berhenti();
        }

        private void resetForm()
        {
            textBoxNama.Clear();
            textBoxTelepon.Clear();
            textBoxJudul.Clear();
            comboBoxKondisi.SelectedIndex = -1;
            textBoxDenda.Clear();
            dateTimePickerPinjam.Value = DateTime.Now;
            dateTimePickerKembali.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                koneksi.mulai();
                var con = koneksi.con;
                // Ambil ID dari baris yang dipilih
                string id = dataGridView1.SelectedRows[0].Cells["id_pinjam"].Value.ToString();

                string namaPeminjam = textBoxNama.Text;
                string telepon = textBoxTelepon.Text;
                string judulBuku = textBoxJudul.Text;
                string kondisiBuku = comboBoxKondisi.Text;
                string denda = textBoxDenda.Text;
                string tanggalPinjam = dateTimePickerPinjam.Value.ToString("yyyy-MM-dd");
                string tanggalKembali = dateTimePickerKembali.Value.ToString("yyyy-MM-dd");
                string status = radioButton1.Checked ? "Belum dikembalikan" : "Sudah dikembalikan";


                string query = "UPDATE peminjaman SET nama_pinjam = @nama, telepon = @telepon, judul_buku = @judul, " +
                               "kondisi_buku = @kondisi, denda = @denda, tgl_kembali = @tglKembali, status = @status " +
                               "WHERE id_pinjam = @id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nama", namaPeminjam);
                cmd.Parameters.AddWithValue("@telepon", telepon);
                cmd.Parameters.AddWithValue("@judul", judulBuku);
                cmd.Parameters.AddWithValue("@kondisi", kondisiBuku);
                cmd.Parameters.AddWithValue("@denda", denda);
                cmd.Parameters.AddWithValue("@tglKembali", tanggalKembali);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate!");
                    LoadData();
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
                koneksi.berhenti();
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diubah terlebih dahulu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                koneksi.mulai();
                var con = koneksi.con;
                string id = dataGridView1.SelectedRows[0].Cells["id_pinjam"].Value.ToString();
                string query = "DELETE FROM peminjaman WHERE id_pinjam = @id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil dihapus!");
                        LoadData();
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
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = false;
            button4.Visible = true;

            // Isi textbox ketika user klik baris di datagrid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxNama.Text = row.Cells["nama_pinjam"].Value.ToString();
                textBoxTelepon.Text = row.Cells["telepon"].Value.ToString();
                textBoxJudul.Text = row.Cells["judul_buku"].Value.ToString();
                comboBoxKondisi.Text = row.Cells["kondisi_buku"].Value.ToString();
                textBoxDenda.Text = row.Cells["denda"].Value.ToString();
                dateTimePickerPinjam.Value = Convert.ToDateTime(row.Cells["tgl_pinjam"].Value);
                dateTimePickerKembali.Value = Convert.ToDateTime(row.Cells["tgl_kembali"].Value);

                string status = row.Cells["status"].Value.ToString();
                radioButton1.Checked = status == "Belum dikembalikan";
                radioButton2.Checked = status == "Sudah dikembalikan";

                // Nonaktifkan dateTimePickerPinjam saat mode edit
                dateTimePickerPinjam.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            resetForm();
            button3.Visible = true;
            // Aktifkan kembali dateTimePickerPinjam untuk input baru
            dateTimePickerPinjam.Enabled = true;
        }

        private void comboBoxKondisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKondisi.SelectedItem != null)
            {
                string kondisi = comboBoxKondisi.SelectedItem.ToString();

                if (kondisi == "Rusak")
                {
                    textBoxDenda.Text = "2000";
                }
                else if (kondisi == "Hilang")
                {
                    textBoxDenda.Text = "10000";
                }
                else // Asumsikan selain "Rusak" dan "Hilang" adalah "Baik"
                {
                    textBoxDenda.Text = "0";
                }
            }

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

        private void search_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_txt.Text) || search_txt.Text == "Cari Data...  ")
            {
                LoadData(); // tampilkan semua data
            }
            else
            {
                CariData(search_txt.Text); // filter berdasarkan input
            }
        }

        public void CariData(string keyword)
        {
            koneksi = new koneksi();

            DataSet ds = new DataSet();
            DataTable dt;

            koneksi.mulai();
            var con = koneksi.con;

            string sql = "SELECT * FROM peminjaman WHERE nama_pinjam LIKE @keyword OR judul_buku LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            koneksi.berhenti();
        }

        private void search_txt_Enter(object sender, EventArgs e)
        {
            if (search_txt.Text == "Cari Data...  ")
            {
                search_txt.Text = "";
                search_txt.ForeColor = Color.Black;
            }
        }

        private void search_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_txt.Text))
            {
                search_txt.Text = "Cari Data...  ";
                search_txt.ForeColor = Color.Gray;
            }
        }
    }
}