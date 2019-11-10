﻿using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class ProductController : Controller
    {

        public ProductService PS;
        public CategoryService cs;
        public DiscountService DS;
        public PackService Pas;
        public PacksController PC;
        public StockService SS;
        public CartService CS;

        public ProductController()
        {
            PS = new ProductService();
            cs = new CategoryService();
            DS = new DiscountService();
            Pas = new PackService();
            PC = new PacksController();
            SS = new StockService();
            CS = new CartService();
        }
        // GET: Product
        public ActionResult Index()
        {
            
            return View(PS.GetAll());
        }

       



        public ActionResult Index1(Pack pack)
        {
            //Product prod = new Product();
            //Pack p = new Pack();
            //if (prod.IdPack== p.IdPack)
            //{
                return View(PS.GetProductByPack(pack));
            //}
            //return View();

        }

        public ActionResult IndexFrontPAck()
        {
            return View(Pas.GetAll());

        }

        public ActionResult IndexFront()
        {
           
            return View(PS.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = PS.GetById(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }

        public ActionResult ListProds(int id, Pack pack)
        {
            //return View(PS.GetProductByPack(pack));
            return View(PS.GetProductByPackRefer(id,pack));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var listCategories = cs.GetAll();
            ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");

            var ListSto = SS.GetAll();
            ViewBag.stocks = new SelectList(ListSto, "Ref_Stock", "stockname");

            return View();
            
        }

     

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            try
            {
                product.ImageProduct = file.FileName;
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                    file.SaveAs(path);
                }
 

                PS.Add(product);
                PS.Commit();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product Prod = PS.GetById(id);
            var listCategories = cs.GetAll();
            ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");

            var ListP = Pas.GetAll();
            ViewBag.packs = new SelectList(ListP, "IdPack", "PackName");

            var ListD = DS.GetAll();
            ViewBag.discs = new SelectList(ListD, "IdDiscount", "Pourcentage");


            var ListSto = SS.GetAll();
            ViewBag.stocks = new SelectList(ListSto, "Ref_Stock", "stockname");

            var Carts = CS.GetAll();
            ViewBag.cart = new SelectList(Carts, "IdCart");

            if (Prod == null)
            {

                return HttpNotFound();
            }
            return View(Prod);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {

            Product prod = PS.GetById(p.IdProduct);

            prod.NameProduct = p.NameProduct;
            prod.Price = p.Price;
            prod.Description = p.Description;
            prod.IdPack = p.IdPack;
            prod.IdStock = p.IdStock;
            Pas.ListProds.Add(p);
            prod.IdCategory = p.IdCategory;
            prod.IdDiscount = p.IdDiscount;
            if (ModelState.IsValid)
            {
                
                PS.Update(prod);
                
                PS.Commit();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult EditCart(int id)
        {
            Product Prod = PS.GetById(id);
            

            if (Prod == null)
            {

                return HttpNotFound();
            }
            return View(Prod);
        }

        [HttpPost]
        public ActionResult EditCart(Product p)
        {

            Product prod = PS.GetById(p.IdProduct);

            prod.NameProduct = p.NameProduct;
            prod.Price = p.Price;           
            prod.IdDiscount = p.IdDiscount;
            if (ModelState.IsValid)
            {

                //PS.Add(prod);
                //PS.Commit();
                //ViewBag.Message = "Added to cart... Do you want to buy now?";
                return RedirectToAction("IndexFront");
            }

            return View();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = PS.GetById(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Product pro = PS.GetById(id);
            PS.Delete(pro);
            PS.Commit();
            return RedirectToAction("Index");

        }


        public ActionResult EditCartPack(int id)
        {
            Pack Prod = Pas.GetById(id);


            if (Prod == null)
            {

                return HttpNotFound();
            }
            return View(Prod);
        }

        [HttpPost]
        public ActionResult EditCartPack(Pack p)
        {

            Pack prod = Pas.GetById(p.IdPack);

            prod.PackName = p.PackName;
            prod.PackPrice = p.PackPrice;

            if (ModelState.IsValid)
            {

                //PS.Add(prod);
                //PS.Commit();
                //ViewBag.Message = "Added to cart... Do you want to buy now?";
                return RedirectToAction("IndexFront");
            }

            return View();
        }
    

    public ActionResult Dashboard()
        {
            var list = PS.GetAll();
            List<int> repartitions = new List<int>();
            var prices = list.Select(x => x.Price).Distinct();
            foreach (var item in prices)
            {
                repartitions.Add(list.Count(x => x.Price == item));
            }
            var rep = repartitions;
            ViewBag.PRICES = prices;
            ViewBag.REP = repartitions.ToList();

            return View();
        }

    }
}
