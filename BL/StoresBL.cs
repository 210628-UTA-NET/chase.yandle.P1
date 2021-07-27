using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class StoresBL : IStoresBL
    {
        private IStoreRepository _repo;
        public StoresBL(IStoreRepository p_repo)
        {
            _repo=p_repo;
        }
        public void AddStore(Store p_store)
        {
            _repo.AddStore(p_store);
        }
        public List<Store> GetAllStores()
        {
            return _repo.GetAllStores();
        }
        public List<Inventory> StoreInventory(Store p_store)
        {
            return _repo.StoreInventory(p_store);
        }
        public Store GetStore(int p_ID)
        {
            return _repo.GetStore(p_ID);
        }
    }
}