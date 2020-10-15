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
    public class HomeController : Controller
    {
        private moradorContext db = new moradorContext();
        public ActionResult Index()
        {
            return View(db.Moradors.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}