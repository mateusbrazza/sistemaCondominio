using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace condominio.Models
{
    public class visistante
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("N° Apartamento")]
        public string numApartamento { get; set; }
        [DisplayName("Bloco")]
        public string bloco { get; set; }
        [DisplayName("Telefone 1")]
        public string telefone1 { get; set; }
        [DisplayName("Telefone 2")]
        public string telefone2 { get; set; }
        [DisplayName("Observação")]
        public string observacao { get; set; }
        [DisplayName("Imagem")]
        public string nome_image { get; set; }
        [NotMapped]

        public HttpPostedFileBase Imagemfile { get; set; }


    }
}