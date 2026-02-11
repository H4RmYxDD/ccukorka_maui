using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Candy
    {
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
