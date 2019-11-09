﻿using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Controllers
{
    public class StockController : Controller
    {
        public StockService ST;
        public StockController()
        {
            ST = new StockService();
        }


        // GET: Stock
        public ActionResult Index()
        {
            return View(ST.GetAll());
        }

        // GET: Stock/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Stock/Create
        [HttpPost]
        public ActionResult Create(Stock st)
        {
            ST.Add(st);
            ST.Commit();
            return RedirectToAction("Index");
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stock/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
