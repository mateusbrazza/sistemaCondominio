using condominio.Data;
using condominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace condominio.Controllers
{
    public class RegisterController : Controller
    {
        loginContext db = new loginContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

       // public ActionResult Register(login lg,int[] Interest)
        //{
          //  if (Interest !=null)
            //{
              //  foreach(var item in Interest)
                //{
                  //  Interest interest = db.logins.Find(item);
                    //lg.Interests.Add(interest);
                //}
               // db.logins

            //}
        //}
    }
}