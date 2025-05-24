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
    public partial class Form4 : Form
    {
        BukuController bukuController = new BukuController();
        private string selectedId = "";

        public Form4()
        {
            InitializeComponent();
            LoadDataBuku();
        }

        private void LoadDataBuku()
        {
            dataGridView1.DataSource = bukuController.GetAll();
            ResetForm();
        }

        private Buku GetBukuFromForm()
        {
            return new Buku
            {
                Judul = textBoxJudul.Text,
                Penulis = textBoxPenulis.Text,
                Penerbit = textBoxPenerbit.Text,
                Tahun = textBoxTahun.Text,
                Jumlah = textBoxJumlah.Text,
                Jenis = textBoxJenis.Text
            };
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
            var buku = GetBukuFromForm();
            bool success = bukuController.Tambah(buku);
            if (success)
            {
                MessageBox.Show("Data berhasil disimpan!");
                LoadDataBuku();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data.");
            }

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
            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Pilih data yang ingin diupdate!");
                return;
            }

            var buku = GetBukuFromForm();
            bool success = bukuController.Edit(selectedId, buku);
            if (success)
            {
                MessageBox.Show("Data berhasil diupdate!");
                LoadDataBuku();
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
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool success = bukuController.Delete(selectedId);
                if (success)
                {
                    MessageBox.Show("Data berhasil dihapus!");
                    LoadDataBuku();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data.");
                }
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
                selectedId = row.Cells["id_buku"].Value.ToString();
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
