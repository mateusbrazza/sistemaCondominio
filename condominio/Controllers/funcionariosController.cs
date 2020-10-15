using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using condominio.Models;
using System.IO;
using System.Threading.Tasks;


namespace condominio.Controllers
{
    public class funcionariosController : Controller
    {
        private funcionarioContext db = new funcionarioContext();

        // GET: funcionarios
        public ActionResult Index()
        {
            return View(db.Funcionarios.ToList());
        }
        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            ViewData["nomeget"] = search;

            var textquery = from x in db.Funcionarios select x;

            if (!String.IsNullOrEmpty(search))
            {
                textquery = textquery.Where(x => x.nome.Contains(search) || x.numApartamento.Contains(search));
            }
            return View(await textquery.AsNoTracking().ToListAsync());
        }

        // GET: funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( funcionario funcionario)
        {


            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(funcionario.Imagemfile.FileName);
                string extension = Path.GetExtension(funcionario.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                funcionario.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                funcionario.Imagemfile.SaveAs(fileName);
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(funcionario.Imagemfile.FileName);
                string extension = Path.GetExtension(funcionario.Imagemfile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                funcionario.nome_image = "Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                funcionario.Imagemfile.SaveAs(fileName);
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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
