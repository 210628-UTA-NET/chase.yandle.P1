using System;
using System.Collections.Generic;

namespace Models
{
    public class Store
    {
        public string stStreet { get; set; }
        public string stCity { get; set; }
        public string stState { get; set; }
        public string stPhone { get; set; }
        public string stEmail { get; set; }
        public int stID { get; set; }
        public List<Inventory> stInventory { get; set; }
        public List<Order> stOrders { get; set; }
    }
}
