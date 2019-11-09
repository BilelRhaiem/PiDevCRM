
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class ClaimController : Controller
    {
        ClaimService Cs;

       public ClaimController()
        {
            Cs = new ClaimService();

        }
        // GET: Claim
        public ActionResult Index()
        {
            return View(Cs.GetMany());
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {

            Claims c = Cs.GetById(id);
            if (c == null)
            {

                return HttpNotFound();

            }

            return View(c);

        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            
           
            return View();
        }

        // POST: Claim/Create
        //[HttpPost, ValidateInput(false)]
         [HttpPost, ValidateInput(false)]
        public ActionResult Create(Claims c)
        {
            try
            {
                // TODO: Add insert logic here
                Cs.Add(c);
                Cs.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            Claims c = Cs. GetById(id);

            if (c==null)
            {
                return HttpNotFound();
            }
            return View(c);
           
        }

        // POST: Claim/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit( Claims c)
        {
            Claims c1 = Cs.GetById(c.IdClaims);
            c1.Description = c.Description;
            c1.ClaimDate = c.ClaimDate;
            c1.typeClaims = c.typeClaims;
            if (ModelState.IsValid)
            {
                Cs.Update(c1);
                Cs.Commit();

                return RedirectToAction("Index");

            }
            
            return RedirectToAction("Index");
        }

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Cs.GetById(id));
        }

        // POST: Claim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Claims c)
        {

            // TODO: Add delete logic here
            c = Cs.GetById(id);
            Cs.Delete(c);
            Cs.Commit();
            return RedirectToAction("Index");

            
        }
    }
}
