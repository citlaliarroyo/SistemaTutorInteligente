using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTutorInteligente.Models;

namespace SistemaTutorInteligente.Data
{
    public class DbInitializer
    {
        public static void Initialize(SistemaTutorInteligenteContext context)
        {
            context.Database.EnsureCreated();
            if (context.datos_personales.Any())
            {
                return;
            }
            var datos_personales = new datos_personales[]
                {
                    //
                };
            foreach (datos_personales a in datos_personales)
            {
                context.datos_personales.Add(a);
            }
            context.SaveChanges();
        }
    }
}
