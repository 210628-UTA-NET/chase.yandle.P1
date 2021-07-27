using System.Collections.Generic;
using Models;
using System.Linq;

namespace DL
{
    public class CustRepository : ICustRepository
    {
        private StDbContext _context;
        public CustRepository(StDbContext p_context)
        {
            _context=p_context;
        }
        public void AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);
            _context.SaveChanges();
        }
        public List<Customer> GetAllCustomers()
        {   
            return _context.Customers.Select(cust => cust).ToList();
        }

        public List<Customer> GetCustomerByName(string p_string)
        {
            return _context.Customers
            .Where(cust => cust.cName.ToUpper().Contains(p_string.ToUpper()))
            .Select(cust => cust)
            .ToList();
        }
        public Customer GetCustomer(int p_ID)
        {
            return _context.Customers.FirstOrDefault(cust => cust.cID==p_ID);
        }
    
    }
}