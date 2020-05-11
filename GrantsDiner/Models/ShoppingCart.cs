using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantsDiner.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}
