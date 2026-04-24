using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PropiedadConRecursosDTO
    {
        public Propiedad Propiedad { get; set; }
        public List<PropiedadRecursoHidrico> RecursosHidricos { get; set; }

        public PropiedadConRecursosDTO()
        {
            Propiedad = new Propiedad();
            RecursosHidricos = new List<PropiedadRecursoHidrico>();
        }
    }
}
