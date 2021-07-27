using System;
using System.Collections.Generic;

namespace Models
{
    public class LineItem
    {
        public Order liOrder { get; set; }
        public Product liProduct { get; set; }
        public int liQuantity { get; set; }
        public int liID { get; set; }
        public decimal liLinePrice { get; set; }

        public int liOrderID { get; set; }
        public int liProductID { get; set; }
    }
}
