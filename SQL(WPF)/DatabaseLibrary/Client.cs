﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        public int PersentSale { get; set; }
        public bool Subscribe { get; set; }
    }
}