using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTutorInteligente.Models;

namespace SistemaTutorInteligente.Models
{
    public class SistemaTutorInteligenteContext : DbContext
    {
        public SistemaTutorInteligenteContext (DbContextOptions<SistemaTutorInteligenteContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaTutorInteligente.Models.datos_personales> datos_personales { get; set; }

        public DbSet<SistemaTutorInteligente.Models.datos_cuenta> datos_cuenta { get; set; }

        public DbSet<SistemaTutorInteligente.Models.tipo_usuario> tipo_usuario { get; set; }
    }
}
