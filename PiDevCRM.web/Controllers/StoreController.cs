using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{


    public class StoreController : Controller
    {
        public StoreService SS;
        public StoreController()
        {
            SS = new StoreService();
        }
        // GET: Store
        public ActionResult Index()
        {
            return View(SS.GetAll());
        }

        public ActionResult IndexBack()
        {
            return View(SS.GetAll());
        }
        public ActionResult Map()
        {
            return View(SS.GetAll());
        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = SS.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.NameStore.ToString().Equals(filtre)).ToList();
            }

            return View(list);



        }
        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View(SS.GetById(id));
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Store s)
        {
            SS.Add(s);
            SS.Commit();
            return RedirectToAction("IndexBack");
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            Store s = SS.GetById(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(Store S)
        {
            Store s1 = SS.GetById(S.IdStore);
            s1.NameStore = S.NameStore;
            s1.ouverture = S.ouverture;
            s1.Tel = S.Tel;
            s1.Email = S.Email;
            s1.Adresse = S.Adresse;
            if (ModelState.IsValid)
            {
                SS.Update(s1);
                SS.Commit();
                return RedirectToAction("IndexBack");
            }
            return RedirectToAction("IndexBack");
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View(SS.GetById(id));
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Store S)
        {
            S = SS.GetById(id);
            SS.Delete(S);
            SS.Commit();
            return RedirectToAction("IndexBack");
        }
    }
}
