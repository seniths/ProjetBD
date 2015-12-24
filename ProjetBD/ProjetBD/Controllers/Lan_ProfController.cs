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
    public class Lan_ProfController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Lan_Prof
        public ActionResult Index()
        {
            var lan_Prof = db.Lan_Prof.Include(l => l.Langue).Include(l => l.Profession);
            return View(lan_Prof.ToList());
        }

        // GET: Lan_Prof/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Prof lan_Prof = db.Lan_Prof.Find(id);
            if (lan_Prof == null)
            {
                return HttpNotFound();
            }
            return View(lan_Prof);
        }

        // GET: Lan_Prof/Create
        public ActionResult Create()
        {
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle");
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession");
            return View();
        }

        // POST: Lan_Prof/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLangueProf,texte,idProfession,idLangue")] Lan_Prof lan_Prof)
        {
            if (ModelState.IsValid)
            {
                db.Lan_Prof.Add(lan_Prof);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Prof.idLangue);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", lan_Prof.idProfession);
            return View(lan_Prof);
        }

        // GET: Lan_Prof/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Prof lan_Prof = db.Lan_Prof.Find(id);
            if (lan_Prof == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Prof.idLangue);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", lan_Prof.idProfession);
            return View(lan_Prof);
        }

        // POST: Lan_Prof/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLangueProf,texte,idProfession,idLangue")] Lan_Prof lan_Prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lan_Prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLangue = new SelectList(db.Langue, "idLangue", "libelle", lan_Prof.idLangue);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", lan_Prof.idProfession);
            return View(lan_Prof);
        }

        // GET: Lan_Prof/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan_Prof lan_Prof = db.Lan_Prof.Find(id);
            if (lan_Prof == null)
            {
                return HttpNotFound();
            }
            return View(lan_Prof);
        }

        // POST: Lan_Prof/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lan_Prof lan_Prof = db.Lan_Prof.Find(id);
            db.Lan_Prof.Remove(lan_Prof);
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
