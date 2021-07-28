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
