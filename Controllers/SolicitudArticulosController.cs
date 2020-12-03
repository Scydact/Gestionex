using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestionex.Models;

namespace Gestionex.Controllers
{
    public class SolicitudArticulosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: SolicitudArticulos
        public ActionResult Index()
        {
            var solicitudArticulos = db.SolicitudArticulos.Include(s => s.Articulo).Include(s => s.Empleado);
            return View(solicitudArticulos.ToList());
        }

        // GET: SolicitudArticulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulos solicitudArticulos = db.SolicitudArticulos.Find(id);
            if (solicitudArticulos == null)
            {
                return HttpNotFound();
            }
            return View(solicitudArticulos);
        }

        // GET: SolicitudArticulos/Create
        public ActionResult Create()
        {
            ViewBag.ArticulosId = new SelectList(db.Articulos, "Id", "Nombre");
            ViewBag.EmpleadosId = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: SolicitudArticulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Cantidad,ArticulosId,EmpleadosId,Estado")] SolicitudArticulos solicitudArticulos)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudArticulos.Add(solicitudArticulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticulosId = new SelectList(db.Articulos, "Id", "Nombre", solicitudArticulos.ArticulosId);
            ViewBag.EmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", solicitudArticulos.EmpleadosId);
            return View(solicitudArticulos);
        }

        // GET: SolicitudArticulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulos solicitudArticulos = db.SolicitudArticulos.Find(id);
            if (solicitudArticulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticulosId = new SelectList(db.Articulos, "Id", "Nombre", solicitudArticulos.ArticulosId);
            ViewBag.EmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", solicitudArticulos.EmpleadosId);
            return View(solicitudArticulos);
        }

        // POST: SolicitudArticulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Cantidad,ArticulosId,EmpleadosId,Estado")] SolicitudArticulos solicitudArticulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudArticulos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticulosId = new SelectList(db.Articulos, "Id", "Nombre", solicitudArticulos.ArticulosId);
            ViewBag.EmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", solicitudArticulos.EmpleadosId);
            return View(solicitudArticulos);
        }

        // GET: SolicitudArticulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudArticulos solicitudArticulos = db.SolicitudArticulos.Find(id);
            if (solicitudArticulos == null)
            {
                return HttpNotFound();
            }
            return View(solicitudArticulos);
        }

        // POST: SolicitudArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudArticulos solicitudArticulos = db.SolicitudArticulos.Find(id);
            db.SolicitudArticulos.Remove(solicitudArticulos);
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
