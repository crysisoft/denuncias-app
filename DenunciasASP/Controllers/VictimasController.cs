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
    public class VictimasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Victimas
        public ActionResult Index()
        {
            var victimas = db.Victimas.Include(v => v.denuncia).Include(v => v.Sexo);
            return View(victimas.ToList());
        }

        // GET: Victimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            return View(victima);
        }

        // GET: Victimas/Create
        public ActionResult Create()
        {
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis");
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo");
            return View();
        }

        // POST: Victimas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Identificacion,SexoId,Edad,DenunciaId")] Victima victima)
        {
            if (ModelState.IsValid)
            {
                db.Victimas.Add(victima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Direccion", victima.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", victima.SexoId);
            return View(victima);
        }

        // GET: Victimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", victima.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", victima.SexoId);
            return View(victima);
        }

        // POST: Victimas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Identificacion,SexoId,Edad,DenunciaId")] Victima victima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", victima.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", victima.SexoId);
            return View(victima);
        }

        // GET: Victimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victima victima = db.Victimas.Find(id);
            if (victima == null)
            {
                return HttpNotFound();
            }
            return View(victima);
        }

        // POST: Victimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Victima victima = db.Victimas.Find(id);
            db.Victimas.Remove(victima);
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
