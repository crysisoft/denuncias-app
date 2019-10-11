using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DenunciasASP.Models;

namespace DenunciasASP.Controllers
{
    public class ObjetoAfectadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ObjetoAfectadoes
        public ActionResult Index()
        {
            var objetoAfectados = db.ObjetoAfectados.Include(o => o.denuncia);
            return View(objetoAfectados.ToList());
        }

        // GET: ObjetoAfectadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoAfectado objetoAfectado = db.ObjetoAfectados.Find(id);
            if (objetoAfectado == null)
            {
                return HttpNotFound();
            }
            return View(objetoAfectado);
        }

        // GET: ObjetoAfectadoes/Create
        public ActionResult Create()
        {
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis");
            return View();
        }

        // POST: ObjetoAfectadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAfectado,CantidadAfectado,DenunciaId")] ObjetoAfectado objetoAfectado)
        {
            if (ModelState.IsValid)
            {
                db.ObjetoAfectados.Add(objetoAfectado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoAfectado.DenunciaId);
            return View(objetoAfectado);
        }

        // GET: ObjetoAfectadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoAfectado objetoAfectado = db.ObjetoAfectados.Find(id);
            if (objetoAfectado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoAfectado.DenunciaId);
            return View(objetoAfectado);
        }

        // POST: ObjetoAfectadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAfectado,CantidadAfectado,DenunciaId")] ObjetoAfectado objetoAfectado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetoAfectado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoAfectado.DenunciaId);
            return View(objetoAfectado);
        }

        // GET: ObjetoAfectadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoAfectado objetoAfectado = db.ObjetoAfectados.Find(id);
            if (objetoAfectado == null)
            {
                return HttpNotFound();
            }
            return View(objetoAfectado);
        }

        // POST: ObjetoAfectadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjetoAfectado objetoAfectado = db.ObjetoAfectados.Find(id);
            db.ObjetoAfectados.Remove(objetoAfectado);
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
