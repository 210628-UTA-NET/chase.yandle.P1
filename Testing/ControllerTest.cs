using BL;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;
using WebUI.Models;
using Xunit;

namespace Testing
{
    public class ControllerTest
    {
        [Fact]
        public void LoginShowsAllCustomers()
        {

            var mockCustBL = new Mock<ICustomerBL>();
            var mockOrdBL = new Mock<IOrdersBL>();
            var mockLineBL = new Mock<ILineItemBL>();
            var mockProdBL = new Mock<IProdBL>();
            var mockStoreBL = new Mock<IStoresBL>();
            mockCustBL.Setup(custBL => custBL.GetAllCustomers()).Returns
            (
                new List<Customer>
                {
                    new Customer(){ cName = "Chase Yandle"},
                    new Customer(){ cName = "John Jacob"}
                }
            );

            var custController = new CustomerController(mockCustBL.Object, mockOrdBL.Object, mockLineBL.Object, mockProdBL.Object, mockStoreBL.Object);

            var result = custController.Login(null);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerVM>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());

        }
        [Fact]
        public void LoginFiltersCustomersByName()
        {

            var mockCustBL = new Mock<ICustomerBL>();
            var mockOrdBL = new Mock<IOrdersBL>();
            var mockLineBL = new Mock<ILineItemBL>();
            var mockProdBL = new Mock<IProdBL>();
            var mockStoreBL = new Mock<IStoresBL>();
            mockCustBL.Setup(custBL => custBL.GetCustomerByName("Chase")).Returns
            (
                new List<Customer>
                {
                    new Customer(){ cName = "Chase Yandle"}
                }
            );

            var custController = new CustomerController(mockCustBL.Object, mockOrdBL.Object, mockLineBL.Object, mockProdBL.Object, mockStoreBL.Object);

            var result = custController.Login("Chase");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerVM>>(viewResult.ViewData.Model);

            Assert.Single(model);

        }

        [Fact]
        public void CreateChangesView()
        {

            var mockCustBL = new Mock<ICustomerBL>();
            var mockOrdBL = new Mock<IOrdersBL>();
            var mockLineBL = new Mock<ILineItemBL>();
            var mockProdBL = new Mock<IProdBL>();
            var mockStoreBL = new Mock<IStoresBL>();
            mockCustBL.Setup(custBL => custBL.GetAllCustomers()).Returns
            (
                new List<Customer>
                {
                    new Customer(){ cName = "Chase Yandle"},
                    new Customer(){ cName = "John Jacob"}
                }
            );

            var custController = new CustomerController(mockCustBL.Object, mockOrdBL.Object, mockLineBL.Object, mockProdBL.Object, mockStoreBL.Object);

            var result = custController.Create();

            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void OrderListTest()
        {

            var mockCustBL = new Mock<ICustomerBL>();
            var mockOrdBL = new Mock<IOrdersBL>();
            var mockLineBL = new Mock<ILineItemBL>();
            var mockProdBL = new Mock<IProdBL>();
            var mockStoreBL = new Mock<IStoresBL>();
            mockOrdBL.Setup(mockOrdBL => mockOrdBL.GetOrdersByCustomer(5,DL.Sort.Default)).Returns
            (
                new List<Order>
                {
                    new Order(){ oCustomerID = 5, oStoreID=4}
                }
            );

            mockStoreBL.Setup(mockStoreBL => mockStoreBL.GetStore(4)).Returns(new Store { stStreet = "Fake" });

            var custController = new CustomerController(mockCustBL.Object, mockOrdBL.Object, mockLineBL.Object, mockProdBL.Object, mockStoreBL.Object);

            var result = custController.OrderList(5,0);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<OrderVM>>(viewResult.ViewData.Model);

            Assert.Single(model);

        }

    }
}
