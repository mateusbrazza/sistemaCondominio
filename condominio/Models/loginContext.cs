using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace condominio.Models
{
    public class loginContext : DbContext
    {
        public DbSet<login> logins { get; set; }
    }
    
}