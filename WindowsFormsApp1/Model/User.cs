using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class User
    {
        public int Id { get; set; }              // Jika di database ada kolom id
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
