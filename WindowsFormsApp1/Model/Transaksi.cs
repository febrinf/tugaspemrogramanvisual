using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Transaksi
    {
        public string Id { get; set; }
        public string NamaPeminjam { get; set; }
        public string Telepon { get; set; }
        public string JudulBuku { get; set; }
        public string KondisiBuku { get; set; }
        public string Denda { get; set; }
        public string TanggalPinjam { get; set; }
        public string TanggalKembali { get; set; }
        public string Status { get; set; }
    }
}
