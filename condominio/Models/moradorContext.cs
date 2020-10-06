using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;


namespace condominio.Models
{
    public class moradorContext: DbContext
    {
        public DbSet<moradores> Moradors { get; set; }
    }
}