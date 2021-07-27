using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{

    public enum Sort
        {
            OldToNew,
            NewToOld,
            LowToHigh,
            HighToLow,
            Default
        }
    public interface IOrdRepository
    {
        public List<Order> GetOrdersByStore(int p_storeID, Sort p_sort);
        public List<Order> GetOrdersByCustomer(int p_custID, Sort p_sort);
        public List<Order> GetAllOrders();
        public int AddOrders(Order p_order);
    }
}