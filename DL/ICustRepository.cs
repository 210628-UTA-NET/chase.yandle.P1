using System.Collections.Generic;
using Models;
using System.Linq;

namespace DL
{
    public interface ICustRepository
    {
        public void AddCustomer(Customer p_cust);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetCustomerByName(string p_string);
        public Customer GetCustomer(int p_ID);
    }
}