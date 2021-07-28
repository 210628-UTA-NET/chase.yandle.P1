using System;
using System.Collections.Generic;
using Models;
using BL;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        { }

        public OrderVM(Order p_ord)
        {
            oCustomerID = p_ord.oCustomerID;
            oStoreID = p_ord.oStoreID;
            oPrice = p_ord.oPrice;
            oID = p_ord.oID;
            oDateAndTime = p_ord.oDateAndTime;
        }

        public List<LineItemVM> oLineItems { get; set; }
        [Required]

        public int oCustomerID { get; set; }
        [Required]
        public int oStoreID { get; set; }

        public CustomerVM oCustomer { get; set; }

        public StoreVM oStore { get; set; }
        [Required]
        public decimal oPrice { get; set; }
        public int oID { get; set; }
        [Required]
        public DateTime oDateAndTime { get; set; }
        [Required]
        public string oCustName { get; set; }
        [Required]
        public string oStoreStreet { get; set; }

        public static OrderVM currentOrder = new();
        public static List<LineItemVM> currentLines = new();
        public static ProductVM currentProduct = new();
        public static int currentCustomer = new();
        public static int currentStore = new();
        public static OrderVM orderHistory = new();
    }
}