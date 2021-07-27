using System;
using System.Collections.Generic;
using System.Globalization;

namespace Models
{
    public class Customer
    {

        public string cName { get; set; }
        public string cStreet { get; set; }
        public string cCity { get; set; }
        public string cState { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public List<Order> cOrders { get; set; }
        public int cID { get; set; }
    }
}