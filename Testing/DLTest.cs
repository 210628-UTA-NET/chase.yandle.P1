using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using DL;
using Models;
using System.Collections.Generic;

namespace Testing
{
    public class DLTest
    {

        private readonly DbContextOptions<StDbContext> _options;
        public DLTest()
        {
            _options = new DbContextOptionsBuilder<StDbContext>().UseSqlite("Filename = test.db").Options;
            this.Seed();
        }
        [Fact]
        public void AddCustomerTest()
        {
            using (var context = new StDbContext(_options))
            {

                ICustRepository repo = new CustRepository(context);
                List<Customer> customers = new();
                repo.AddCustomer(new Customer()
                {
                    cID = 2,
                    cName = "John Jacobs",
                    cStreet = "132 Jingleheimer Ln",
                    cCity = "His Name",
                    cState = "Is",
                    cEmail = "MyName@too.com",
                    cPhone = "919-867-5309"
                });
                customers = repo.GetAllCustomers();
                Assert.NotNull(customers);
                Assert.Equal(2,customers.Count);

            }
        }
        [Fact]
        public void GetAllCustomersTest()
        {
            using (var context = new StDbContext(_options))
            {

                ICustRepository repo = new CustRepository(context);
                List<Customer> customers= new();

                customers = repo.GetAllCustomers();
                Assert.NotNull(customers);
                Assert.Single(customers);

            }
        }
        [Fact]
        public void GetCustomerByNameTest()
        {
            using (var context = new StDbContext(_options))
            {

                ICustRepository repo = new CustRepository(context);
                List<Customer> customers = new();

                customers = repo.GetCustomerByName("Chase");
                Assert.NotNull(customers);
                Assert.Single(customers);

            }
        }
        [Fact]
        public void GetCustomerTest()
        {
            using (var context = new StDbContext(_options))
            {

                ICustRepository repo = new CustRepository(context);
                Customer customers = new();

                customers = repo.GetCustomer(1);
                Assert.NotNull(customers);
                Assert.Equal("Chase Yandle",customers.cName);

            }
        }
        [Fact]
        public void AddLineItemTest()
        {
            using (var context = new StDbContext(_options))
            {

                ILineRepository repo = new LineRepository(context);
                List<LineItem> lines = new();
                repo.AddLineItem(new LineItem { 
                    liID = 2,
                    liOrderID = 1,
                    liProductID = 1,
                    liQuantity = 2,
                    liLinePrice = 100
                });


                lines = repo.GetLineItems(1);
                Assert.NotNull(lines);
                Assert.Equal(2, lines.Count);

            }
        }
        [Fact]
        public void GetLineItemsTest()
        {
            using (var context = new StDbContext(_options))
            {

                ILineRepository repo = new LineRepository(context);
                List<LineItem> lines = new();

                lines = repo.GetLineItems(1);
                Assert.NotNull(lines);
                Assert.Single(lines);

            }
        }

        [Fact]
        public void GetOrdersByStoreTest()
        {
            using (var context = new StDbContext(_options))
            {

                IOrdRepository repo = new OrdRepository(context);
                List<Order> orders = new();

                orders = repo.GetOrdersByStore(1, Sort.Default);
                Assert.NotNull(orders);
                Assert.Single(orders);

            }
        }

        [Fact]
        public void GetOrdersByCustomerTest()
        {
            using (var context = new StDbContext(_options))
            {

                IOrdRepository repo = new OrdRepository(context);
                List<Order> orders = new();

                orders = repo.GetOrdersByCustomer(1, Sort.Default);
                Assert.NotNull(orders);
                Assert.Single(orders);

            }
        }

        [Fact]
        public void GetAllOrdersTest()
        {
            using (var context = new StDbContext(_options))
            {

                IOrdRepository repo = new OrdRepository(context);
                List<Order> orders = new();

                orders = repo.GetAllOrders();
                Assert.NotNull(orders);
                Assert.Single(orders);

            }
        }

        [Fact]
        public void AddOrdersTest()
        {
            using (var context = new StDbContext(_options))
            {

                IOrdRepository repo = new OrdRepository(context);
                List<Order> orders = new();
                repo.AddOrders(new Order
                {
                    oID = 2,
                    oCustomerID = 1,
                    oStoreID = 1,
                    oDateAndTime = DateTime.Now,
                    oPrice = 50
                });


                orders = repo.GetAllOrders();
                Assert.NotNull(orders);
                Assert.Equal(2, orders.Count);

            }
        }

        [Fact]
        public void GetAllProductsTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                List<Product> prod = new();

