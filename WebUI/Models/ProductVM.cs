using System;
using System.Collections.Generic;
using Models;
using BL;


namespace WebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        { }

        public ProductVM(Product p_prod)
        {
            pID = p_prod.pID;
            pPrice = p_prod.pPrice;
            pName = p_prod.pName;
            pReleaseDate = p_prod.pReleaseDate;
            pReleaseDay = pReleaseDate.ToString("MM/dd/yyyy");
        }

        public int pID { get; set; }
        public decimal pPrice { get; set; }
        public string pName { get; set; }
        public DateTime pReleaseDate { get; set; }
        public List<InventoryVM> pInventory { get; set; }
        public string pReleaseDay { get; set; }
        public int pQuantity { get; set; }
    }
}