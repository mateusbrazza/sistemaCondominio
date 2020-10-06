using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace condominio.Models
{

    public class veiculo
    {

        [Key]
        public int id { get; set; }
        public string placa { get; set; }
        public string numApartamento { get; set; }
        public string bloco { get; set; }
        public string cor { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string nome_image { get; set; }
    }
}