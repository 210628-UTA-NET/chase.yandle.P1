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
using DL;
using Serilog;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrdersBL _ordersBL;
        private ILineItemBL _lineitemBL;
        private IProdBL _prodBL;

        public OrderController(IOrdersBL p_ordersBL, ILineItemBL p_lineitemBL, IProdBL p_prodBL)
        {
            _ordersBL = p_ordersBL;
            _lineitemBL = p_lineitemBL;
            _prodBL = p_prodBL;
        }

        public IActionResult Index()
        {
            Log.Information("Index is called");
            return View();
        }
        [HttpGet]
        public IActionResult Cart()
        {
            Log.Information("Display Cart Details");
            return View(OrderVM.currentLines);
        }

        [HttpPost]
        public IActionResult Cart(decimal p_oPrice)
        {
            OrderVM.currentOrder.oCustomerID = CustomerVM.cCurrent.cID;
            OrderVM.currentOrder.oStoreID = StoreVM.stCurrent.stID;
            int orderID=0;
            foreach (LineItemVM item in OrderVM.currentLines)
            {
                if (_prodBL.StockAtStore(item.liProductID,OrderVM.currentOrder.oStoreID)<item.liQuantity)
                {
                    Log.Information("Order Not posted");
                    return View();
                }
            }
            
                if (OrderVM.currentOrder.oCustomerID!=0 || OrderVM.currentOrder.oStoreID !=0)
                {
                    orderID=_ordersBL.AddOrders(new Order
                    {
                        oCustomerID = OrderVM.currentOrder.oCustomerID,
                        oStoreID = OrderVM.currentOrder.oStoreID,
                        oDateAndTime = DateTime.Now,
                        oPrice = p_oPrice
                    }
                    );
                    foreach (LineItemVM line in OrderVM.currentLines)
                    {
                        _lineitemBL.AddLineItem(new LineItem
                        {
                            liProductID = line.liProductID,
                            liQuantity = line.liQuantity,
                            liLinePrice = line.liLinePrice,
                            liOrderID = orderID
                        }
                        );
                        Inventory remove = new();
                        int old = _prodBL.StockAtStore(line.liProductID, OrderVM.currentOrder.oStoreID);
                        remove.iProductID = line.liProductID;
                        remove.iStoreID = OrderVM.currentOrder.oStoreID;
                        remove.iQuantity = old-line.liQuantity;
                        _prodBL.RemoveFromInventory(remove);
                    }
                    OrderVM.currentOrder = new();
                    OrderVM.currentLines = new();
                Log.Information("Order created and posted");
                return RedirectToAction(nameof(Cart));
                }
            Log.Information("Order Not posted");
            return View();
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            OrderVM.currentLines = new();
            return RedirectToAction("Cart");
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("Errored Out");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
