using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using PiDevCRM.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class PacksController : Controller
    {

        public PackService PaS;
        public ProductService ps;

        public PacksController()
        {
            PaS = new PackService();
            ps = new ProductService();
        }
        // GET: Packs
        public ActionResult Index()
        {
            return View(PaS.GetAll());

        }

        public ActionResult IndexFrontPAck()
        {
            return View(PaS.GetAll());

        }

        public ActionResult IndexPacksProds()
        {
            return View("~/Views/PackProducts/Index.cshtml");

        }

        //public ActionResult DetailsPack(int idpack)
        //{
        //    var ProductList = ps.GetProductByPackId(idpack);
        //    ViewBag.Products = new SelectList(ProductList, "IdProduct", "NameProduct");
        //    return View();
        //}

        //public ActionResult Details(int id)
        //{

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pack pack = PaS.GetById(id);
        //    ps.GetProductByPack(pack);

        //    if (pack == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return RedirectToAction("Index1", "Product");
        //}

        // GET: Packs/Create
        public ActionResult Create()
        {
            var ProductList = ps.GetAll();
            ViewBag.Products = new SelectList(ProductList, "IdProduct", "NameProduct");

            return View();
        }

        // POST: Packs/Create
        [HttpPost]
        public ActionResult Create(Pack pack, HttpPostedFileBase file)
        {
            try
            {
                pack.PackImage = file.FileName;
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/uploads/"), file.FileName);
                    file.SaveAs(path);
                }
                PaS.Add(pack);
                PaS.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Packs/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = PaS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Packs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pack p)
        {


            Pack pa = PaS.GetById(p.IdPack);

            pa.PackName = p.PackName;
            pa.PackPrice = p.PackPrice;

            if (ModelState.IsValid)
            {
                PaS.Update(pa);
                PaS.Commit();
                return RedirectToAction("Index");
            }

            return View();

        }

        // GET: Packs/Delete/5

        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = PaS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Pack pack = PaS.GetById(id);
            PaS.Delete(pack);
            PaS.Commit();
            return RedirectToAction("Index");

        }
    }
}
