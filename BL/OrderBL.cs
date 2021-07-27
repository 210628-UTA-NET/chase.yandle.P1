using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class OrdersBL : IOrdersBL
    {
        private IOrdRepository _repo;
        public OrdersBL(IOrdRepository p_repo)
        {
            _repo=p_repo;
        }

        public int AddOrders(Order p_order)
        {
            return _repo.AddOrders(p_order);
        }
        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }
        public List<Order> GetOrdersByStore(int p_storeID, Sort p_method)
        {
            return _repo.GetOrdersByStore(p_storeID, p_method);
        }
        public List<Order> GetOrdersByCustomer(int p_custID, Sort p_method)
        {
            return _repo.GetOrdersByCustomer(p_custID, p_method);
        }
    }
}