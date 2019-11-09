using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class StockProductController : Controller
    {
        private PiDevCRMContexte db = new PiDevCRMContexte();
        // GET: StockProduct
        public ActionResult Index(Stock stock,Product product)
        {
            var mymodel = new StockProduits();
            mymodel.listProducts = db.Products.ToList();
            mymodel.listStocks = db.Stock.ToList();



            return View(mymodel);
        }
    }
}