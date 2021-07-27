using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class ProdBL : IProdBL
    {
        private IProdRepository _repo;
        public ProdBL(IProdRepository p_repo)
        {
            _repo=p_repo;
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
        public Product GetProductByID(int p_ID)
        {
            return _repo.GetProductByID(p_ID);
        }
        public List<Inventory> StoresWithStock(Product p_prod)
        {
            return _repo.StoresWithStock(p_prod);
        }
        public void AddProduct(Product p_prod)
        {
            _repo.AddProduct(p_prod);
        }
        public int StockAtStore(int p_prod, int p_store)
        {
            return _repo.StockAtStore(p_prod,p_store);
        }
        public void AddToInventory(Inventory p_inv, int p_old)
        {
            _repo.AddToInventory(p_inv, p_old);
        }
        public void RemoveFromInventory(Inventory p_inv)
        {

            _repo.RemoveFromInventory(p_inv);
        }
    }
}