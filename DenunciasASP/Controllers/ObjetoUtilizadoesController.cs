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
    public class ObjetoUtilizadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ObjetoUtilizadoes
        public ActionResult Index()
        {
            var objetoUtilizados = db.ObjetoUtilizados.Include(o => o.denuncia);
            return View(objetoUtilizados.ToList());
        }

        // GET: ObjetoUtilizadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoUtilizado objetoUtilizado = db.ObjetoUtilizados.Find(id);
            if (objetoUtilizado == null)
            {
                return HttpNotFound();
            }
            return View(objetoUtilizado);
        }

        // GET: ObjetoUtilizadoes/Create
        public ActionResult Create()
        {
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis");
            return View();
        }

        // POST: ObjetoUtilizadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreUtilizado,CantidadUtilizado,DenunciaId")] ObjetoUtilizado objetoUtilizado)
        {
            if (ModelState.IsValid)
            {
                db.ObjetoUtilizados.Add(objetoUtilizado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoUtilizado.DenunciaId);
            return View(objetoUtilizado);
        }

        // GET: ObjetoUtilizadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoUtilizado objetoUtilizado = db.ObjetoUtilizados.Find(id);
            if (objetoUtilizado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoUtilizado.DenunciaId);
            return View(objetoUtilizado);
        }

        // POST: ObjetoUtilizadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreUtilizado,CantidadUtilizado,DenunciaId")] ObjetoUtilizado objetoUtilizado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetoUtilizado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", objetoUtilizado.DenunciaId);
            return View(objetoUtilizado);
        }

        // GET: ObjetoUtilizadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoUtilizado objetoUtilizado = db.ObjetoUtilizados.Find(id);
            if (objetoUtilizado == null)
            {
                return HttpNotFound();
            }
            return View(objetoUtilizado);
        }

        // POST: ObjetoUtilizadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjetoUtilizado objetoUtilizado = db.ObjetoUtilizados.Find(id);
            db.ObjetoUtilizados.Remove(objetoUtilizado);
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
