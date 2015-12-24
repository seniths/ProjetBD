﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetBD;

namespace ProjetBD.Controllers
{
    public class LanguesController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Langues
        public ActionResult Index()
        {
            return View(db.Langue.ToList());
        }

        // GET: Langues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langue.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // GET: Langues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Langues/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLangue,libelle")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                db.Langue.Add(langue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(langue);
        }

        // GET: Langues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langue.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // POST: Langues/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLangue,libelle")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(langue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(langue);
        }

        // GET: Langues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langue.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // POST: Langues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Langue langue = db.Langue.Find(id);
            db.Langue.Remove(langue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
