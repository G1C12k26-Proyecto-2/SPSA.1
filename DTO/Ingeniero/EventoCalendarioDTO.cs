using System;

namespace DTO.Ingeniero
{
    public class EventoCalendarioDTO
    {
        public int IdEvento { get; set; }
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaVisita { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int? DuracionEstimada { get; set; }
        public string Ubicacion { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
        public string HoraFormateada { get; set; }
        public string EstadoClase { get; set; }
        public string Propietario { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        // Propiedad calculada
        public string UbicacionCompleta => $"{Provincia}, {Canton}, {Distrito}".Trim(',', ' ');
    }
}