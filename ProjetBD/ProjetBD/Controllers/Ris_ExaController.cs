using System;
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
    public class Ris_ExaController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Ris_Exa
        public ActionResult Index()
        {
            var ris_Exa = db.Ris_Exa.Include(r => r.Examen).Include(r => r.Risque);
            return View(ris_Exa.ToList());
        }

        // GET: Ris_Exa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ris_Exa ris_Exa = db.Ris_Exa.Find(id);
            if (ris_Exa == null)
            {
                return HttpNotFound();
            }
            return View(ris_Exa);
        }

        // GET: Ris_Exa/Create
        public ActionResult Create()
        {
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen");
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque");
            return View();
        }

        // POST: Ris_Exa/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRisqueExamen,idRisque,idExamen")] Ris_Exa ris_Exa)
        {
            if (ModelState.IsValid)
            {
                db.Ris_Exa.Add(ris_Exa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", ris_Exa.idExamen);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", ris_Exa.idRisque);
            return View(ris_Exa);
        }

        // GET: Ris_Exa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ris_Exa ris_Exa = db.Ris_Exa.Find(id);
            if (ris_Exa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", ris_Exa.idExamen);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", ris_Exa.idRisque);
            return View(ris_Exa);
        }

        // POST: Ris_Exa/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRisqueExamen,idRisque,idExamen")] Ris_Exa ris_Exa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ris_Exa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", ris_Exa.idExamen);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", ris_Exa.idRisque);
            return View(ris_Exa);
        }

        // GET: Ris_Exa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ris_Exa ris_Exa = db.Ris_Exa.Find(id);
            if (ris_Exa == null)
            {
                return HttpNotFound();
            }
            return View(ris_Exa);
        }

        // POST: Ris_Exa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ris_Exa ris_Exa = db.Ris_Exa.Find(id);
            db.Ris_Exa.Remove(ris_Exa);
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
