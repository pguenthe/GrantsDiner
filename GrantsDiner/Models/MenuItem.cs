using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantsDiner.Models
{
    public class MenuItem
    {
        //	CREATE TABLE MenuItems(
        //	ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
        //	Name varchar(45) NOT NULL,
        //   Category varchar(25) NOT NULL,
        //  Description varchar(255) NOT NULL,
        // Price money NOT NULL
        //  );

        //TODO: add data annotations for max length etc
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
