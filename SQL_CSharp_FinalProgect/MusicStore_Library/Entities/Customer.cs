﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library.Entities
{
    public class Customer
    {
       
            public int Id { get; set; } 
            public string Username { get; set; } 
            public string Password { get; set; } 
            public string FirstName { get; set; } 
            public string LastName { get; set; }
            public decimal TotalSpent { get; set; }
            public ICollection<Reservation> Reservations { get; set; }

        

    }
}
