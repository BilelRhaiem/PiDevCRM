using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class CartController : Controller
    {



        public ProductService PS;
        public CartService Cs;

        public CartController()
        {
            PS = new ProductService();
            Cs = new CartService();
        }





        // GET: Cart
        public ActionResult Index()
        {
            return View(Cs.GetAll());
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(Cart cart,Product prod)
        {
            try
            {
                Cart cr = new Cart();
                cr.IdProduct = PS.ProductID(prod);
                
                cr.Quantity = prod.Quantity;
                Cs.Add(cart);
                Cs.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            var listprods = PS.GetAll();
            ViewBag.prods = new SelectList(listprods, "IdProduct", "NameProduct");
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
           
                
               Cart c = new Cart();
               c.Product.IdProduct= cart.Product.IdProduct;

                c.Product.Price = cart.Product.IdProduct;
            if (ModelState.IsValid)
            {

                Cs.Add(c);

                Cs.Commit();
                return RedirectToAction("Index");
            }

            return View();


        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
