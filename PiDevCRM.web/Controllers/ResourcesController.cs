using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class ResourcesController : Controller
    {

        public RessourcesService RS;

        public ResourcesController()
        {
            RS = new RessourcesService();

        }
        // GET: Resources
        public ActionResult Index()
        {
            return View(RS.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = RS.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.TypeResource.ToString().Equals(filtre)).ToList();
            }

            return View(list);



        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            var categories = RS.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "IdProspection", "FirstName");
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult Create(Resources r)
        {
            RS.Add(r);
            RS.Commit();
           
           
            return RedirectToAction("Index");
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RS.GetById(id));
        }

        // POST: Resources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Resources r)
        {
            
                // TODO: Add update logic here
                r = RS.GetById(id);
                RS.Update(r);
                RS.Commit();
                return RedirectToAction("Index");
            
                
            
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RS.GetById(id));
        }

        // POST: Resources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Resources r)
        {
            r = RS.GetById(id);
            RS.Delete(r);
            RS.Commit();
            return RedirectToAction("Index");
        }
    }
}
