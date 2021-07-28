using System;
using System.Collections.Generic;
using Models;
using BL;
using Microsoft.AspNetCore.Http;

namespace WebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        { }

        public CustomerVM(Customer p_cust)
        {
            cID = p_cust.cID;
            cName = p_cust.cName;
            cStreet = p_cust.cStreet;
            cCity = p_cust.cCity;
            cState = p_cust.cState;
            cPhone = p_cust.cPhone;
            cEmail = p_cust.cEmail;
        }

        public string cName { get; set; }
        public string cStreet { get; set; }
        public string cCity { get; set; }
        public string cState { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public List<OrderVM> cOrders { get; set; }
        public int cID { get; set; }
        public static CustomerVM cCurrent = new();
    }
}