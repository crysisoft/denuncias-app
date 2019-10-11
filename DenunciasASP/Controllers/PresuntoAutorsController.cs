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
    public class PresuntoAutorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PresuntoAutors
        public ActionResult Index()
        {
            var presuntoAutors = db.PresuntoAutors.Include(p => p.ColorCabello).Include(p => p.ColorPiel).Include(p => p.Contextura).Include(p => p.denuncia).Include(p => p.Sexo);
            return View(presuntoAutors.ToList());
        }

        // GET: PresuntoAutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresuntoAutor presuntoAutor = db.PresuntoAutors.Find(id);
            if (presuntoAutor == null)
            {
                return HttpNotFound();
            }
            return View(presuntoAutor);
        }

        // GET: PresuntoAutors/Create
        public ActionResult Create()
        {
            ViewBag.ColorCabelloId = new SelectList(db.Colors, "Id", "NombreColor");
            ViewBag.ColorPielId = new SelectList(db.Colors, "Id", "NombreColor");
            ViewBag.ContexturaId = new SelectList(db.Contexturas, "Id", "NombreContextura");
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis");
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo");
            return View();
        }

        // POST: PresuntoAutors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAutor,Alias,Descripcion,ColorPielId,ColorCabelloId,EstaturaAprox,ContexturaId,Tatuajes,Cicatrices,SexoId,DenunciaId")] PresuntoAutor presuntoAutor)
        {
            if (ModelState.IsValid)
            {
                db.PresuntoAutors.Add(presuntoAutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorCabelloId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorCabelloId);
            ViewBag.ColorPielId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorPielId);
            ViewBag.ContexturaId = new SelectList(db.Contexturas, "Id", "NombreContextura", presuntoAutor.ContexturaId);
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", presuntoAutor.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", presuntoAutor.SexoId);
            return View(presuntoAutor);
        }

        // GET: PresuntoAutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresuntoAutor presuntoAutor = db.PresuntoAutors.Find(id);
            if (presuntoAutor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorCabelloId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorCabelloId);
            ViewBag.ColorPielId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorPielId);
            ViewBag.ContexturaId = new SelectList(db.Contexturas, "Id", "NombreContextura", presuntoAutor.ContexturaId);
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", presuntoAutor.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", presuntoAutor.SexoId);
            return View(presuntoAutor);
        }

        // POST: PresuntoAutors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAutor,Alias,Descripcion,ColorPielId,ColorCabelloId,EstaturaAprox,ContexturaId,Tatuajes,Cicatrices,SexoId,DenunciaId")] PresuntoAutor presuntoAutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presuntoAutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorCabelloId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorCabelloId);
            ViewBag.ColorPielId = new SelectList(db.Colors, "Id", "NombreColor", presuntoAutor.ColorPielId);
            ViewBag.ContexturaId = new SelectList(db.Contexturas, "Id", "NombreContextura", presuntoAutor.ContexturaId);
            ViewBag.DenunciaId = new SelectList(db.Denuncias, "Id", "Sintesis", presuntoAutor.DenunciaId);
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "NombreSexo", presuntoAutor.SexoId);
            return View(presuntoAutor);
        }

        // GET: PresuntoAutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresuntoAutor presuntoAutor = db.PresuntoAutors.Find(id);
            if (presuntoAutor == null)
            {
                return HttpNotFound();
            }
            return View(presuntoAutor);
        }

        // POST: PresuntoAutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PresuntoAutor presuntoAutor = db.PresuntoAutors.Find(id);
            db.PresuntoAutors.Remove(presuntoAutor);
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
