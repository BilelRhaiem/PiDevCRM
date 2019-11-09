using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class AgentController : Controller
    {
        public AgentService AS;

        public AgentController()
        {
            AS = new AgentService();

        }
        // GET: Agent
        public ActionResult Index()
        {
            return View(AS.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = AS.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.FirstName.ToString().Equals(filtre)).ToList();
            }

            return View(list);



        }

        // GET: Agent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agent/Create
        public ActionResult Create()
        {
            var categories = AS.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "IdProspection", "FirstName");
            return View();
        }

        // POST: Agent/Create
        [HttpPost]
        public ActionResult Create(Agent a)
        {
            AS.Add(a);
            AS.Commit();


            return RedirectToAction("Index");
        }

        // GET: Agent/Edit/5
        public ActionResult Edit(int id)
        {
            Agent pack = AS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Agent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Agent a)
        {
            Agent pa = AS.GetById(a.IdAgent);

            pa.FirstName = a.FirstName;
            pa.LastName = a.LastName;
            pa.PhoneNumber = a.PhoneNumber;
            pa.TypeAgent = a.TypeAgent;

            if (ModelState.IsValid)
            {
                AS.Update(pa);
                AS.Commit();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Agent/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AS.GetById(id));
        }

        // POST: Agent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Agent a)
        {
            a = AS.GetById(id);
            AS.Delete(a);
            AS.Commit();
            return RedirectToAction("Index");
        }
    }
}
