using MusicStore_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicStore_Library.Entities.Customer;

namespace MusicStore_Library
{
    public class Reservations
    {
        public void ReserveRecordForCustomer(int recordId, int customerId)
        {
            using (var context = new MusicDB())
            {
                var reservation = new Reservation
                {
                    RecordId = recordId,
                    CustomerId = customerId,
                    ReservationDate = DateTime.Now
                };
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }


    }

}
