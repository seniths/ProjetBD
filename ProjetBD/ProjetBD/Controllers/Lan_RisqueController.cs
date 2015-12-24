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
    public class Lan_RisqueController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Lan_Risque
        public ActionResult Index()
        {
            var lan_Risque = db.Lan_Risque.Include(l => l.Langue).Include(l => l.Risque);
            return View(lan_Risque.ToList());
        }

        // GET: Lan_Risque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Risque lan_Risque = db.Lan_Risque.Find(id);
            if (lan_Risque == null)
            {
                return HttpNotFound();
            }
            return View(lan_Risque);
        }

        // GET: Lan_Risque/Create
        public ActionResult Create()
        {
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle");
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque");
            return View();
        }

        // POST: Lan_Risque/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLangueRisque,texte,idRisque,idLangue")] Lan_Risque lan_Risque)
        {
            if (ModelState.IsValid)
            {
                db.Lan_Risque.Add(lan_Risque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Risque.idLangue);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", lan_Risque.idRisque);
            return View(lan_Risque);
        }

        // GET: Lan_Risque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Risque lan_Risque = db.Lan_Risque.Find(id);
            if (lan_Risque == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Risque.idLangue);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", lan_Risque.idRisque);
            return View(lan_Risque);
        }

        // POST: Lan_Risque/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLangueRisque,texte,idRisque,idLangue")] Lan_Risque lan_Risque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lan_Risque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Risque.idLangue);
            ViewBag.idRisque = new SelectList(db.Risque, "idRisque", "idRisque", lan_Risque.idRisque);
            return View(lan_Risque);
        }

        // GET: Lan_Risque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Risque lan_Risque = db.Lan_Risque.Find(id);
            if (lan_Risque == null)
            {
                return HttpNotFound();
            }
            return View(lan_Risque);
        }

        // POST: Lan_Risque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lan_Risque lan_Risque = db.Lan_Risque.Find(id);
            db.Lan_Risque.Remove(lan_Risque);
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
