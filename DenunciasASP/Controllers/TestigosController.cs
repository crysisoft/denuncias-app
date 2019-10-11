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
    public class TestigosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Testigos
        public ActionResult Index()
        {
            var testigos = db.Testigos.Include(t => t.denuncia).Include(t => t.Sexo);
            return View(testigos.ToList());
        }

        // GET: Testigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigos testigos = db.Testigos.Find(id);
            if (testigos == null)
            {
                return HttpNotFound();
            }
            return View(testigos);
        }

        // GET: Testigos/Create
        public ActionResult Create()
        {
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis");
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo");
            return View();
        }

        // POST: Testigos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Identificacion,SexoId,Edad,DenunciaId")] Testigos testigos)
        {
            if (ModelState.IsValid)
            {
                db.Testigos.Add(testigos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", testigos.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", testigos.SexoId);
            return View(testigos);
        }

        // GET: Testigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigos testigos = db.Testigos.Find(id);
            if (testigos == null)
            {
                return HttpNotFound();
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", testigos.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", testigos.SexoId);
            return View(testigos);
        }

        // POST: Testigos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Identificacion,SexoId,Edad,DenunciaId")] Testigos testigos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testigos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", testigos.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", testigos.SexoId);
            return View(testigos);
        }

        // GET: Testigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testigos testigos = db.Testigos.Find(id);
            if (testigos == null)
            {
                return HttpNotFound();
            }
            return View(testigos);
        }

        // POST: Testigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testigos testigos = db.Testigos.Find(id);
            db.Testigos.Remove(testigos);
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
