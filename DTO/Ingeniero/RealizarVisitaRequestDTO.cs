using System;
using System.Collections.Generic;

namespace DTO.Ingeniero.RealizarVisita
{
    public class RealizarVisitaRequestDTO
    {
        public int IdSolicitud { get; set; }

        // Datos verificados en campo
        public decimal? HectareasVerificadas { get; set; }
        public string TipoVegetacionVerificado { get; set; }
        public string PendienteVerificada { get; set; }
        public string RecursoHidricoVerificado { get; set; }
        public int? CantidadNacientesVerificado { get; set; }
        public string UsoSueloVerificado { get; set; }

        // Datos de la visita real
        public DateTime? FechaVisitaReal { get; set; }
        public string HoraInicioReal { get; set; }

        // Observaciones técnicas
        public string ObservacionesTecnicas { get; set; }

        // Decisión final
        public string CalificaParaPago { get; set; }  // "Aprobado" o "Rechazado"

        // Motivo del rechazo - NO REQUERIDO, se valida en Controller solo si es rechazado
        public string RazonRechazo { get; set; }

        // Fotos
        public List<NuevaFotoVisitaDTO> FotosCampo { get; set; }
    }
}