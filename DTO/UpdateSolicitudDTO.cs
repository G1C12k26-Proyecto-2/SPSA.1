using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UpdateSolicitudDTO : BaseClass
    {
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdCanton { get; set; }
        public int? IdDistrito { get; set; }
        public decimal? HectareasOriginal { get; set; }
        public string PendienteOriginal { get; set; }
        public string TipoVegetacionOriginal { get; set; }
        public bool? TieneRiosQuebradasOriginal { get; set; }
        public int? CantidadNacientesOriginal { get; set; }
        public string UsoSueloOriginal { get; set; }
    }
}