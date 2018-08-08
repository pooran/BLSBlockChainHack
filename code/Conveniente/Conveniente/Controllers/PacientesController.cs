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
    public class PacientesController : Controller
    {
        private bslhackEntities db = new bslhackEntities();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Clinica).Include(p => p.Usuario);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.ClinicId = new SelectList(db.Clinicas, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "RUT");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,ClinicId,Clave,FechaDeCreacion,FechaModificada,EstaActivo,PacienteId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClinicId = new SelectList(db.Clinicas, "Id", "Nombre", paciente.ClinicId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "RUT", paciente.UsuarioId);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClinicId = new SelectList(db.Clinicas, "Id", "Nombre", paciente.ClinicId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "RUT", paciente.UsuarioId);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,ClinicId,Clave,FechaDeCreacion,FechaModificada,EstaActivo,PacienteId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClinicId = new SelectList(db.Clinicas, "Id", "Nombre", paciente.ClinicId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "RUT", paciente.UsuarioId);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
