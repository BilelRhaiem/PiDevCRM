using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiDevCRM.Web.Models
{
    public class PackProduct
    {
        public List<Pack> ListPacks { get; set; }
        public List<Product> ListProds { get; set; }

        public String NameOfPack { get; set; }

        public int? IdProd { get; set; }
        public int? IdPack { get; set; }
    }
}