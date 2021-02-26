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
    public class pedidosController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: pedidos
        public ActionResult Index()
        {
            var pedidos = db.pedidos.Include(p => p.comanda).Include(p => p.productos);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_comanda = new SelectList(db.comanda, "id", "id");
            ViewBag.fk_id_producto = new SelectList(db.productos, "id", "nombre");
            return View();
        }

        // POST: pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fk_id_producto,cantidad,fk_id_comanda")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_comanda = new SelectList(db.comanda, "id", "id", pedidos.fk_id_comanda);
            ViewBag.fk_id_producto = new SelectList(db.productos, "id", "nombre", pedidos.fk_id_producto);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_comanda = new SelectList(db.comanda, "id", "id", pedidos.fk_id_comanda);
            ViewBag.fk_id_producto = new SelectList(db.productos, "id", "nombre", pedidos.fk_id_producto);
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fk_id_producto,cantidad,fk_id_comanda")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_comanda = new SelectList(db.comanda, "id", "id", pedidos.fk_id_comanda);
            ViewBag.fk_id_producto = new SelectList(db.productos, "id", "nombre", pedidos.fk_id_producto);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            db.pedidos.Remove(pedidos);
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
