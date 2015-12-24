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
    public class EntreprisesController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Entreprises
        public ActionResult Index()
        {
            return View(db.Entreprise.ToList());
        }

        // GET: Entreprises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprise.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise);
        }

        // GET: Entreprises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entreprises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntreprise,nom,adr_rue,adr_numero,adr_localite,adr_codePostal,numTel")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                db.Entreprise.Add(entreprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entreprise);
        }

        // GET: Entreprises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprise.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntreprise,nom,adr_rue,adr_numero,adr_localite,adr_codePostal,numTel")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entreprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entreprise);
        }

        // GET: Entreprises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprise.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entreprise entreprise = db.Entreprise.Find(id);
            db.Entreprise.Remove(entreprise);
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
