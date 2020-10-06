using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace condominio.Models
{
    public class apartamento
    {
        [Key]
        public string numApartamento { get; set;}
        [Key]
        public string bloco { get; set; }

    }
}