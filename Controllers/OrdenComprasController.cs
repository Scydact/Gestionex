using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestionex.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Gestionex.Controllers
{
    public class OrdenComprasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: OrdenCompras
        public ActionResult Index()
        {
            var ordenCompras = db.OrdenCompras.Include(o => o.SolicitudArticulo);
            return View(ordenCompras.ToList());
        }

        // GET: OrdenCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public ActionResult Create()
        {
            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Id");
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroOrden,Fecha,Estado,Cantidad,CostoUnitario,SolicitudArticulosId")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenCompras.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Id", ordenCompra.SolicitudArticulosId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Id", ordenCompra.SolicitudArticulosId);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroOrden,Fecha,Estado,Cantidad,CostoUnitario,SolicitudArticulosId")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Id", ordenCompra.SolicitudArticulosId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordenCompra = db.OrdenCompras.Find(id);
            db.OrdenCompras.Remove(ordenCompra);
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
