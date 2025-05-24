using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Controller
{
    internal class UserController
    {
        userQuery userQuery = new userQuery();

        public bool Login(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            return userQuery.AuthenticateUser(user);
        }
    }
}
