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
    public class NombreMedicinasController : Controller
    {
        private bslhackEntities db = new bslhackEntities();

        // GET: NombreMedicinas
        public ActionResult Index()
        {
            var nombreMedicinas = db.NombreMedicinas.Include(n => n.Medicina).Include(n => n.Oferta);
            return View(nombreMedicinas.ToList());
        }

        // GET: NombreMedicinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreMedicina nombreMedicina = db.NombreMedicinas.Find(id);
            if (nombreMedicina == null)
            {
                return HttpNotFound();
            }
            return View(nombreMedicina);
        }

        // GET: NombreMedicinas/Create
        public ActionResult Create()
        {
            ViewBag.MedicinaId = new SelectList(db.Medicinas, "Id", "NombreMedicamento");
            ViewBag.OfertaId = new SelectList(db.Ofertas, "Id", "EstaActivo");
            return View();
        }

        // POST: NombreMedicinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OfertaId,MedicinaId,Marca,EstaActivo,Costo")] NombreMedicina nombreMedicina)
        {
            if (ModelState.IsValid)
            {
                db.NombreMedicinas.Add(nombreMedicina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicinaId = new SelectList(db.Medicinas, "Id", "NombreMedicamento", nombreMedicina.MedicinaId);
            ViewBag.OfertaId = new SelectList(db.Ofertas, "Id", "EstaActivo", nombreMedicina.OfertaId);
            return View(nombreMedicina);
        }

        // GET: NombreMedicinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreMedicina nombreMedicina = db.NombreMedicinas.Find(id);
            if (nombreMedicina == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicinaId = new SelectList(db.Medicinas, "Id", "NombreMedicamento", nombreMedicina.MedicinaId);
            ViewBag.OfertaId = new SelectList(db.Ofertas, "Id", "EstaActivo", nombreMedicina.OfertaId);
            return View(nombreMedicina);
        }

        // POST: NombreMedicinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OfertaId,MedicinaId,Marca,EstaActivo,Costo")] NombreMedicina nombreMedicina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nombreMedicina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicinaId = new SelectList(db.Medicinas, "Id", "NombreMedicamento", nombreMedicina.MedicinaId);
            ViewBag.OfertaId = new SelectList(db.Ofertas, "Id", "EstaActivo", nombreMedicina.OfertaId);
            return View(nombreMedicina);
        }

        // GET: NombreMedicinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreMedicina nombreMedicina = db.NombreMedicinas.Find(id);
            if (nombreMedicina == null)
            {
                return HttpNotFound();
            }
            return View(nombreMedicina);
        }

        // POST: NombreMedicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NombreMedicina nombreMedicina = db.NombreMedicinas.Find(id);
            db.NombreMedicinas.Remove(nombreMedicina);
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
