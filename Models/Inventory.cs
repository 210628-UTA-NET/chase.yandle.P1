using System;
using System.Collections.Generic;

namespace Models
{
    public class Inventory
    {
        public Store iStore { get; set; }
        public int iQuantity { get; set; }
        public Product iProduct { get; set; }
        public int iStoreID { get; set; }
        public int iProductID { get; set; }
    }
}
