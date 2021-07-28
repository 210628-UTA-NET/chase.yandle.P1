using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface ICustomerBL
    {
        public Customer AddCustomer(Customer p_cust);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetCustomerByName(string p_name);
        public Customer GetCustomer(int p_ID);
    }
}