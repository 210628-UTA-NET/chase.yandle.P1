using System;
using System.Collections.Generic;
using Models;
using BL;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string stStreet { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string stCity { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(2, MinimumLength = 2)]
        [Required]
        public string stState { get; set; }
        [RegularExpression(@"^[0-9""'\s-]*$")]
        [Required]
        public string stPhone { get; set; }
        [Required]
        public string stEmail { get; set; }
        public int stID { get; set; }
        public List<InventoryVM> stInventory { get; set; }
        public List<OrderVM> stOrders { get; set; }
        public static Store stCurrent = new();
        public static Store stInventorySet = new();
    }
}