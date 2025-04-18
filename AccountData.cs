﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    internal class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username 
        { 
            get 
            { 
                return username; 
            } 
            set 
            { 
                username = value; 
            } 
        }
        public string Password 
        { 
            get 
            { 
                return password; 
            }
            set 
            { 
                password = value; 
            } 
        }

    }
}
