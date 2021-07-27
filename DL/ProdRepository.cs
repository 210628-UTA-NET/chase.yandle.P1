using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class ProdRepository : IProdRepository
    {
        private StDbContext _context;
        public ProdRepository(StDbContext p_context)
        {
            _context = p_context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(prod => prod).ToList();
        }
        public Product GetProductByID(int p_ID)
        {
            return _context.Products.FirstOrDefault(prod => prod.pID == p_ID);
        }
        public List<Inventory> StoresWithStock(Product p_prod)
        {
            return _context.Inventories.Where(pro => pro.iProduct == p_prod).Select(pro => pro).ToList();
        }
        public void AddProduct(Product p_prod)
        {
            _context.Products.Add(p_prod);
            _context.SaveChanges();
        }
        public int StockAtStore(int p_prod, int p_store)
        {
            if (_context.Inventories.AsNoTracking().FirstOrDefault(pro => pro.iProductID == p_prod && pro.iStoreID == p_store) == null)
            {
                return 0;
            }
            else
            {
                return _context.Inventories.AsNoTracking().FirstOrDefault(pro => pro.iProductID == p_prod && pro.iStoreID == p_store).iQuantity;
            }
        }

        public void AddToInventory(Inventory p_inv, int p_old)
        {
            if (p_old != 0)
            {
                _context.Inventories.Update(p_inv);
                _context.SaveChanges();
            }
            else
            {
                _context.Inventories.Add(p_inv);
                _context.SaveChanges();
            }
        }
        public void RemoveFromInventory(Inventory p_inv)
        {

            _context.Inventories.Update(p_inv);
            _context.SaveChanges();
        }
    }
}