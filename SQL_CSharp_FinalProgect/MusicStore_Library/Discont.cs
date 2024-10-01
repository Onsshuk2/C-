using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library
{
    public class Discont
    {
        public void ApplyDiscountToGenre(int genreId, decimal discount)
        {
            using (var context = new MusicDB())
            {
                var records = context.Records.Where(r => r.GenreId == genreId);
                foreach (var record in records)
                {
                    record.Discount = discount;
                }
                context.SaveChanges();
            }
        }

    }
}
