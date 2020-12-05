using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestionex.Models;

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
            var Solicitudes = db.SolicitudArticulos.Where(a => !a.Estado);
            ViewBag.SolicitudArticulosId = new SelectList(Solicitudes, "Id", "Resumen");

            int primeraCantidad = Solicitudes.FirstOrDefault().Cantidad;
            var ComprasDb = db.OrdenCompras.ToList().LastOrDefault();
            var NumOrden = (ComprasDb!=null) ? ComprasDb.NumeroOrden + 1 : 1;
            var oc = new OrdenCompra { Cantidad = primeraCantidad, Fecha = DateTime.Now, NumeroOrden = NumOrden };
            return View(oc);
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroOrden,Fecha,Cantidad,CostoUnitario,SolicitudArticulosId,Estado")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenCompras.Add(ordenCompra);
                SolicitudArticulos solicitudArticulo = db.SolicitudArticulos.Where(a => a.Id == ordenCompra.SolicitudArticulosId).FirstOrDefault();
                Articulos articulo = db.Articulos.Where(a => a.Id == solicitudArticulo.ArticulosId).FirstOrDefault();

                if (ordenCompra.Cantidad > articulo.Existencia)
                    ModelState.AddModelError("Cantidad", $"Cantidad excede el inventario ({articulo.Existencia})");
                
                if (ModelState.IsValid)
                {
                    solicitudArticulo.Estado = true;
                    articulo.Existencia -= ordenCompra.Cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos.Where(a => !a.Estado), "Id", "Resumen");
                return View(ordenCompra);
            }

            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Resumen", ordenCompra.SolicitudArticulosId);
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
            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Resumen", ordenCompra.SolicitudArticulosId);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroOrden,Fecha,Cantidad,CostoUnitario,SolicitudArticulosId,Estado")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                OrdenCompra originalOrdenCompra = db.OrdenCompras.AsNoTracking().Where(p => p.Id == ordenCompra.Id).FirstOrDefault();
                int old = originalOrdenCompra.Cantidad;

                db.Entry(ordenCompra).State = System.Data.Entity.EntityState.Modified;
                SolicitudArticulos solicitudArticulo = db.SolicitudArticulos.Where(a => a.Id == ordenCompra.SolicitudArticulosId).FirstOrDefault();
                Articulos articulo = db.Articulos.Where(a => a.Id == solicitudArticulo.ArticulosId).FirstOrDefault();


                articulo.Existencia -= -old + ordenCompra.Cantidad;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SolicitudArticulosId = new SelectList(db.SolicitudArticulos, "Id", "Resumen", ordenCompra.SolicitudArticulosId);
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
            SolicitudArticulos solicitudArticulo = db.SolicitudArticulos.Where(a => a.Id == ordenCompra.SolicitudArticulosId).FirstOrDefault();
            Articulos articulo = db.Articulos.Where(a => a.Id == solicitudArticulo.ArticulosId).FirstOrDefault();


            solicitudArticulo.Estado = false;

            articulo.Existencia += ordenCompra.Cantidad;
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

        public ActionResult ExportarExcel()
        {
            string filename = "Ordenes de compra.csv";
            string filepath = @"C:\tmp\" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("id_orden,nombre proveedor, cedula/rnc proveedor, no. de orden, fecha, solicitud de articulo, cantidad, costo por unidad, costo total, estado"); //Encabezado 
            foreach (var orden in db.OrdenCompras.ToList())
            {
                var proveedor = orden.SolicitudArticulo.Articulo.Marca.Proveedor;
                string[] elementos = { 
                    orden.Id.ToString(),
                    proveedor.NombreComercial,
                    proveedor.Cedula, 
                    orden.NumeroOrden.ToString(),
                    orden.Fecha.ToShortDateString(),
                    orden.SolicitudArticulo.Resumen,
                    orden.Cantidad.ToString(),
                    orden.CostoUnitario.ToString(),
                    orden.CostoTotal.ToString(),
                    orden.Estado.ToString() };
                sw.WriteLine(string.Join(",", elementos));
            }
            sw.Close();

            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = false,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}
