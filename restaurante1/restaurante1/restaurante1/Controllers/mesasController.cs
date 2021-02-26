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
    public class mesasController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: mesas
        public ActionResult Index()
        {
            var mesas = db.mesas.Include(m => m.estado_mesa);
            return View(mesas.ToList());
        }

        // GET: mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesas mesas = db.mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // GET: mesas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_estado = new SelectList(db.estado_mesa, "id", "estado");
            return View();
        }

        // POST: mesas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero_mesa,fk_id_estado,comensales")] mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.mesas.Add(mesas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_estado = new SelectList(db.estado_mesa, "id", "estado", mesas.fk_id_estado);
            return View(mesas);
        }

        // GET: mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesas mesas = db.mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_estado = new SelectList(db.estado_mesa, "id", "estado", mesas.fk_id_estado);
            return View(mesas);
        }

        // POST: mesas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero_mesa,fk_id_estado,comensales")] mesas mesas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_estado = new SelectList(db.estado_mesa, "id", "estado", mesas.fk_id_estado);
            return View(mesas);
        }

        // GET: mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesas mesas = db.mesas.Find(id);
            if (mesas == null)
            {
                return HttpNotFound();
            }
            return View(mesas);
        }

        // POST: mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mesas mesas = db.mesas.Find(id);
            db.mesas.Remove(mesas);
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
