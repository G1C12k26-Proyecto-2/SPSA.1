using System;

namespace DTO.Ingeniero
{
    public class SolicitudPendienteDTO
    {
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Propietario { get; set; }
        public string Ubicacion { get; set; }
        public decimal Hectareas { get; set; }
        public string TipoVegetacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
    }
}