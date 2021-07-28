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
    }
}
