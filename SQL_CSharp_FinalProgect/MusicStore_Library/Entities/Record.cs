using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string NameRecord { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; } 
        public decimal Discount { get; set; }
        public int GenreId { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
