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
    public class DenunciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Denuncias
        public ActionResult Index()
        {
            var denuncias = db.Denuncias.Include(d => d.Estado).Include(d => d.Localidad).Include(d => d.LugarAfectado).Include(d => d.TipoDelito);
            return View(denuncias.ToList());
        }

        // GET: Denuncias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // GET: Denuncias/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "Id", "NombreEstado");
            ViewBag.LocalidadId = new SelectList(db.Localidads, "Id", "NombreLocalidad");
            ViewBag.LugarAfectadoId = new SelectList(db.LugarAfectados, "Id", "NombreTipoLugar");
            ViewBag.TipoDelitoId = new SelectList(db.DelitoTipos, "Id", "NombreTipoDelito");
            return View();
        }

        // POST: Denuncias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocalidadId,FechaHoraOcurrido,TipoDelitoId,EstadoId,LugarAfectadoId,Direccion,Sintesis,CuantosMasculino,CuantosFemenino,CuantosDesconocidos")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                db.Denuncias.Add(denuncia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "Id", "NombreEstado", denuncia.EstadoId);
            ViewBag.LocalidadId = new SelectList(db.Localidads, "Id", "NombreLocalidad", denuncia.LocalidadId);
            ViewBag.LugarAfectadoId = new SelectList(db.LugarAfectados, "Id", "NombreTipoLugar", denuncia.LugarAfectadoId);
            ViewBag.TipoDelitoId = new SelectList(db.DelitoTipos, "Id", "NombreTipoDelito", denuncia.TipoDelitoId);
            return View(denuncia);
        }

        // GET: Denuncias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "Id", "NombreEstado", denuncia.EstadoId);
            ViewBag.LocalidadId = new SelectList(db.Localidads, "Id", "NombreLocalidad", denuncia.LocalidadId);
            ViewBag.LugarAfectadoId = new SelectList(db.LugarAfectados, "Id", "NombreTipoLugar", denuncia.LugarAfectadoId);
            ViewBag.TipoDelitoId = new SelectList(db.DelitoTipos, "Id", "NombreTipoDelito", denuncia.TipoDelitoId);
            return View(denuncia);
        }

        // POST: Denuncias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocalidadId,FechaHoraOcurrido,TipoDelitoId,EstadoId,LugarAfectadoId,Direccion,Sintesis,CuantosMasculino,CuantosFemenino,CuantosDesconocidos")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denuncia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "Id", "NombreEstado", denuncia.EstadoId);
            ViewBag.LocalidadId = new SelectList(db.Localidads, "Id", "NombreLocalidad", denuncia.LocalidadId);
            ViewBag.LugarAfectadoId = new SelectList(db.LugarAfectados, "Id", "NombreTipoLugar", denuncia.LugarAfectadoId);
            ViewBag.TipoDelitoId = new SelectList(db.DelitoTipos, "Id", "NombreTipoDelito", denuncia.TipoDelitoId);
            return View(denuncia);
        }

        // GET: Denuncias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // POST: Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Denuncia denuncia = db.Denuncias.Find(id);
            db.Denuncias.Remove(denuncia);
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
