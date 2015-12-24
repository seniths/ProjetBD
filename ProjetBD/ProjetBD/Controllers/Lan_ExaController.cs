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
    public class Lan_ExaController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Lan_Exa
        public ActionResult Index()
        {
            var lan_Exa = db.Lan_Exa.Include(l => l.Examen).Include(l => l.Langue);
            return View(lan_Exa.ToList());
        }

        // GET: Lan_Exa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Exa lan_Exa = db.Lan_Exa.Find(id);
            if (lan_Exa == null)
            {
                return HttpNotFound();
            }
            return View(lan_Exa);
        }

        // GET: Lan_Exa/Create
        public ActionResult Create()
        {
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen");
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle");
            return View();
        }

        // POST: Lan_Exa/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLangueExamen,texte,idLangue,idExamen")] Lan_Exa lan_Exa)
        {
            if (ModelState.IsValid)
            {
                db.Lan_Exa.Add(lan_Exa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", lan_Exa.idExamen);
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Exa.idLangue);
            return View(lan_Exa);
        }

        // GET: Lan_Exa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Exa lan_Exa = db.Lan_Exa.Find(id);
            if (lan_Exa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", lan_Exa.idExamen);
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Exa.idLangue);
            return View(lan_Exa);
        }

        // POST: Lan_Exa/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLangueExamen,texte,idLangue,idExamen")] Lan_Exa lan_Exa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lan_Exa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idExamen = new SelectList(db.Examen, "idExamen", "idExamen", lan_Exa.idExamen);
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Exa.idLangue);
            return View(lan_Exa);
        }

        // GET: Lan_Exa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Exa lan_Exa = db.Lan_Exa.Find(id);
            if (lan_Exa == null)
            {
                return HttpNotFound();
            }
            return View(lan_Exa);
        }

        // POST: Lan_Exa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lan_Exa lan_Exa = db.Lan_Exa.Find(id);
            db.Lan_Exa.Remove(lan_Exa);
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
