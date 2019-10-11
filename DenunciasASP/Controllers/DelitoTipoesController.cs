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
    public class DelitoTipoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DelitoTipoes
        public ActionResult Index()
        {
            return View(db.DelitoTipos.ToList());
        }

        // GET: DelitoTipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DelitoTipo delitoTipo = db.DelitoTipos.Find(id);
            if (delitoTipo == null)
            {
                return HttpNotFound();
            }
            return View(delitoTipo);
        }

        // GET: DelitoTipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DelitoTipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTipoDelito")] DelitoTipo delitoTipo)
        {
            if (ModelState.IsValid)
            {
                db.DelitoTipos.Add(delitoTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(delitoTipo);
        }

        // GET: DelitoTipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DelitoTipo delitoTipo = db.DelitoTipos.Find(id);
            if (delitoTipo == null)
            {
                return HttpNotFound();
            }
            return View(delitoTipo);
        }

        // POST: DelitoTipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTipoDelito")] DelitoTipo delitoTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delitoTipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(delitoTipo);
        }

        // GET: DelitoTipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DelitoTipo delitoTipo = db.DelitoTipos.Find(id);
            if (delitoTipo == null)
            {
                return HttpNotFound();
            }
            return View(delitoTipo);
        }

        // POST: DelitoTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DelitoTipo delitoTipo = db.DelitoTipos.Find(id);
            db.DelitoTipos.Remove(delitoTipo);
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
