using MusicStore_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library
{
    
    public class Search
    {
        public List<Record> SearchRecordsByTitle(string title)
        {
            using (var context = new MusicDB())
            {
                return context.Records
                              .Where(r => r.NameRecord.Contains(title))
                              .ToList();
            }
        }

        public List<Record> SearchRecordsByArtist(string artistName)
        {
            using (var context = new MusicDB())
            {
                return context.Records
                              .Where(r => r.Artist.FirstName.Contains(artistName) || r.Artist.LastName.Contains(artistName))
                              .ToList();
            }
        }

        public List<Record> SearchRecordsByGenre(string genreName)
        {
            using (var context = new MusicDB())
            {
                return context.Records
                              .Where(r => r.Genre.Name == genreName)
                              .ToList();
            }
        }
    }
}
