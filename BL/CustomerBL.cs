using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustRepository _repo;
        public CustomerBL(ICustRepository p_repo)
        {
            _repo=p_repo;
        }
        public Customer AddCustomer(Customer p_cust)
        {
            return _repo.AddCustomer(p_cust);
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public List<Customer> GetCustomerByName(string p_name)
        {
            return _repo.GetCustomerByName(p_name);
        }
        public Customer GetCustomer(int p_ID)
        {
            return _repo.GetCustomer(p_ID);
        }
    }
}