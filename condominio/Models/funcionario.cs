using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace condominio.Models
{
    public class funcionario
    {

        [Key]
        public int id { get; set; }
        [DisplayName("Nome")]
        public string nome { get; set; }
        [DisplayName("RG")]
        public string rg { get; set; }
        [DisplayName("CPF")]
        public string cpf { get; set; }
        [DisplayName("N° Apartamento")]
        public string numApartamento { get; set; }
        [DisplayName("Bloco")]
        public string bloco { get; set; }
        [DisplayName("Telefone")]
        public string telefone { get; set; }
        [DisplayName("Observação")]
        public string observacao { get; set; }
        [DisplayName("Imagem")]
       
        public string nome_image { get; set; }
        [NotMapped]
        
        public HttpPostedFileBase Imagemfile { get; set; }

    }
} 