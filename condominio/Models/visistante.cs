using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace condominio.Models
{
    public class visistante
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string numApartamento { get; set; }
        public string bloco { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }
        public string observacao { get; set; }
        public string nome_image { get; set; }

    }
}