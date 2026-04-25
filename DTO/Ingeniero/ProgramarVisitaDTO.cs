using System;

namespace DTO.Ingeniero
{
    public class ProgramarVisitaDTO
    {
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Propietario { get; set; }
        public string Ubicacion { get; set; }
        public decimal Hectareas { get; set; }
        public string TipoVegetacion { get; set; }

        // Datos de la visita
        public DateTime FechaVisita { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int DuracionEstimada { get; set; } // en minutos
        public string MedioTransporte { get; set; }
        public string ObjetivoVisita { get; set; }
        public string EquipoMateriales { get; set; }
        public string ObservacionesCoordinacion { get; set; }
    }
}