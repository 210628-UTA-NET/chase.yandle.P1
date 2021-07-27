using System;
using System.Collections.Generic;
using Models;
using BL;


namespace WebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM()
        { }

        public InventoryVM(Inventory p_inven)
        {
            iStore = new StoreVM(p_inven.iStore);
            iQuantity = p_inven.iQuantity;
            iProduct = new ProductVM(p_inven.iProduct);
            iStoreID = p_inven.iStoreID;
            iProductID = p_inven.iProductID;
        }

        public StoreVM iStore { get; set; }
        public int iQuantity { get; set; }
        public ProductVM iProduct { get; set; }
        public int iStoreID { get; set; }
        public int iProductID { get; set; }
    }
}