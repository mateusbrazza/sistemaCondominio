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
    public class veiculoesController : Controller
    {
        private veiculoContext db = new veiculoContext();

        // GET: veiculoes
        public ActionResult Index()
        {
            return View(db.veiculos.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            ViewData["nomeget"] = search;

            var textquery = from x in db.veiculos select x;

            if (!String.IsNullOrEmpty(search))
            {
                textquery = textquery.Where(x => x.numApartamento.Contains(search) || x.placa.Contains(search));
            }
            return View(await textquery.AsNoTracking().ToListAsync());
        }

        // GET: veiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veiculo veiculo = db.veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: veiculoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: veiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(veiculo.Imagemfile.FileName);
                string extension = Path.GetExtension(veiculo.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                veiculo.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                veiculo.Imagemfile.SaveAs(fileName);
                db.veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veiculo);
        }

        // GET: veiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veiculo veiculo = db.veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: veiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(veiculo.Imagemfile.FileName);
                string extension = Path.GetExtension(veiculo.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                veiculo.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                veiculo.Imagemfile.SaveAs(fileName);
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

        // GET: veiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veiculo veiculo = db.veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: veiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            veiculo veiculo = db.veiculos.Find(id);
            db.veiculos.Remove(veiculo);
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
