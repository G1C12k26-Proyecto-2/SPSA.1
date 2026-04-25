using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SolicitudDTO : BaseClass
    {
        public int IdSolicitud { get; set; }
        public int UsuarioId { get; set; }
        public string NombreFinca { get; set; }
        public string Propietario { get; set; }
        public string Email { get; set; }
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }
        public int? IdCanton { get; set; }
        public string Canton { get; set; }
        public int? IdDistrito { get; set; }
        public string Distrito { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? PagoMensual { get; set; }
        public decimal? HectareasOriginal { get; set; }
        public string TipoVegetacionOriginal { get; set; }
        public string PendienteOriginal { get; set; }
        public bool? TieneRiosQuebradasOriginal { get; set; }
        public int? CantidadNacientesOriginal { get; set; }
        public string UsoSueloOriginal { get; set; }
        public decimal? HectareasVerificadas { get; set; }
        public string TipoVegetacionVerificado { get; set; }
        public bool? CalificaParaPago { get; set; }
        public DateTime? FechaVisitaReal { get; set; }
        public string IngenieroNombre { get; set; }
        public string DistritoTexto { get; set; }
        public List<string> FotosUrls { get; set; } = new();
        public List<string> DocumentosUrls { get; set; } = new();
    }
}
