using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using condominio.Models;

namespace condominio.Controllers
{
    public class visistantesController : Controller
    {
        private visitanteContext db = new visitanteContext();

        // GET: visistantes
        public ActionResult Index()
        {
            return View(db.visistantes.ToList());
        }

        // GET: visistantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visistante visistante = db.visistantes.Find(id);
            if (visistante == null)
            {
                return HttpNotFound();
            }
            return View(visistante);
        }

        // GET: visistantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: visistantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,numApartamento,bloco,telefone1,telefone2,observacao,nome_image")] visistante visistante)
        {
            if (ModelState.IsValid)
            {
                db.visistantes.Add(visistante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visistante);
        }

        // GET: visistantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visistante visistante = db.visistantes.Find(id);
            if (visistante == null)
            {
                return HttpNotFound();
            }
            return View(visistante);
        }

        // POST: visistantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,numApartamento,bloco,telefone1,telefone2,observacao,nome_image")] visistante visistante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visistante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visistante);
        }

        // GET: visistantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visistante visistante = db.visistantes.Find(id);
            if (visistante == null)
            {
                return HttpNotFound();
            }
            return View(visistante);
        }

        // POST: visistantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visistante visistante = db.visistantes.Find(id);
            db.visistantes.Remove(visistante);
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
