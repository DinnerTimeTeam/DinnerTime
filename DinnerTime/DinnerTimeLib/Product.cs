using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerTimeLib
{
    public class Product
    {
        public int Id { get; set; }
        public string EAN { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public Measurement Measurement { get; set; }
        public decimal Quantity { get; set; }
    }
}
