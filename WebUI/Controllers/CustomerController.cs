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
using Microsoft.AspNetCore.Http;
using Serilog;

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
            Log.Information("Went to Create Customer Menu");
            return View();
        }

        [HttpGet]
        public IActionResult Login(string p_name)
        {
            if (p_name != null)
            {
                Log.Information("Customer List Filtered");
                return View(
                    _customerBL.GetCustomerByName(p_name).Select(cust => new CustomerVM(cust)).ToList());
            }
            else
            {
                Log.Information("Get Full Customer List");
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
                    Log.Information("Created a Customer");
                    return RedirectToAction(nameof(Login));
                }
            }
            catch (Exception)
            {
                Log.Information("Customer Not Created Due to Exception");
                return View();
            }
            Log.Information("Customer Not Created Due to Invalid ModelState");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("Errored out");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult LogInCustomer(string p_name, int p_id)
        {
            CustomerVM.cCurrent.cName = p_name;
            CustomerVM.cCurrent.cID = p_id;
            Log.Information("Current Customer Logged In");
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
                    Log.Information("Customer Orders Sorted");
                    return View(temp);
                case 2:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.HighToLow).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    Log.Information("Customer Orders Sorted");
                    return View(temp);
                case 3:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.OldToNew).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    Log.Information("Customer Orders Sorted");
                    return View(temp);
                case 4:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.NewToOld).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    Log.Information("Customer Orders Sorted");
                    return View(temp);
                default:
                    temp = _ordersBL.GetOrdersByCustomer(p_custID, DL.Sort.Default).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oStoreStreet = _storesBL.GetStore(item.oStoreID).stStreet;
                    }
                    Log.Information("Customer Orders Sorted");
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
            Log.Information("Customer Order Details");
            return View(temp);
        }
    }
}
