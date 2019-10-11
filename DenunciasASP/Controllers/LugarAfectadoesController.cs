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
    public class LugarAfectadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LugarAfectadoes
        public ActionResult Index()
        {
            return View(db.LugarAfectados.ToList());
        }

        // GET: LugarAfectadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarAfectado lugarAfectado = db.LugarAfectados.Find(id);
            if (lugarAfectado == null)
            {
                return HttpNotFound();
            }
            return View(lugarAfectado);
        }

        // GET: LugarAfectadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LugarAfectadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTipoLugar")] LugarAfectado lugarAfectado)
        {
            if (ModelState.IsValid)
            {
                db.LugarAfectados.Add(lugarAfectado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugarAfectado);
        }

        // GET: LugarAfectadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarAfectado lugarAfectado = db.LugarAfectados.Find(id);
            if (lugarAfectado == null)
            {
                return HttpNotFound();
            }
            return View(lugarAfectado);
        }

        // POST: LugarAfectadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTipoLugar")] LugarAfectado lugarAfectado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugarAfectado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugarAfectado);
        }

        // GET: LugarAfectadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarAfectado lugarAfectado = db.LugarAfectados.Find(id);
            if (lugarAfectado == null)
            {
                return HttpNotFound();
            }
            return View(lugarAfectado);
        }

        // POST: LugarAfectadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LugarAfectado lugarAfectado = db.LugarAfectados.Find(id);
            db.LugarAfectados.Remove(lugarAfectado);
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
