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
    public class MarcasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Marcas
        public ActionResult Index()
        {
            var marcas = db.Marcas.Include(m => m.Proveedor);
            return View(marcas.ToList());
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        // GET: Marcas/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ProveedoresId = new SelectList(db.Proveedores, "Id", "NombreComercial");
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,ProveedoresId,Estado")] Marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.Marcas.Add(marcas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProveedoresId = new SelectList(db.Proveedores, "Id", "NombreComercial", marcas.ProveedoresId);
            return View(marcas);
        }

        // GET: Marcas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedoresId = new SelectList(db.Proveedores, "Id", "NombreComercial", marcas.ProveedoresId);
            return View(marcas);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,ProveedoresId,Estado")] Marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedoresId = new SelectList(db.Proveedores, "Id", "NombreComercial", marcas.ProveedoresId);
            return View(marcas);
        }

        // GET: Marcas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marcas marcas = db.Marcas.Find(id);
            db.Marcas.Remove(marcas);
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
