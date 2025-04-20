using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    internal class LoginData
    {
        private string user;
        private string pass;
        private string zxc;

        public LoginData(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
        }

        public string Password
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }
        public string Username
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public string Ghoul
        {
            get
            {
                return zxc;
            }
            set
            {
                zxc = value;
            }
        }
    }
}

//string my info = LoginData.Password;
//print(...) -> asd
// LoginData.Password = "admin"
// LoginData.Password = "user"