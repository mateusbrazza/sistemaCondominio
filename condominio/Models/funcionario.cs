using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace condominio.Models
{
    public class funcionario
    {

        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string numApartamento { get; set; }
        public string bloco { get; set; }
        public string telefone { get; set; }
        public string observacao { get; set; }
        public string nome_image { get; set; }
    }
}