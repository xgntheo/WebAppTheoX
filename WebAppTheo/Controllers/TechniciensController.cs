using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppTheo.Models;

namespace WebAppTheo.Controllers
{
    public class TechniciensController : Controller
    {
        private DevTestTXEntities1 db = new DevTestTXEntities1();

        // GET: Techniciens
        public ActionResult Index()
        {
            return View(db.Technicien.ToList());
        }

        // GET: Techniciens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technicien technicien = db.Technicien.Find(id);
            if (technicien == null)
            {
                return HttpNotFound();
            }
            return View(technicien);
        }

        // GET: Techniciens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Techniciens/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTech,NomTechn")] Technicien technicien)
        {
            if (ModelState.IsValid)
            {
                db.Technicien.Add(technicien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicien);
        }

        // GET: Techniciens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technicien technicien = db.Technicien.Find(id);
            if (technicien == null)
            {
                return HttpNotFound();
            }
            return View(technicien);
        }

        // POST: Techniciens/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTech,NomTechn")] Technicien technicien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technicien);
        }

        // GET: Techniciens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technicien technicien = db.Technicien.Find(id);
            if (technicien == null)
            {
                return HttpNotFound();
            }
            return View(technicien);
        }

        // POST: Techniciens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technicien technicien = db.Technicien.Find(id);
            db.Technicien.Remove(technicien);
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
