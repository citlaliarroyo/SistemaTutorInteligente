using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaTutorInteligente.Models
{
    public class datos_cuenta
    {
        [Key]
        public int id_usuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public ICollection<datos_personales> datos_Personales { get; set; }
    }
}
