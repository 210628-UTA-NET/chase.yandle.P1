using System;
using System.Collections.Generic;
using Models;
using BL;


namespace WebUI.Models
{
    public class StoreVM
    {
        public StoreVM()
        { }

        public StoreVM(Store p_store)
        {
            stStreet = p_store.stStreet;
            stCity = p_store.stCity;
            stState = p_store.stState;
            stPhone = p_store.stPhone;
            stEmail = p_store.stEmail;
            stID = p_store.stID;
        }
        public string stStreet { get; set; }
        public string stCity { get; set; }
        public string stState { get; set; }
        public string stPhone { get; set; }
        public string stEmail { get; set; }
        public int stID { get; set; }
        public List<InventoryVM> stInventory { get; set; }
        public List<OrderVM> stOrders { get; set; }
        public static Store stCurrent = new();
        public static Store stInventorySet = new();
    }
}