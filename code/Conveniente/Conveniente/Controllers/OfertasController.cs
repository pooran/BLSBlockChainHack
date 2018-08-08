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
    public class OfertasController : Controller
    {
        private bslhackEntities db = new bslhackEntities();

        // GET: Ofertas
        public ActionResult Index()
        {
            var ofertas = db.Ofertas.Include(o => o.Farmacia).Include(o => o.Prescripcion).Include(o => o.Seguro);
            return View(ofertas.ToList());
        }

        // GET: Ofertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // GET: Ofertas/Create
        public ActionResult Create()
        {
            ViewBag.FarmaciaId = new SelectList(db.Farmacias, "Id", "Nombre");
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id");
            ViewBag.SeguroId = new SelectList(db.Seguroes, "Id", "Nombre");
            return View();
        }

        // POST: Ofertas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FarmaciaId,UsusarioId,PrescripcionId,EstaActivo,Total,SeguroId,EsAceptado,EsRecogido")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Ofertas.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmaciaId = new SelectList(db.Farmacias, "Id", "Nombre", oferta.FarmaciaId);
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", oferta.PrescripcionId);
            ViewBag.SeguroId = new SelectList(db.Seguroes, "Id", "Nombre", oferta.SeguroId);
            return View(oferta);
        }

        // GET: Ofertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmaciaId = new SelectList(db.Farmacias, "Id", "Nombre", oferta.FarmaciaId);
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", oferta.PrescripcionId);
            ViewBag.SeguroId = new SelectList(db.Seguroes, "Id", "Nombre", oferta.SeguroId);
            return View(oferta);
        }

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FarmaciaId,UsusarioId,PrescripcionId,EstaActivo,Total,SeguroId,EsAceptado,EsRecogido")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmaciaId = new SelectList(db.Farmacias, "Id", "Nombre", oferta.FarmaciaId);
            ViewBag.PrescripcionId = new SelectList(db.Prescripcions, "Id", "Id", oferta.PrescripcionId);
            ViewBag.SeguroId = new SelectList(db.Seguroes, "Id", "Nombre", oferta.SeguroId);
            return View(oferta);
        }

        // GET: Ofertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        // POST: Ofertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.Ofertas.Find(id);
            db.Ofertas.Remove(oferta);
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
