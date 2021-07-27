using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class StoreRepository : IStoreRepository
    {
        private StDbContext _context;
        public StoreRepository(StDbContext p_context)
        {  
            _context=p_context;       
        }
        public List<Store> GetAllStores()
        {
            return _context.Stores.Select(sto => sto).ToList();
        }
        public void AddStore(Store p_store)
        {
            _context.Stores.Add(p_store);
            _context.SaveChanges();
        }
        public List<Inventory> StoreInventory(Store p_store)
        {
            return _context.Inventories.Where(inv => inv.iStore == p_store).Select(inv => inv).ToList();
        }
        public Store GetStore(int p_ID)
        {
            return _context.Stores.FirstOrDefault(store => store.stID == p_ID);
        }

    }
}