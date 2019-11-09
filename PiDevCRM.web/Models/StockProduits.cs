using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiDevCRM.Web.Models
{
    public class StockProduits
    {
        public List<Product> listProducts{ get; set; }
        public List<Stock> listStocks { get; set; }
    }
}