using System;
using System.Collections.Generic;
using Models;
using BL;


namespace WebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM()
        { }

        public LineItemVM(LineItem p_line)
        {
            liOrderID = p_line.liOrderID;
            liProductID = p_line.liProductID;
            liQuantity = p_line.liQuantity;
            liID = p_line.liID;
            liLinePrice = p_line.liLinePrice;
        }
        public int liOrderID { get; set; }
        public int liProductID { get; set; }
        public OrderVM liOrder { get; set; }
        public ProductVM liProduct { get; set; }
        public int liQuantity { get; set; }
        public int liID { get; set; }
        public decimal liLinePrice { get; set; }
        public string liProdName { get; set; }
    }
}