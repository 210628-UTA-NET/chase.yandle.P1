using System;
using System.Collections.Generic;
using Models;
using BL;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string cName { get; set; }
        [Required]
        public string cStreet { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string cCity { get; set; }

        [RegularExpression(@"^[A-Z]+[A-Z]*$")]
        [Required]
        [StringLength(2,MinimumLength = 2)]
        public string cState { get; set; }
        [RegularExpression(@"^[0-9""'\s-]*$")]
        [Required]
        public string cPhone { get; set; }
        [Required]
        public string cEmail { get; set; }
        public List<OrderVM> cOrders { get; set; }
        public int cID { get; set; }
        public static CustomerVM cCurrent = new();
    }
}