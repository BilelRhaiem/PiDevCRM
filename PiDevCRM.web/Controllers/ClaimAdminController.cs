using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class ClaimAdminController : Controller
    {
        ClaimService Cs;
        public ClaimAdminController()
        {
            Cs = new ClaimService();

        }
        // GET: ClaimAdmin
        public ActionResult Index()
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
            ViewBag.totale = Cs.NbrRec();
>>>>>>> Stashed changes
=======
            ViewBag.totale = Cs.NbrRec();
>>>>>>> Stashed changes
            return View(Cs.GetMany());
        }

        // GET: ClaimAdmin/Details/5
        public ActionResult Details(int id)
        {
            Claims c = Cs.GetById(id);
            if (c == null)
            {

                return HttpNotFound();

            }

            return View(c);
        }

        // GET: ClaimAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaimAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaimAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            Claims c = Cs.GetById(id);

            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: ClaimAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Claims c)
        {
            Claims c1 = Cs.GetById(c.IdClaims);
            c1.Answer = c.Answer;
            c1.statustype = c.statustype;
            
            if (ModelState.IsValid)
            {
                Cs.Update(c1);
                Cs.Commit();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        // GET: ClaimAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Cs.GetById(id));
        }

        // POST: ClaimAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Claims c)
        {
            // TODO: Add delete logic here
            c = Cs.GetById(id);
            Cs.Delete(c);
            Cs.Commit();
            return RedirectToAction("Index");

        }

        // GET: ClaimAdmin/EmailSetup
        public ActionResult EmailSetup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailSetup(PiDevCRM.Domain.Entities.gmail model)
        {
            MailMessage mm = new MailMessage("maram.mtir@esprit.tn", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("maram.mtir@esprit.tn", "MaramNaceurMtir12");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been send successfully !!";


            return View();
        }

        public ActionResult Reply(int id)
        {
            Claims c = Cs.GetById(id);

            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        // POST: ClaimAdmin/Reply
        [HttpPost]
        public ActionResult Reply(Claims c)
        {
            Claims c1 = Cs.GetById(c.IdClaims);
            c1.Answer = c.Answer;
            c1.statustype = c.statustype;

            if (ModelState.IsValid)
            {
                Cs.Update(c1);
                Cs.Commit();

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
                var verifyurl = "/Signup/VerifiyAccount/";
                var link = Request.Url.AbsolutePath.Replace(Request.Url.PathAndQuery, verifyurl);

                var fromEmail = new MailAddress("maram.mtir@esprit.tn", "maram mtir");
                var toEmail = new MailAddress("takwa.hammedi@esprit.tn");
                var FromEmailPassword = "MaramNaceurMtir12";

                string subject = "Validation Job";

                string body = "Congratulations you are  assigned to work in our prospecting point " +
                    "<br/><a href = '" + link + "'>" + link + "</a>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, FromEmailPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                }) smtp.Send(message);

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        public ActionResult Dashboard()
        {
            var list = Cs.GetAll();
            List<int> repartitions = new List<int>();
            var typeC = list.Select(x => x.typeClaims).Distinct();

            foreach(var item in typeC)
            {
                repartitions.Add(list.Count(x => x.typeClaims == item));

            }
            var rep = repartitions;
            ViewBag.TYPEC = typeC;
            ViewBag.REP = repartitions.ToList();

            return View();
        }

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    }
}
