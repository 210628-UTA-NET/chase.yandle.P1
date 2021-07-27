using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IOrdersBL
    {

        public int AddOrders(Order p_order);
        public List<Order> GetAllOrders();
        public List<Order> GetOrdersByStore(int p_storeID, Sort p_method);
        public List<Order> GetOrdersByCustomer(int p_custID, Sort p_method);
    }
}