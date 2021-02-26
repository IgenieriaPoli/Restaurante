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
    public class comandasController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: comandas
        public ActionResult Index()
        {
            var comanda = db.comanda.Include(c => c.facturacion).Include(c => c.mesas);
            return View(comanda.ToList());
        }

        // GET: comandas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comanda comanda = db.comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // GET: comandas/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.facturacion, "fkpk_id_comanda", "fkpk_id_comanda");
            ViewBag.fk_numero_mesa = new SelectList(db.mesas, "numero_mesa", "numero_mesa");
            return View();
        }

        // POST: comandas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fk_numero_mesa")] comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.comanda.Add(comanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.facturacion, "fkpk_id_comanda", "fkpk_id_comanda", comanda.id);
            ViewBag.fk_numero_mesa = new SelectList(db.mesas, "numero_mesa", "numero_mesa", comanda.fk_numero_mesa);
            return View(comanda);
        }

        // GET: comandas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comanda comanda = db.comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.facturacion, "fkpk_id_comanda", "fkpk_id_comanda", comanda.id);
            ViewBag.fk_numero_mesa = new SelectList(db.mesas, "numero_mesa", "numero_mesa", comanda.fk_numero_mesa);
            return View(comanda);
        }

        // POST: comandas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fk_numero_mesa")] comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.facturacion, "fkpk_id_comanda", "fkpk_id_comanda", comanda.id);
            ViewBag.fk_numero_mesa = new SelectList(db.mesas, "numero_mesa", "numero_mesa", comanda.fk_numero_mesa);
            return View(comanda);
        }

        // GET: comandas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comanda comanda = db.comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // POST: comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comanda comanda = db.comanda.Find(id);
            db.comanda.Remove(comanda);
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
