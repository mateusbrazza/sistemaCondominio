using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace condominio.Models
{
    public class visitanteContext : DbContext
    {
        public DbSet<visistante> visistantes { get; set; }
    }
    
}