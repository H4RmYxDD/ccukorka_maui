using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Listing
    {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public double SalePrice { get; set; }
    }
}
