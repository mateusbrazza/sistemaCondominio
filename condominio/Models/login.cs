using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace condominio.Models
{
    public class login
    {

        //[Required(ErrorMessage ="Please enter yout email")]
        //[Display(Name ="Enter email:")]
        public string email { get; set; }
       // [Required(ErrorMessage = "Please enter yout Password")]
        //[Display(Name = "Enter Password:")]
        //[DataType(DataType.Password)]
        public string password { get; set; }
        public int id { get; set; }
        public string lasstname { get; set; }

        public string fristname { get; set; }

        public string about { get; set; }

        public string gender { get; set; }
        public ICollection<Interest> Interests { get; set; }


    }
}