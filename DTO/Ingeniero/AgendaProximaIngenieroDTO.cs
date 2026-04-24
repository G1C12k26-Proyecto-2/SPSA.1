using System;

namespace DTO.Ingeniero
{
    public class AgendaProximaIngenieroDTO
    {
        public int IdEvento { get; set; }
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaVisita { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public string Estado { get; set; }
        public string HoraInicioStr => HoraInicio.ToString(@"hh\:mm");
    }
}