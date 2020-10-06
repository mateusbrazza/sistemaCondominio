using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace condominio.Models
{
    public class funcionarioContext: DbContext
    {
        public DbSet<funcionario> Funcionarios { get; set; }
    }
}