using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IStoresBL
    {
        public void AddStore(Store p_store);
        public List<Store> GetAllStores();
        public List<Inventory> StoreInventory(Store p_store);
        public Store GetStore(int p_ID);
    }
}