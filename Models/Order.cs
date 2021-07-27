using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public List<LineItem> oLineItems { get; set; }

        public Customer oCustomer { get; set; }

        public Store oStore { get; set; }

        public decimal oPrice { get; set; }
        public int oID { get; set; }
        public DateTime oDateAndTime { get; set; }

        public int oCustomerID { get; set; }

        public int oStoreID { get; set; }
    }
}
