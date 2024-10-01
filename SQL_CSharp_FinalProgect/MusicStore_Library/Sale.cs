using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library
{
    public class Sale
    {
        public void UpdateTotalSpent(int customerId, decimal amountSpent)
        {
            using (var context = new MusicDB())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                {
                    customer.TotalSpent += amountSpent;
                    context.SaveChanges();
                }
            }
        }

    }
}
