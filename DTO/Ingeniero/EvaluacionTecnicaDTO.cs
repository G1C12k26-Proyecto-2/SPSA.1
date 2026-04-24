using System;

namespace DTO.Ingeniero.Solicitud
{
    public class EvaluacionTecnicaDTO
    {
        public int IdSolicitud { get; set; }

        // Datos verificados en campo
        public decimal? HectareasVerificadas { get; set; }
        public string TipoVegetacionVerificado { get; set; }
        public string PendienteVerificada { get; set; }
        public bool? TieneRiosQuebradasVerificado { get; set; }
        public int? CantidadNacientesVerificado { get; set; }
        public string UsoSueloVerificado { get; set; }

        // Observaciones
        public string ObservacionesTecnicas { get; set; }

        // Decisión final
        public bool CalificaParaPago { get; set; }
        public string RazonRechazo { get; set; }

        // Datos de la visita real
        public DateTime? FechaVisitaReal { get; set; }
        public TimeSpan? HoraInicioReal { get; set; }
    }
}