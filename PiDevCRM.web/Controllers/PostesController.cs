using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using PiDevCRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class PostesController : Controller
    {

        private Context db = new Context();
        PostesService OS;
        CommentService CS;
        ClientService PS;
        public PostesController()
        {
            OS = new PostesService();
            PS = new ClientService();
        }
        // GET: Postes
        public ActionResult Index()
        {
            return View(OS.GetAll());


        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = OS.GetMany();


            // recherche
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.Title.ToString().Contains(filtre)).ToList();
            }

            return View(list);



        }

        // GET: Postes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }





 


        public ActionResult Create()
        {
            return View();
        }

        // POST: Postes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Postes pm)
        {
            if (ModelState.IsValid)
            {
                OS.Add(pm);
                OS.Commit();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }

        // GET: Postes/AddComment/5
        public ActionResult AddComment(int id)
        {
            Postes pack = OS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Postes/Edit/5
        [HttpPost]
        public ActionResult AddComment(Comment c)
        {
            try
            {

                CS.Add(c);
                CS.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Postes/Edit/5
        public ActionResult Edit(int id)
        {
            Postes pack = OS.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Postes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Postes a)
        {
            Postes pa = OS.GetById(a.IdPoste);

            pa.Title = a.Title;
            pa.Content = a.Content;
            pa.PublishDate = a.PublishDate;
           

            if (ModelState.IsValid)
            {
                OS.Update(pa);
                OS.Commit();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Postes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(OS.GetById(id));
        }

        // POST: Postes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Postes a)
        {
            a = OS.GetById(id);
            OS.Delete(a);
            OS.Commit();
            return RedirectToAction("Index");
        }
    }
}
