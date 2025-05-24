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
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        TransaksiController transaksiController = new TransaksiController();
        private string selectedId = "";

        public Form2()
        {
            InitializeComponent();
            LoadData();
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

            dateTimePickerPinjam.Enabled = false;
            dateTimePickerPinjam.Value = DateTime.Now;
            dateTimePickerKembali.Enabled = false;
            dateTimePickerKembali.Value = DateTime.Now;
        }

        private void LoadData()
        {
            dataGridView1.DataSource = transaksiController.GetAll();
            resetForm();
        }

        private Transaksi GetTransaksiFromForm()
        {
            return new Transaksi
            {
                NamaPeminjam = textBoxNama.Text,
                Telepon = textBoxTelepon.Text,
                JudulBuku = textBoxJudul.Text,
                KondisiBuku = comboBoxKondisi.Text,
                Denda = textBoxDenda.Text,
                TanggalPinjam = dateTimePickerPinjam.Value.ToString("yyyy-MM-dd"),
                TanggalKembali = dateTimePickerKembali.Value.ToString("yyyy-MM-dd"),
                Status = radioButton1.Checked ? "Belum dikembalikan" : "Sudah dikembalikan"
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transaksi t = GetTransaksiFromForm();
            bool success = transaksiController.Add(t);
            if (success)
            {
                MessageBox.Show("Data berhasil ditambahkan!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal menambahkan data.");
            }
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
            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            Transaksi t = GetTransaksiFromForm();
            bool success = transaksiController.Update(selectedId, t);
            if (success)
            {
                MessageBox.Show("Data berhasil diupdate!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal mengupdate data.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool success = transaksiController.Delete(selectedId);
                if (success)
                {
                    MessageBox.Show("Data berhasil dihapus!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data.");
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    selectedId = row.Cells["id_pinjam"].Value.ToString();
                    textBoxNama.Text = row.Cells["nama_pinjam"].Value.ToString();
                    textBoxTelepon.Text = row.Cells["telepon"].Value.ToString();
                    textBoxJudul.Text = row.Cells["judul_buku"].Value.ToString();
                    comboBoxKondisi.Text = row.Cells["kondisi_buku"].Value.ToString();
                    textBoxDenda.Text = row.Cells["denda"].Value.ToString();
                    dateTimePickerPinjam.Value = DateTime.Parse(row.Cells["tgl_pinjam"].Value.ToString());
                    dateTimePickerKembali.Value = DateTime.Parse(row.Cells["tgl_kembali"].Value.ToString());
                    string status = row.Cells["status"].Value.ToString();
                    radioButton1.Checked = status == "Belum dikembalikan";
                    radioButton2.Checked = status == "Sudah dikembalikan";
                }
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan saat memilih data.");
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
            dataGridView1.DataSource = transaksiController.Search(keyword);

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

        private DateTime CariTanggalKembaliValid(DateTime tglAwal, int durasiHari)
        {
            DateTime tglKembali = tglAwal.AddDays(durasiHari);

            // Jika Sabtu (6) atau Minggu (0), tambahkan satu hari hingga hari kerja
            while (tglKembali.DayOfWeek == DayOfWeek.Saturday || tglKembali.DayOfWeek == DayOfWeek.Sunday)
            {
                tglKembali = tglKembali.AddDays(1);
            }

            return tglKembali;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime tglPinjam = DateTime.Now;
            dateTimePickerPinjam.Value = tglPinjam;

            DateTime tglKembali = CariTanggalKembaliValid(tglPinjam, 3);
            dateTimePickerKembali.Value = tglKembali;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime tglPinjam = DateTime.Now;
            dateTimePickerPinjam.Value = tglPinjam;

            DateTime tglKembali = CariTanggalKembaliValid(tglPinjam, 7);
            dateTimePickerKembali.Value = tglKembali;
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
    }
}