                prod = repo.GetAllProducts();
                Assert.NotNull(prod);
                Assert.Single(prod);

            }
        }
        [Fact]
        public void GetProductByIDTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                Product prod = new();

                prod = repo.GetProductByID(1);
                Assert.NotNull(prod);
                Assert.Equal("Bioshock Infinite",prod.pName);

            }
        }
        [Fact]
        public void StoresWithStockTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                List<Inventory> inven = new();

                inven = repo.StoresWithStock(new Product { pID = 1, pName = "Bioshock Infinite", pPrice = 50, pReleaseDate = DateTime.Now });
                Assert.NotNull(inven);
                Assert.Single(inven);

            }
        }
        [Fact]
        public void StockAtStoreTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                int quant;

                quant = repo.StockAtStore(1,1);
                Assert.Equal(8,quant);

            }
        }

        [Fact]
        public void AddProductTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                List<Product> prod = new();
                repo.AddProduct(new Product
                {
                    pID = 2,
                    pName = "Skyward Sword",
                    pReleaseDate = DateTime.Now,
                    pPrice = 50
                });


                prod = repo.GetAllProducts();
                Assert.NotNull(prod);
                Assert.Equal(2, prod.Count);

            }
        }

        [Fact]
        public void AddToInventoryTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                int result;
                Inventory inven = new Inventory
                {
                    iStoreID = 1,
                    iProductID = 1,
                    iQuantity = 7
                };
                repo.AddToInventory(inven, 8);
                result = repo.StockAtStore(1,1);
                Assert.Equal(7, result);

            }
        }

        [Fact]
        public void RemoveFromInventoryTest()
        {
            using (var context = new StDbContext(_options))
            {

                IProdRepository repo = new ProdRepository(context);
                int result;
                Inventory inven = new Inventory
                {
                    iStoreID = 1,
                    iProductID = 1,
                    iQuantity = 7
                };
                repo.RemoveFromInventory(inven);
                result = repo.StockAtStore(1, 1);
                Assert.Equal(7, result);

            }
        }

        [Fact]
        public void GetAllStoresTest()
        {
            using (var context = new StDbContext(_options))
            {

                IStoreRepository repo = new StoreRepository(context);
                List<Store> store = new();

                store = repo.GetAllStores();
                Assert.NotNull(store);
                Assert.Single(store);

            }
        }

        [Fact]
        public void StoreInventoryTest()
        {
            using (var context = new StDbContext(_options))
            {

                IStoreRepository repo = new StoreRepository(context);
                List<Inventory> inven = new();

                inven = repo.StoreInventory(new Store { stID = 1, stStreet = "1131 Market Center Dr", stCity = "Morrisville", stState = "NC", stEmail = "morrisville@gamestop.com", stPhone = "919-867-5309" });
                Assert.NotNull(inven);
                Assert.Single(inven);

            }
        }

        [Fact]
        public void GetStoreTest()
        {
            using (var context = new StDbContext(_options))
            {

                IStoreRepository repo = new StoreRepository(context);
                Store store = new();

                store = repo.GetStore(1);
                Assert.NotNull(store);
                Assert.Equal("1131 Market Center Dr",store.stStreet);

            }
        }

        [Fact]
        public void AddStoreTest()
        {
            using (var context = new StDbContext(_options))
            {

                IStoreRepository repo = new StoreRepository(context);
                List<Store> store = new();
                repo.AddStore(new Store
                {
                    stID = 2,
                    stStreet = "8301 Brier Creek Pkwy",
                    stCity = "Raleigh",
                    stState = "NC",
                    stEmail = "briercreek@gamestop.com",
                    stPhone = "919-867-5310"
                });


                store = repo.GetAllStores();
                Assert.NotNull(store);
                Assert.Equal(2, store.Count);

            }
        }

        private void Seed()
        {
            using (var context = new StDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.Add(
                    new Customer()
                    {
                        cID = 1,
                        cName = "Chase Yandle",
                        cStreet = "203 Church St",
                        cCity = "Morrisville",
                        cState = "NC",
                        cEmail = "cayandle@live.com",
                        cPhone = "919-623-3658"
                    });
                context.Stores.Add(
                    new Store()
                    {
                        stID = 1,
                        stStreet = "1131 Market Center Dr",
                        stCity = "Morrisville",
                        stState = "NC",
                        stEmail = "morrisville@gamestop.com",
                        stPhone = "919-867-5309"
                    });
                context.Orders.Add(
                    new Order()
                    {
                        oID=1,
                        oCustomerID = 1,
                        oStoreID = 1,
                        oDateAndTime = DateTime.Now,
                        oPrice = 50
                    });
                context.Products.Add(
                    new Product()
                    {
                        pID = 1,
                        pName = "Bioshock Infinite",
                        pReleaseDate = DateTime.Now,
                        pPrice = 50
                    });
                context.Inventories.Add(
                    new Inventory()
                    {
                        iStoreID = 1,
                        iProductID = 1,
                        iQuantity = 8
                    });
                context.LineItems.Add(
                    new LineItem()
                    {
                        liID = 1,
                        liOrderID = 1,
                        liProductID = 1,
                        liQuantity = 2,
                        liLinePrice = 100
                    });
                context.SaveChanges();
            }

        }
    }
}
