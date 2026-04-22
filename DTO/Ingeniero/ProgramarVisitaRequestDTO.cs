using System;

namespace DTO.Ingeniero
{
    public class ProgramarVisitaRequestDTO
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaVisita { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int DuracionEstimada { get; set; } // en minutos
        public string MedioTransporte { get; set; }
        public string ObjetivoVisita { get; set; }
        public string EquipoMateriales { get; set; }
        public string ObservacionesCoordinacion { get; set; }
    }
}