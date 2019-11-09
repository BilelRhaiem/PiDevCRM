using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using PiDevCRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class ProspectionController : Controller
    {

        public ProspectionService PaS;
      
        public ProspectionController()
        {
            PaS = new ProspectionService();
           
        }
        // GET: Prospection
        public ActionResult Index()
        {
            return View(PaS.GetAll());
        }

        // GET: Prospection/Details/5
        public ActionResult Details(int id)
        {
            return View(PaS.GetById(id));
        }

        // GET: Prospection/Create
        public ActionResult Create()
        {
            var categories = PaS.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "VilleId", "nom");
            return View();
        }

        // POST: Prospection/Create
        [HttpPost]
        public ActionResult Create(Prospection collection)
        {
            try
            {

                PaS.Add(collection);
                PaS.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prospection/Edit/5
        public ActionResult Edit(int id)
        {
          
            Prospection pack = PaS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Prospection/Edit/5
        [HttpPost]
        public ActionResult Edit(Prospection p)
        {
            Prospection pa = PaS.GetById(p.IdProspection);

            pa.TypeProspection = p.TypeProspection;
            pa.Location = p.Location;

            if (ModelState.IsValid)
            {
                PaS.Update(pa);
                PaS.Commit();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Prospection/Delete/5
        public ActionResult Delete(int id)
        {
            return View(PaS.GetById(id));
        }

        // POST: Prospection/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Prospection p)
        {
            p = PaS.GetById(id);
            PaS.Delete(p);
            PaS.Commit();
            return RedirectToAction("Index");
        }

        public async System.Threading.Tasks.Task<ActionResult> ConsumeExternalAPI()
        {
  
            return View();
        }
        private PiDevCRMContexte db = new PiDevCRMContexte();

        // GET: ProspectionAgent
        public ActionResult DetailProspection(Prospection pack, Agent prod)
        {

            var mymodel = new ProspectionModele();
            mymodel.ListAgent = db.Agent.ToList();
            mymodel.ListProspection = db.Prospection.ToList();

            return View(mymodel);
        }
    }
}
