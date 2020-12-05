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
    public class ArticulosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Articulos
        public ActionResult Index(string Criterio = null)
        {
            //var articulos = db.Articulos.Include(a => a.UnidadMedida).Include(a => a.Marca);
            var articulos = db.Articulos
                .Where(p => Criterio == null 
                || p.Nombre.Contains(Criterio) 
                || p.Marca.Nombre.Contains(Criterio) 
                || p.Descripcion.Contains(Criterio)
            );
            ViewBag.Criterio = Criterio;
            return View(articulos.ToList());
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: Articulos/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UnidadMedidaId = new SelectList(db.UnidadMedidas, "Id", "Nombre");
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Existencia,Estado,Descripcion,UnidadMedidaId,MarcasId")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadMedidaId = new SelectList(db.UnidadMedidas, "Id", "Nombre", articulos.UnidadMedidaId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nombre", articulos.MarcasId);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadMedidaId = new SelectList(db.UnidadMedidas, "Id", "Nombre", articulos.UnidadMedidaId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nombre", articulos.MarcasId);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Existencia,Estado,Descripcion,UnidadMedidaId,MarcasId")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadMedidaId = new SelectList(db.UnidadMedidas, "Id", "Nombre", articulos.UnidadMedidaId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nombre", articulos.MarcasId);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
