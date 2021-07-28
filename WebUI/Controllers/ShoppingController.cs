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
    public class ShoppingController : Controller
    {
        private IProdBL _prodBL;
        private IOrdersBL _ordersBL;
        private ILineItemBL _lineitemBL;

        public static OrderVM _orderVM;
        public static List<LineItemVM> _lineitemVMs;

        public ShoppingController(IProdBL p_prodBL, IOrdersBL p_ordersBL, ILineItemBL p_LineItemBL)
        {
            _prodBL = p_prodBL;
            _ordersBL = p_ordersBL;
            _lineitemBL = p_LineItemBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Log.Information("All Products Gathered");
            return View(
                _prodBL.GetAllProducts()
                .Select(prod => new ProductVM(prod))
                .ToList()
                );
        }

        public IActionResult AddToOrder(int p_prod, int p_quant)
        {
            LineItemVM newLine = new()
            {
                liProductID = p_prod,
                liProduct = new ProductVM(_prodBL.GetProductByID(p_prod)),
                liQuantity = p_quant,
                liLinePrice = new ProductVM(_prodBL.GetProductByID(p_prod)).pPrice*p_quant
            };
            OrderVM.currentLines.Add(newLine);
            Log.Information("Item Added to Cart");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            Log.Information("Product Creation screen called");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM prodVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _prodBL.AddProduct(new Product
                    {
                        pName = prodVM.pName,
                        pPrice = prodVM.pPrice,
                        pReleaseDate = prodVM.pReleaseDate,
                    }
                    );
                    Log.Information("Product Added to system");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                Log.Information("Product not added to system");
                return View();
            }
            Log.Information("Product not added to system");
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("Errored Out");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
