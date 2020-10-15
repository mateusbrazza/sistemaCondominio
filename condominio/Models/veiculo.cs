using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace condominio.Models
{

    public class veiculo
    {

        [Key]
        public int id { get; set; }
        [DisplayName("Placa")]
        public string placa { get; set; }
        [DisplayName("N° Apartamento")]
        public string numApartamento { get; set; }
        [DisplayName("Bloco")]
        public string bloco { get; set; }
        [DisplayName("Cor")]
        public string cor { get; set; }
        [DisplayName("Marca")]
        public string marca { get; set; }
        [DisplayName("Modelo")]
        public string modelo { get; set; }
        [DisplayName("Imagem")]
        public string nome_image { get; set; }
        [NotMapped]

        public HttpPostedFileBase Imagemfile { get; set; }
    }
}