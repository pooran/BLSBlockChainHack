using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conveniente.Models;

namespace Conveniente.Controllers
{
    public class MedicinasController : Controller
    {
        private bslhackEntities db = new bslhackEntities();

        // GET: Medicinas
        public ActionResult Index()
        {
            var medicinas = db.Medicinas.Include(m => m.Prescripcion);
            return View(medicinas.ToList());
        }

        // GET: Medicinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // GET: Medicinas/Create
        public ActionResult Create()
        {
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id");
            return View();
        }

        // POST: Medicinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrescripcionId,NombreMedicamento,Dosis,Unidad,Cada,UnidadTiempo,CantidadDias,FechaDeCreacion,FechaModificada,EstaActivo")] Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Medicinas.Add(medicina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", medicina.PrescripcionId);
            return View(medicina);
        }

        // GET: Medicinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", medicina.PrescripcionId);
            return View(medicina);
        }

        // POST: Medicinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrescripcionId,NombreMedicamento,Dosis,Unidad,Cada,UnidadTiempo,CantidadDias,FechaDeCreacion,FechaModificada,EstaActivo")] Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", medicina.PrescripcionId);
            return View(medicina);
        }

        // GET: Medicinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // POST: Medicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            db.Medicinas.Remove(medicina);
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
