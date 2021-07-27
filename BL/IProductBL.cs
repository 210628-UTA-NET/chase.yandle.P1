using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public interface IProdBL
    {
        public List<Product> GetAllProducts();
        public Product GetProductByID(int p_ID);
        public List<Inventory> StoresWithStock(Product p_prod);
        public void AddProduct(Product p_prod);
        public int StockAtStore(int p_prod, int p_store);
        public void AddToInventory(Inventory p_inv, int p_old);
        public void RemoveFromInventory(Inventory p_inv);
    }
}