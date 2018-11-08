using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaTutorInteligente.Models
{
    public class datos_personales
    {
        [Key]
        public int id_datos { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [StringLength(85, MinimumLength = 4, ErrorMessage = "El Nombre debe tener de 4 a 85 caracteres")]
        public String nombre { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [StringLength(85, MinimumLength = 4, ErrorMessage = "El Apellido paterno debe tener de 4 a 85 caracteres")]
        public String a_paterno { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [StringLength(85, MinimumLength = 4, ErrorMessage = "El Apellido materno debe tener de 4 a 85 caracteres")]
        public String a_materno { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public int edad { get; set; }
        public int id_tipo { get; set; }
        public tipo_usuario tipo_usuario { get; set; }
        public int id_usuario { get; set; }
        public datos_cuenta datos_cuenta { get; set; }
    }
}
