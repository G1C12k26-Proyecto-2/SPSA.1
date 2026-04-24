using System;

namespace DTO
{
    public class PropiedadRecursoHidrico : BaseClass
    {
        // BaseClass.Id → IdPropiedadRecursoHidrico

        public int IdPropiedad { get; set; }

        public string RecursoHidricoClave { get; set; }
        public int Cantidad { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public int? UsuarioCreacionId { get; set; }
        public int? UsuarioActualizaId { get; set; }

        public PropiedadRecursoHidrico()
        {
            RecursoHidricoClave = string.Empty;
            Cantidad = 1;
            Active = true;
        }
    }
}