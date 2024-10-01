using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicStore_Library.Entities.Customer;

namespace MusicStore_Library.Entities
{
    public class Reservation
    {
        public int Id { get; set; } 
        public int RecordId { get; set; } 
        public int CustomerId { get; set; } 
        public DateTime ReservationDate { get; set; }
        public Record Record { get; set; }
        public Customer Customer { get; set; }
       
    }
}
