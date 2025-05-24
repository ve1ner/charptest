using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string fName;
        private string lName;
        private string mName = "", 
                       nickname = "",
                       photo = "",
                       title = "",
                       company = "",
                       address = "",
                       tHome = "",
                       tMobile = "",
                       tWork = "",
                       fax = "",
                       email = "",
                       email2 = "",
                       email3 = "",
                       homepage = "",
                       birthday = "",
                       anniversary = "",
                       group = "";

        public ContactData(string fName, string lName)
        {
            this.fName = fName;
            this.lName = lName;
        }

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }
        public string MName
        {
            get
            { return mName; }
            set { mName = value; }
        }
        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string THome
        {
            get { return tHome; }
            set { tHome = value; }
        }
        public string TMobile
        {
            get { return tMobile; }
            set { tMobile = value; }
        }
        public string TWork
        {
            get { return tWork; }
            set { tWork = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }
        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Anniversary
        {
            get { return anniversary; }
            set { anniversary = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
