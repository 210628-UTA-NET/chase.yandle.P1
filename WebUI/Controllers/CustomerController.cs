using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;
using BL;
using Models;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        private IOrdersBL _ordersBL;
        private ILineItemBL _lineitemBL;
        private IProdBL _prodBL;
        private IStoresBL _storesBL;

        public CustomerController(ICustomerBL p_customerBL, IOrdersBL p_ordersBL, ILineItemBL p_lineitemBL, IProdBL p_prodBL, IStoresBL p_storesBL)
        {
            _customerBL = p_customerBL;
            _ordersBL = p_ordersBL;
            _lineitemBL = p_lineitemBL;
            _prodBL = p_prodBL;
            _storesBL = p_storesBL;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string p_name)
        {
            if (p_name != null)
            {
                return View(
                    _customerBL.GetCustomerByName(p_name).Select(cust => new CustomerVM(cust)).ToList());
            }
            else
            {
                return View(
                _customerBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
                );
            }
        }

        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerBL.AddCustomer(new Customer
                        {
                            cName = custVM.cName,
                            cCity = custVM.cCity,
                            cStreet = custVM.cStreet,
                            cState = custVM.cState,
                            cEmail = custVM.cEmail,
                            cPhone = custVM.cPhone
                        }
                    );
                    return RedirectToAction(nameof(Login));
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult LogInCustomer(string p_name, int p_id)
        {
            CustomerVM.cCurrent.cName = p_name;
            CustomerVM.cCurrent.cID = p_id;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult OrderList(int p_custID, int p_sort)
        {
            OrderVM.currentCustomer = p_custID;
            List<OrderVM> temp = new();
            switch (p_sort)
            {
                case 1:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.LowToHigh).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }    
                    return View(temp);
                case 2:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.HighToLow).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    return View(temp);
                case 3:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.OldToNew).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    return View(temp);
                case 4:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.NewToOld).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    return View(temp);
                default:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.Default).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    return View(temp);
            }
            
        }
        [HttpPost]
        public IActionResult OrderDetails(int p_ordID)
        {
            List<LineItemVM> temp = new();
            temp = _lineitemBL.GetLineItems(p_ordID).Select(line => new LineItemVM(line)).ToList();
            foreach (LineItemVM item in temp)
            {
                item.liProdName = _prodBL.GetProductByID(item.liProductID).pName;
            }
            return View(temp);
        }
    }
}
