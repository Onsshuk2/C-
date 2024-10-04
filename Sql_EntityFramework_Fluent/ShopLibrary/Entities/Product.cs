﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public Categori Categori { get; set; }

        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public bool IslnStock { get; set; }

        public ICollection<Shop>Shops { get; set; }

    }
}
