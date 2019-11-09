using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class DiscountController : Controller
    {
        public ProductService ps;
        public Product prod;
        public DiscountService Ds;
        public DiscountController()
        {
            Ds = new DiscountService();
            ps = new ProductService();
            prod = new Product();

        }
        // GET: Discount
        public ActionResult Index()
        {

            ////using (PiDevCRMContexte ctx = new PiDevCRMContexte())
            ////{
            //    var x = Ds.GetAll().Where(a => a.EndDate < DateTime.Now);
            //    var dis = x;
            //    foreach (var item in dis)
            //    {
            //        var pr = ps.GetAll().Where(p => p.IdDiscount != null);
            //        var o = pr;

            //        //Ds.Delete(item);
            //        //Ds.Commit();
            //    }
            //}
            return View(Ds.GetAll());
        }

        // GET: Discount/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount disc = Ds.GetById(id);
            if (disc == null)
            {
                return HttpNotFound();
            }
            return View(disc);
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            var ProductList = ps.GetAll();
            ViewBag.Products = new SelectList(ProductList, "IdProduct", "NameProduct");

            
            return View();
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Create(Discount discount,Product prod)
        {
            try
            {
                Ds.Add(discount); 
                Ds.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int id)
        {
            Discount ds = Ds.GetById(id);
            return View(ds);
        }

        // POST: Discount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Discount dis)
        {
            Discount d = Ds.GetById(dis.IdDiscount);

            d.Pourcentage = dis.Pourcentage;
            d.StartDate = dis.StartDate;
            d.EndDate = dis.EndDate;
            if (d.EndDate == d.StartDate)
            {
                Ds.Delete(d);
                Ds.Commit();
            }

            if (ModelState.IsValid)
            {
                Ds.Update(d);
                Ds.Commit();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Discount/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = Ds.GetById(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Discount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Discount disc = Ds.GetById(id);
            Ds.Delete(disc);
            Ds.Commit();
            return RedirectToAction("Index");

        }
    }
    }

