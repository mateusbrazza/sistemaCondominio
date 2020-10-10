using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using condominio.Models;

namespace condominio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<funcionarioContext>(new DropCreateDatabaseIfModelChanges<funcionarioContext>());
            Database.SetInitializer<visitanteContext>(new DropCreateDatabaseIfModelChanges<visitanteContext>());
            Database.SetInitializer<moradorContext>(new DropCreateDatabaseIfModelChanges<moradorContext>());
            Database.SetInitializer<veiculoContext>(new DropCreateDatabaseIfModelChanges<veiculoContext>());




        }
    }
}
