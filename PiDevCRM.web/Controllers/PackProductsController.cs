using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using PiDevCRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class PackProductsController : Controller
    {

        private PiDevCRMContexte db = new PiDevCRMContexte();

        public ProductService PS;

        public PackProductsController()
        {
            PS = new ProductService();
        }

        // GET: PackProducts
        public ActionResult Index(Pack pack,Product prod)
        {

            var mymodel = new PackProduct();
            mymodel.ListProds = db.Products.ToList();
            mymodel.ListPacks = db.Pack.ToList();

            return View(mymodel);
        }

        public ActionResult IndexFront(Pack pack, Product prod)
        {

            var mymodel = new PackProduct();
            mymodel.ListProds = db.Products.ToList();
            mymodel.ListPacks = db.Pack.ToList();

            return View(mymodel);
        }



        public ActionResult CartIndex(Pack pack, Product prod)
        {

            var mymodel = new PackProduct();
            mymodel.ListProds = db.Products.ToList();
            mymodel.ListPacks = db.Pack.ToList();

            return View(mymodel);
        }

        public ActionResult IndexStore(Pack pack, Product prod)
        {

            return View("~/Views/Store/index.cshtml");
        }


        public ActionResult IndexCart(Pack pack, Product prod)
        {

            return View("~/Views/PackProducts/CartIndex.cshtml");
        }

        //public int getProdId(PackProduct pp)
        //{
        //    return pp.ListProds.fi;
        //}

        public ActionResult Edit(int id)
        {
            Product Prod = PS.GetById(id);
           
            if (Prod == null)
            {

                return HttpNotFound();
            }
            return View(Prod);
        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Product p,int id)
        //{

        //    //PackProduct prod = PS.GetById(p.IdProduct);

        //    //prod.NameProduct = p.NameProduct;
        //    //prod.Price = p.Price;
        //    //prod.Description = p.Description;
        //    //prod.IdPack = p.IdPack;
        //    //prod.IdStock = p.IdStock;
        //    ////Pas.ListProds.Add(p);
        //    //prod.IdCategory = p.IdCategory;
        //    //prod.IdDiscount = p.IdDiscount;
        //    //if (ModelState.IsValid)
        //    //{

        //    //    PS.Update(prod);

        //    //    PS.Commit();
        //    //    return RedirectToAction("Index");
        //    //}

        //    //return View();
        //}


    }
}