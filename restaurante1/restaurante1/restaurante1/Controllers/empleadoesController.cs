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
    public class empleadoesController : Controller
    {
        private restaurante_el_buen_saborEntities6 db = new restaurante_el_buen_saborEntities6();

        // GET: empleadoes
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.rol).Include(e => e.tipo_documento);
            return View(empleado.ToList());
        }

        // GET: empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.fk_rol = new SelectList(db.rol, "id", "rol1");
            ViewBag.fkpk_tipo_doc = new SelectList(db.tipo_documento, "tipo_documento1", "descripcion");
            return View();
        }

        // POST: empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "identificacion,fkpk_tipo_doc,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,contrasenia,telefono,email,direccion,fk_rol")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_rol = new SelectList(db.rol, "id", "rol1", empleado.fk_rol);
            ViewBag.fkpk_tipo_doc = new SelectList(db.tipo_documento, "tipo_documento1", "descripcion", empleado.fkpk_tipo_doc);
            return View(empleado);
        }

        // GET: empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_rol = new SelectList(db.rol, "id", "rol1", empleado.fk_rol);
            ViewBag.fkpk_tipo_doc = new SelectList(db.tipo_documento, "tipo_documento1", "descripcion", empleado.fkpk_tipo_doc);
            return View(empleado);
        }

        // POST: empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "identificacion,fkpk_tipo_doc,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,contrasenia,telefono,email,direccion,fk_rol")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_rol = new SelectList(db.rol, "id", "rol1", empleado.fk_rol);
            ViewBag.fkpk_tipo_doc = new SelectList(db.tipo_documento, "tipo_documento1", "descripcion", empleado.fkpk_tipo_doc);
            return View(empleado);
        }

        // GET: empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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
