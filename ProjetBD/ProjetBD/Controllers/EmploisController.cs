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
    public class EmploisController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: Emplois
        public ActionResult Index()
        {
            var emploi = db.Emploi.Include(e => e.Entreprise).Include(e => e.Profession).Include(e => e.Travailleur);
            return View(emploi.ToList());
        }

        // GET: Emplois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emploi.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }

            List<Risque_TravSoumis> risquesIds = db.Risque_TravSoumis.Where(r => r.idEmploi == emploi.idEmploi).ToList();
            List<string> txt = new List<string>();
            foreach (var item in risquesIds)
            {
                txt.Add(db.Lan_Risque.First(l => l.idRisque == item.idRisque && l.idLangue == 1).texte);
            }
            emploi.LabelsRisques = new SelectList(txt);

            List<ExamenParticulier> exaIds = db.ExamenParticulier.Where(e => e.idEmploi == emploi.idEmploi).ToList();
            txt = new List<string>();
            foreach (var item in exaIds)
            {
                txt.Add(db.Lan_Exa.First(l => l.idExamen == item.idExamen && l.idLangue == 1).texte);
            }
            emploi.LabelsExamens = new SelectList(txt);

            return View(emploi);
        }

        // GET: Emplois/Create
        public ActionResult Create()
        {
            ViewBag.idEntreprise = new SelectList(db.Entreprise, "idEntreprise", "nom");
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession");
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom");
            return View();
        }

        // POST: Emplois/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmploi,dateEntree,idTravailleur,idEntreprise,dateSortie,type,idProfession")] Emploi emploi)
        {
            if (ModelState.IsValid)
            {
                db.Emploi.Add(emploi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntreprise = new SelectList(db.Entreprise, "idEntreprise", "nom", emploi.idEntreprise);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", emploi.idProfession);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", emploi.idTravailleur);
            return View(emploi);
        }

        // GET: Emplois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emploi.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntreprise = new SelectList(db.Entreprise, "idEntreprise", "nom", emploi.idEntreprise);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", emploi.idProfession);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", emploi.idTravailleur);
            return View(emploi);
        }

        // POST: Emplois/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmploi,dateEntree,idTravailleur,idEntreprise,dateSortie,type,idProfession")] Emploi emploi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emploi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntreprise = new SelectList(db.Entreprise, "idEntreprise", "nom", emploi.idEntreprise);
            ViewBag.idProfession = new SelectList(db.Profession, "idProfession", "idProfession", emploi.idProfession);
            ViewBag.idTravailleur = new SelectList(db.Travailleur, "idTravailleur", "nom", emploi.idTravailleur);
            return View(emploi);
        }

        // GET: Emplois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emploi emploi = db.Emploi.Find(id);
            if (emploi == null)
            {
                return HttpNotFound();
            }
            return View(emploi);
        }

        // POST: Emplois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emploi emploi = db.Emploi.Find(id);
            db.Emploi.Remove(emploi);
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
