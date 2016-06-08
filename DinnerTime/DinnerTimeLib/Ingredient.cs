using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerTimeLib
{
    public class Ingredient
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Measurement Measurement { get; set; }
        public decimal Quantity { get; set; }
    }
}
