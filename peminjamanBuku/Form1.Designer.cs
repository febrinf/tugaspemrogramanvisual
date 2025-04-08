namespace peminjamanBuku
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtJudulBuku = new System.Windows.Forms.TextBox();
            this.dtTanggalPinjam = new System.Windows.Forms.DateTimePicker();
            this.dtTanggalKembali = new System.Windows.Forms.DateTimePicker();
            this.btnPinjam = new System.Windows.Forms.Button();
            this.dgvPeminjaman = new System.Windows.Forms.DataGridView();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.judulBuku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggalPinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggalKembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aplikasi Peminjaman Buku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Peminjam";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Judul Buku";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tanggal Pinjam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tanggal Kembali";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(180, 67);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(230, 20);
            this.txtNama.TabIndex = 5;
            // 
            // txtJudulBuku
            // 
            this.txtJudulBuku.Location = new System.Drawing.Point(180, 111);
            this.txtJudulBuku.Name = "txtJudulBuku";
            this.txtJudulBuku.Size = new System.Drawing.Size(230, 20);
            this.txtJudulBuku.TabIndex = 6;
            // 
            // dtTanggalPinjam
            // 
            this.dtTanggalPinjam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTanggalPinjam.Location = new System.Drawing.Point(573, 67);
            this.dtTanggalPinjam.Name = "dtTanggalPinjam";
            this.dtTanggalPinjam.Size = new System.Drawing.Size(128, 20);
            this.dtTanggalPinjam.TabIndex = 7;
            // 
            // dtTanggalKembali
            // 
            this.dtTanggalKembali.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTanggalKembali.Location = new System.Drawing.Point(573, 108);
            this.dtTanggalKembali.Name = "dtTanggalKembali";
            this.dtTanggalKembali.Size = new System.Drawing.Size(128, 20);
            this.dtTanggalKembali.TabIndex = 8;
            // 
            // btnPinjam
            // 
            this.btnPinjam.Location = new System.Drawing.Point(365, 175);
            this.btnPinjam.Name = "btnPinjam";
            this.btnPinjam.Size = new System.Drawing.Size(75, 23);
            this.btnPinjam.TabIndex = 9;
            this.btnPinjam.Text = "Pinjam";
            this.btnPinjam.UseVisualStyleBackColor = true;
            this.btnPinjam.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvPeminjaman
            // 
            this.dgvPeminjaman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeminjaman.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nama,
            this.judulBuku,
            this.tanggalPinjam,
            this.tanggalKembali});
            this.dgvPeminjaman.Location = new System.Drawing.Point(180, 225);
            this.dgvPeminjaman.Name = "dgvPeminjaman";
            this.dgvPeminjaman.Size = new System.Drawing.Size(443, 213);
            this.dgvPeminjaman.TabIndex = 10;
            // 
            // nama
            // 
            this.nama.HeaderText = "Nama Peminjam";
            this.nama.Name = "nama";
            // 
            // judulBuku
            // 
            this.judulBuku.HeaderText = "Judul Buku";
            this.judulBuku.Name = "judulBuku";
            // 
            // tanggalPinjam
            // 
            this.tanggalPinjam.HeaderText = "Tanggal Pinjam";
            this.tanggalPinjam.Name = "tanggalPinjam";
            // 
            // tanggalKembali
            // 
            this.tanggalKembali.HeaderText = "Tanggal Kembali";
            this.tanggalKembali.Name = "tanggalKembali";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPeminjaman);
            this.Controls.Add(this.btnPinjam);
            this.Controls.Add(this.dtTanggalKembali);
            this.Controls.Add(this.dtTanggalPinjam);
            this.Controls.Add(this.txtJudulBuku);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeminjaman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtJudulBuku;
        private System.Windows.Forms.DateTimePicker dtTanggalPinjam;
        private System.Windows.Forms.DateTimePicker dtTanggalKembali;
        private System.Windows.Forms.Button btnPinjam;
        private System.Windows.Forms.DataGridView dgvPeminjaman;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn judulBuku;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalPinjam;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalKembali;
    }
}

