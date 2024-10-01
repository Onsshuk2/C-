using MusicStore_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library
{
    public class Revision
    {
        public List<Record> GetNewReleases()
        {
            using (var context = new MusicDB())
            {
                return context.Records
                              .OrderByDescending(r => r.Year)
                              .Take(10)
                              .ToList();
            }
        }

    }
}
