﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_C_Sharp
{
    internal class User
    {
       public int id { get; set; }
       public string login, email, pass;
        public string Login
        {
            get { return login; }
            set { login = value; }
        } 
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User(string login, string email, string pass) {
            this.login = login;
            this.email = email;
            this.pass = pass;
        }

        public override string ToString() {
            return "User: " + Login + ".Email: " + Email;
        }
    }
}
