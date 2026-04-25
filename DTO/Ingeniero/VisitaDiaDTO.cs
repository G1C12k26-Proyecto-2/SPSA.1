using System;

namespace DTO.Ingeniero
{
    public class VisitaDiaDTO
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
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Propietario { get; set; }
        public string EmailPropietario { get; set; }

        // Propiedad calculada
        public string UbicacionCompleta => $"{Provincia}, {Canton}, {Distrito}".Trim(',', ' ');
        public string HoraFormateada => HoraInicio.ToString(@"hh\:mm");

        // Color según estado
        public string EstadoClase => Estado?.ToLower() switch
        {
            "pendiente" => "gold",
            "en proceso" => "blue",
            "completada" => "green",
            "cancelada" => "red",
            _ => "green"
        };
    }
}