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
    public class Risque_TravSoumisController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Risque_TravSoumis
        public ActionResult Index()
        {
            var risque_TravSoumis = db.Risque_TravSoumis.Include(r => r.Emploi).Include(r => r.Risque);
            return View(risque_TravSoumis.ToList());
        }

        // GET: Risque_TravSoumis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque_TravSoumis risque_TravSoumis = db.Risque_TravSoumis.Find(id);
            if (risque_TravSoumis == null)
            {
                return HttpNotFound();
            }
            return View(risque_TravSoumis);
        }

        // GET: Risque_TravSoumis/Create
        public ActionResult Create()
        {
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession");
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque");
            return View();
        }

        // POST: Risque_TravSoumis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExamenSoumis,idRisque,idEmploi")] Risque_TravSoumis risque_TravSoumis)
        {
            if (ModelState.IsValid)
            {
                db.Risque_TravSoumis.Add(risque_TravSoumis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", risque_TravSoumis.idEmploi);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", risque_TravSoumis.idRisque);
            return View(risque_TravSoumis);
        }

        // GET: Risque_TravSoumis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque_TravSoumis risque_TravSoumis = db.Risque_TravSoumis.Find(id);
            if (risque_TravSoumis == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", risque_TravSoumis.idEmploi);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", risque_TravSoumis.idRisque);
            return View(risque_TravSoumis);
        }

        // POST: Risque_TravSoumis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExamenSoumis,idRisque,idEmploi")] Risque_TravSoumis risque_TravSoumis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risque_TravSoumis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmploi = new SelectList(db.Emploi, "idEmploi", "idProfession", risque_TravSoumis.idEmploi);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", risque_TravSoumis.idRisque);
            return View(risque_TravSoumis);
        }

        // GET: Risque_TravSoumis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque_TravSoumis risque_TravSoumis = db.Risque_TravSoumis.Find(id);
            if (risque_TravSoumis == null)
            {
                return HttpNotFound();
            }
            return View(risque_TravSoumis);
        }

        // POST: Risque_TravSoumis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risque_TravSoumis risque_TravSoumis = db.Risque_TravSoumis.Find(id);
            db.Risque_TravSoumis.Remove(risque_TravSoumis);
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
