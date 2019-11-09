using PiDevCRM.Domain.Entities;
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

        public ProductController()
        {
            PS = new ProductService();
            cs = new CategoryService();
            DS = new DiscountService();
            Pas = new PackService();
        }
        // GET: Product
        public ActionResult Index()
        {
            //Product p = new Product();
            //if (p.IdDiscount == null)
            //{
            //    p.Price = p.Price * p.Discount.Pourcentage;
            //}
            return View(PS.GetAll());
        }
        public ActionResult IndexFront()
        {
            //Product p = new Product();
            //if (p.IdDiscount == null)
            //{
            //    p.Price = p.Price * p.Discount.Pourcentage;
            //}
            return View(PS.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var listCategories = cs.GetAll();
            ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");
            return View();
            
        }

        public ActionResult CreateDiscount()
        {
            var ListDisc = DS.GetAll();
            ViewBag.Discs = new SelectList(ListDisc, "IdDiscount", "Pourcentage");
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


            if (Prod == null)
            {

                return HttpNotFound();
            }
            //ViewBag.Category = new SelectList(listCategories, "IdCategory", "CategoryName");
            //ViewBag.IdCategory = new SelectList(PS.unitofwork.dataContext.Categories, "IdCategory", "CategoryName", Prod.IdCategory);
            //ViewBag.Category = new SelectList(P);
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
            prod.IdCategory = p.IdCategory;
            prod.IdDiscount = p.IdDiscount;
            if (ModelState.IsValid)
            {
                
                PS.Update(prod);
                PS.Commit();
                return RedirectToAction("Index");
            }

            return View();





            //    try
            //    {
            //        //p = PS.GetById(id);
            //        PS.Update(p);
            //        PS.Commit();
            //        return RedirectToAction("Index");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
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
    }
}
