using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public interface IStoreRepository
    {
        public List<Store> GetAllStores();
        public void AddStore(Store p_store);
        public List<Inventory> StoreInventory(Store p_store);
        public Store GetStore(int p_ID);
    }
}