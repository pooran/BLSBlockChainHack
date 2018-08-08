using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfertaDeFarmacia.Models;

namespace OfertaDeFarmacia.Controllers
{
    public class PrescripcionsController : Controller
    {
        private bslhackEntities db = new bslhackEntities();

        // GET: Prescripcions
        public ActionResult Index()
        {
            var prescripcions = db.Prescripcions.Include(p => p.Paciente);
            return View(prescripcions.ToList());
        }

        // GET: Prescripcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescripcion prescripcion = db.Prescripcions.Find(id);
            if (prescripcion == null)
            {
                return HttpNotFound();
            }
            return View(prescripcion);
        }

        // GET: Prescripcions/Create
        public ActionResult Create()
        {
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "PacienteId");
            return View();
        }

        // POST: Prescripcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,PacienteId,FechaDeCreacion,FechaModificada,EstaActivo")] Prescripcion prescripcion)
        {
            if (ModelState.IsValid)
            {
                db.Prescripcions.Add(prescripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "PacienteId", prescripcion.PacienteId);
            return View(prescripcion);
        }

        // GET: Prescripcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescripcion prescripcion = db.Prescripcions.Find(id);
            if (prescripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "PacienteId", prescripcion.PacienteId);
            return View(prescripcion);
        }

        // POST: Prescripcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,PacienteId,FechaDeCreacion,FechaModificada,EstaActivo")] Prescripcion prescripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "PacienteId", prescripcion.PacienteId);
            return View(prescripcion);
        }

        // GET: Prescripcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescripcion prescripcion = db.Prescripcions.Find(id);
            if (prescripcion == null)
            {
                return HttpNotFound();
            }
            return View(prescripcion);
        }

        // POST: Prescripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescripcion prescripcion = db.Prescripcions.Find(id);
            db.Prescripcions.Remove(prescripcion);
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
