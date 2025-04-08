using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace peminjamanBuku
{
    public partial class Form1 : Form
    {
        private string filePath = "peminjaman.csv";

        public Form1()
        {
            InitializeComponent();
            LoadPeminjaman();
        }

        private void LoadPeminjaman()
        {
            dgvPeminjaman.Rows.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 4)
                    {
                        dgvPeminjaman.Rows.Add(data);
                    }
                }
            }
        }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            string judulBuku = txtJudulBuku.Text;
            string tanggalPinjam = dtTanggalPinjam.Value.ToShortDateString();
            string tanggalKembali = dtTanggalKembali.Value.ToShortDateString();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(judulBuku))
            {
                MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string peminjamanData = $"{nama},{judulBuku},{tanggalPinjam},{tanggalKembali}";
            File.AppendAllText(filePath, peminjamanData + Environment.NewLine);

            MessageBox.Show("Peminjaman berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPeminjaman(); // Perbarui tampilan DataGridView
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPeminjaman.ColumnCount = 3;
            dgvPeminjaman.Columns[0].Name = "Nama Peminjam";
            dgvPeminjaman.Columns[1].Name = "Judul Buku";
            dgvPeminjaman.Columns[2].Name = "Tanggal Peminjaman";

            LoadPeminjaman();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
