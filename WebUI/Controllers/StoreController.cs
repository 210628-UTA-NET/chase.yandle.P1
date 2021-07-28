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
using Serilog;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IStoresBL _storesBL;
        private IProdBL _prodBL;
        private IOrdersBL _ordersBL;
        private ILineItemBL _lineitemBL;
        private ICustomerBL _customerBL;

        public StoreController(IStoresBL p_storesBL, IProdBL p_prodBL, IOrdersBL p_ordersBL, ILineItemBL p_lineitemBL, ICustomerBL p_customerBL)
        {
            _storesBL = p_storesBL;
            _prodBL = p_prodBL;
            _ordersBL = p_ordersBL;
            _lineitemBL = p_lineitemBL;
            _customerBL = p_customerBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Log.Information("");
            return View(
                _storesBL.GetAllStores()
                .Select(store => new StoreVM(store))
                .ToList()
                );
            
        }
        public IActionResult Create()
        {
            Log.Information("Store Creation Menu Called");
            return View();
        }

        [HttpGet]
        public IActionResult Inventory()
        {
            List<ProductVM> temp = new();
            temp =_prodBL.GetAllProducts()
                .Select(prod => new ProductVM(prod))
                .ToList();
            foreach (ProductVM item in temp)
            {
                try
                {
                    item.pQuantity = _prodBL.StockAtStore(item.pID, StoreVM.stInventorySet.stID);
                }
                catch (NullReferenceException)
                {
                    item.pQuantity = 0;
                }
            }
            Log.Information("Inventory of a store called");
            return View(temp);
        }

        [HttpPost]
        public IActionResult SetInventoryStore(string p_street, int p_id)
        {
            StoreVM.stInventorySet.stStreet = p_street;
            StoreVM.stInventorySet.stID = p_id;
            Log.Information("Inventory Action Called");
            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public IActionResult Restock(int p_quant, int p_prod, int p_store, int p_oldquant)
        {
            Inventory add = new();
            add.iProductID = p_prod;
            add.iStoreID = p_store;
            add.iQuantity = p_quant+p_oldquant;
            _prodBL.AddToInventory(add, p_oldquant);
            Log.Information("Inventory Updated");
            return RedirectToAction("Inventory");
        }



        [HttpPost]
        public IActionResult Create(StoreVM storeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storesBL.AddStore(new Store
                    {
                        stCity = storeVM.stCity,
                        stStreet = storeVM.stStreet,
                        stState = storeVM.stState,
                        stEmail = storeVM.stEmail,
                        stPhone = storeVM.stPhone
                    }
                    );
                    Log.Information("Store Added");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                Log.Information("Store not added");
                return View();
            }
            Log.Information("Store not added");
            return View();
        }


        [HttpPost]
        public IActionResult LogInStore(string p_name, int p_id)
        {
            StoreVM.stCurrent.stStreet = p_name;
            StoreVM.stCurrent.stID = p_id;
            Log.Information("Store logged in");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult OrderList(int p_storeID, int p_sort)
        {
            OrderVM.currentStore = p_storeID;
            List<OrderVM> temp = new();
            switch (p_sort)
            {
                case 1:
                    temp = _ordersBL.GetOrdersByStore(p_storeID, DL.Sort.LowToHigh).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oCustName = _customerBL.GetCustomer(item.oCustomerID).cName;
                    }
                    Log.Information("Store order list sorted");
                    return View(temp);
                case 2:
                    temp = _ordersBL.GetOrdersByStore(p_storeID, DL.Sort.HighToLow).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oCustName = _customerBL.GetCustomer(item.oCustomerID).cName;
                    }
                    Log.Information("Store order list sorted");
                    return View(temp);
                case 3:
                    temp = _ordersBL.GetOrdersByStore(p_storeID, DL.Sort.OldToNew).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oCustName = _customerBL.GetCustomer(item.oCustomerID).cName;
                    }
                    Log.Information("Store order list sorted");
                    return View(temp);
                case 4:
                    temp = _ordersBL.GetOrdersByStore(p_storeID, DL.Sort.NewToOld).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oCustName = _customerBL.GetCustomer(item.oCustomerID).cName;
                    }
                    Log.Information("Store order list sorted");
                    return View(temp);
                default:
                    temp = _ordersBL.GetOrdersByStore(p_storeID, DL.Sort.Default).Select(ord => new OrderVM(ord)).ToList();
                    foreach (OrderVM item in temp)
                    {
                        item.oCustName = _customerBL.GetCustomer(item.oCustomerID).cName;
                    }
                    Log.Information("Store order list sorted");
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
            Log.Information("Store order details shown");
            return View(temp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("Errored Out");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
