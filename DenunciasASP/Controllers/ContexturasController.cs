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
    public class ContexturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contexturas
        public ActionResult Index()
        {
            return View(db.Contexturas.ToList());
        }

        // GET: Contexturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contextura contextura = db.Contexturas.Find(id);
            if (contextura == null)
            {
                return HttpNotFound();
            }
            return View(contextura);
        }

        // GET: Contexturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contexturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreContextura")] Contextura contextura)
        {
            if (ModelState.IsValid)
            {
                db.Contexturas.Add(contextura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contextura);
        }

        // GET: Contexturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contextura contextura = db.Contexturas.Find(id);
            if (contextura == null)
            {
                return HttpNotFound();
            }
            return View(contextura);
        }

        // POST: Contexturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreContextura")] Contextura contextura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contextura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contextura);
        }

        // GET: Contexturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contextura contextura = db.Contexturas.Find(id);
            if (contextura == null)
            {
                return HttpNotFound();
            }
            return View(contextura);
        }

        // POST: Contexturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contextura contextura = db.Contexturas.Find(id);
            db.Contexturas.Remove(contextura);
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
