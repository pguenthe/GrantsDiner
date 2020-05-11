using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantsDiner.Models
{
    public class JoinedItem
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
