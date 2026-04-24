using System;

namespace DTO
{
    public class Propiedad : BaseClass
    {
        // BaseClass.Id → IdPropiedad

        public int IdSolicitud { get; set; }

        public decimal AreaHectareas { get; set; }
        public string VegetacionClave { get; set; }
        public string PendienteClave { get; set; }

        public decimal? ValorCalculado { get; set; }
        public DateTime? FechaUltimaValuacion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public int? UsuarioCreacionId { get; set; }
        public int? UsuarioActualizaId { get; set; }

        public Propiedad()
        {
            VegetacionClave = string.Empty;
            PendienteClave = string.Empty;
            Active = true;
        }
    }
}
