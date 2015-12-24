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
    public class ExamenParticuliersController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: ExamenParticuliers
        public ActionResult Index()
        {
            var examenParticulier = db.ExamenParticulier.Include(e => e.Emploi).Include(e => e.Examen);
            return View(examenParticulier.ToList());
        }

        // GET: ExamenParticuliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenParticulier examenParticulier = db.ExamenParticulier.Find(id);
            if (examenParticulier == null)
            {
                return HttpNotFound();
            }
            return View(examenParticulier);
        }

        // GET: ExamenParticuliers/Create
        public ActionResult Create()
        {
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession");
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen");
            return View();
        }

        // POST: ExamenParticuliers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExamenParticulier,idExamen,idEmploi")] ExamenParticulier examenParticulier)
        {
            if (ModelState.IsValid)
            {
                db.ExamenParticulier.Add(examenParticulier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", examenParticulier.idEmploi);
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", examenParticulier.idExamen);
            return View(examenParticulier);
        }

        // GET: ExamenParticuliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenParticulier examenParticulier = db.ExamenParticulier.Find(id);
            if (examenParticulier == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", examenParticulier.idEmploi);
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", examenParticulier.idExamen);
            return View(examenParticulier);
        }

        // POST: ExamenParticuliers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExamenParticulier,idExamen,idEmploi")] ExamenParticulier examenParticulier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenParticulier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", examenParticulier.idEmploi);
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", examenParticulier.idExamen);
            return View(examenParticulier);
        }

        // GET: ExamenParticuliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamenParticulier examenParticulier = db.ExamenParticulier.Find(id);
            if (examenParticulier == null)
            {
                return HttpNotFound();
            }
            return View(examenParticulier);
        }

        // POST: ExamenParticuliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamenParticulier examenParticulier = db.ExamenParticulier.Find(id);
            db.ExamenParticulier.Remove(examenParticulier);
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
