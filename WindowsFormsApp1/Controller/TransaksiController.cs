using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    public class TransaksiController
    {
        private TransaksiQuery transaksiQuery = new TransaksiQuery();

        public DataTable GetAll()
        {
            return transaksiQuery.GetAll();
        }

        public DataTable Search(string keyword)
        {
            return transaksiQuery.Search(keyword);
        }

        public bool Add(Transaksi transaksi)
        {
            return transaksiQuery.Insert(transaksi);
        }

        public bool Update(string id, Transaksi transaksi)
        {
            return transaksiQuery.Update(id, transaksi);
        }

        public bool Delete(string id)
        {
            return transaksiQuery.Delete(id);
        }
    }
}
