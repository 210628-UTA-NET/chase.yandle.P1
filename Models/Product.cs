using System;
using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int pID { get; set; }
        public decimal pPrice { get; set; }
        public string pName { get; set; }
        public DateTime pReleaseDate { get; set; }
        public List<Inventory> pInventory { get; set; }
        public List<LineItem> pLineItems { get; set; }
    }
}
