using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class LoginData
    {
        private string user;
        private string pass;

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

    }
}
