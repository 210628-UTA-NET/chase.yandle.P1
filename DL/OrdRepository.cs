using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class OrdRepository : IOrdRepository
    {
        private StDbContext _context;
        public OrdRepository(StDbContext p_context)
        {  
            _context=p_context;       
        }
        public List<Order> GetOrdersByStore(int p_storeID, Sort p_sort)
        {
            switch (p_sort)
            {
                case Sort.HighToLow:
                    return _context.Orders
                    .Where(ord => ord.oStoreID == p_storeID)
                    .Select(ord => ord)
                    .OrderByDescending(ord => ord.oPrice)
                    .ToList();
                case Sort.LowToHigh:
                    return _context.Orders
                    .Where(ord => ord.oStoreID == p_storeID)
                    .Select(ord => ord)
                    .OrderBy(ord => ord.oPrice)
                    .ToList();
                case Sort.OldToNew:
                    return _context.Orders
                    .Where(ord => ord.oStoreID == p_storeID)
                    .Select(ord => ord)
                    .OrderBy(ord => ord.oDateAndTime)
                    .ToList();
                case Sort.NewToOld:
                    return _context.Orders
                    .Where(ord => ord.oStoreID == p_storeID)
                    .Select(ord => ord)
                    .OrderByDescending(ord => ord.oDateAndTime)
                    .ToList();
                default:
                    return _context.Orders
                    .Where(ord => ord.oStoreID == p_storeID)
                    .Select(ord => ord)
                    .ToList();
            }
        }
        public List<Order> GetOrdersByCustomer(int p_custID, Sort p_sort)
        {
            switch (p_sort)
            {
                case Sort.HighToLow:
                    return _context.Orders
                    .Where(ord => ord.oCustomerID == p_custID)
                    .Select(ord => ord)
                    .OrderByDescending(ord => ord.oPrice)
                    .ToList();
                case Sort.LowToHigh:
                    return _context.Orders
                    .Where(ord => ord.oCustomerID == p_custID)
                    .Select(ord => ord)
                    .OrderBy(ord => ord.oPrice)
                    .ToList();
                case Sort.OldToNew:
                    return _context.Orders
                    .Where(ord => ord.oCustomerID == p_custID)
                    .Select(ord => ord)
                    .OrderBy(ord => ord.oDateAndTime)
                    .ToList();
                case Sort.NewToOld:
                    return _context.Orders
                    .Where(ord => ord.oCustomerID == p_custID)
                    .Select(ord => ord)
                    .OrderByDescending(ord => ord.oDateAndTime)
                    .ToList();
                default:
                    return _context.Orders
                    .Where(ord => ord.oCustomerID == p_custID)
                    .Select(ord => ord)
                    .ToList();
            }
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.Select(ord => ord).ToList();
        }
        public int AddOrders(Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return _context.Orders.FirstOrDefault(ord => ord == p_order).oID;
        }
        
        
    }
}