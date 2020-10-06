using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace condominio.Models
{
    public class veiculoContext: DbContext
    {
        public DbSet<veiculo> veiculos { get; set; }
    }
   
}