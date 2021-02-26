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
    public class estado_mesaController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: estado_mesa
        public ActionResult Index()
        {
            return View(db.estado_mesa.ToList());
        }

        // GET: estado_mesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_mesa estado_mesa = db.estado_mesa.Find(id);
            if (estado_mesa == null)
            {
                return HttpNotFound();
            }
            return View(estado_mesa);
        }

        // GET: estado_mesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estado_mesa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,estado")] estado_mesa estado_mesa)
        {
            if (ModelState.IsValid)
            {
                db.estado_mesa.Add(estado_mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_mesa);
        }

        // GET: estado_mesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_mesa estado_mesa = db.estado_mesa.Find(id);
            if (estado_mesa == null)
            {
                return HttpNotFound();
            }
            return View(estado_mesa);
        }

        // POST: estado_mesa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,estado")] estado_mesa estado_mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_mesa);
        }

        // GET: estado_mesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_mesa estado_mesa = db.estado_mesa.Find(id);
            if (estado_mesa == null)
            {
                return HttpNotFound();
            }
            return View(estado_mesa);
        }

        // POST: estado_mesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estado_mesa estado_mesa = db.estado_mesa.Find(id);
            db.estado_mesa.Remove(estado_mesa);
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
