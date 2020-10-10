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

namespace condominio.Controllers
{
    public class moradoresController : Controller
    {
        private moradorContext db = new moradorContext();

        // GET: moradores
        public ActionResult Index()
        {
           return View(db.Moradors.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            ViewData["nomeget"] = search;

            var textquery = from x in db.Moradors select x;

            if (!String.IsNullOrEmpty(search))
            {
                textquery = textquery.Where(x => x.nome.Contains(search) || x.numApartamento.Contains(search));
            }
            return View(await textquery.AsNoTracking().ToListAsync());
        }



        // GET: moradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moradores moradores = db.Moradors.Find(id);
            if (moradores == null)
            {
                return HttpNotFound();
            }
            return View(moradores);
        }

        // GET: moradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: moradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,numApartamento,bloco,telefone1,telefone2,email,observacao,nomeEmergencia,telefoneEmergencia,nome_image")] moradores moradores)
        {
            if (ModelState.IsValid)
            {
                db.Moradors.Add(moradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moradores);
        }

        // GET: moradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moradores moradores = db.Moradors.Find(id);
            if (moradores == null)
            {
                return HttpNotFound();
            }
            return View(moradores);
        }

        // POST: moradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,numApartamento,bloco,telefone1,telefone2,email,observacao,nomeEmergencia,telefoneEmergencia,nome_image")] moradores moradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moradores);
        }

        // GET: moradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moradores moradores = db.Moradors.Find(id);
            if (moradores == null)
            {
                return HttpNotFound();
            }
            return View(moradores);
        }

        // POST: moradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            moradores moradores = db.Moradors.Find(id);
            db.Moradors.Remove(moradores);
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


    ///
 







    }
}
