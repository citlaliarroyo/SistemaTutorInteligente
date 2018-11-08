using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaTutorInteligente.Models
{
    public class tipo_usuario
    {
        [Key]
        public int id_tipo { get; set; }
        public String nombre_tipo_usuario { get; set; }
        public ICollection<datos_personales> datos_Personales { get; set; }
    }
}
