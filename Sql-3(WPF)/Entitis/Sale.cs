using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_3_WPF_.Entitis
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
    }
}
