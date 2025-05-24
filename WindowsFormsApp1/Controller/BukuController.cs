using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    public class BukuController
    {
        private BukuQuery query = new BukuQuery();

        public DataTable GetAll()
        {
            return query.GetAll();
        }

        public bool Tambah(Buku buku)
        {
            return query.Insert(buku);
        }

        public bool Edit(string id, Buku buku)
        {
            return query.Update(id, buku);
        }

        public bool Delete(string id)
        {
            return query.Delete(id);
        }
    }
}
