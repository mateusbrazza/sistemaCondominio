using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using condominio.Models;
using FormFactory;
using Microsoft.Ajax.Utilities;
using System.IO;

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
        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            ViewData["nomeget"] = search;

            var textquery = from x in db.visistantes select x;

            if (!String.IsNullOrEmpty(search))
            {
                textquery = textquery.Where(x => x.nome.Contains(search) || x.numApartamento.Contains(search));
            }
            return View(await textquery.AsNoTracking().ToListAsync());
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
        public ActionResult Create( visistante visistante)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(visistante.Imagemfile.FileName);
                string extension = Path.GetExtension(visistante.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                visistante.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                visistante.Imagemfile.SaveAs(fileName);
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
        public ActionResult Edit( visistante visistante)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(visistante.Imagemfile.FileName);
                string extension = Path.GetExtension(visistante.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                visistante.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                visistante.Imagemfile.SaveAs(fileName);
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
