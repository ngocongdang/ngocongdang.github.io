using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_Final.Class
{
    public class Customers
    {
        private string username;
        private string password;
        private string fullname;
        private string email;
        private string phone;
        private string address;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Adress
        {
             get { return address; }
             set { address = value; }
        }
        public Customers(DataRow row)
        {
            username = row["Id"].ToString();
            password = row["Password"].ToString();
            fullname = row["Fullname"].ToString();
            email = row["Email"].ToString();
            phone = row["cusPhone"].ToString();
            address = row["address_c"].ToString();
        }
    }
}