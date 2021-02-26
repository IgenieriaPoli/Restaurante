using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using restaurante1.Models;

namespace restaurante1.Controllers
{
    public class productos_mesaController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: productos_mesa
        public ActionResult Index()
        {
            return View(db.productos_mesa.ToList());
        }

        // GET: productos_mesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos_mesa productos_mesa = db.productos_mesa.Find(id);
            if (productos_mesa == null)
            {
                return HttpNotFound();
            }
            return View(productos_mesa);
        }

        // GET: productos_mesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productos_mesa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero_mesa,cantidad,producto,precio_venta")] productos_mesa productos_mesa)
        {
            if (ModelState.IsValid)
            {
                db.productos_mesa.Add(productos_mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos_mesa);
        }

        // GET: productos_mesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos_mesa productos_mesa = db.productos_mesa.Find(id);
            if (productos_mesa == null)
            {
                return HttpNotFound();
            }
            return View(productos_mesa);
        }

        // POST: productos_mesa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero_mesa,cantidad,producto,precio_venta")] productos_mesa productos_mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos_mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos_mesa);
        }

        // GET: productos_mesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos_mesa productos_mesa = db.productos_mesa.Find(id);
            if (productos_mesa == null)
            {
                return HttpNotFound();
            }
            return View(productos_mesa);
        }

        // POST: productos_mesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos_mesa productos_mesa = db.productos_mesa.Find(id);
            db.productos_mesa.Remove(productos_mesa);
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
