using System;

namespace DTO.Ingeniero
{
    public class DetalleSolicitudDTO
    {
        // Datos de SOLICITUDES
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? PagoMensual { get; set; }

        // Datos del propietario (Users)
        public int UsuarioId { get; set; }
        public string Propietario { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }  // ← Nuevo
        public string Telefono { get; set; }  // ← Si existe en Users

        // Ubicación
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }
        public int? IdCanton { get; set; }
        public string Canton { get; set; }
        public int? IdDistrito { get; set; }
        public string Distrito { get; set; }
        //public string DireccionExacta { get; set; }

        // Datos del DETALLE_SOLICITUD
        public int? IdDetalle { get; set; }  // ← Nuevo
        public int? IdIngeniero { get; set; }
        public string IngenieroNombre { get; set; }
        public int? IdDueno { get; set; }  // ← Nuevo
        public string DuenoNombre { get; set; }  // ← Nuevo

        // Datos originales
        public decimal? HectareasOriginal { get; set; }
        public string TipoVegetacionOriginal { get; set; }
        public string PendienteOriginal { get; set; }
        public bool? TieneRiosQuebradasOriginal { get; set; }
        public int? CantidadNacientesOriginal { get; set; }
        public string UsoSueloOriginal { get; set; }

        // Datos verificados
        public decimal? HectareasVerificadas { get; set; }
        public string TipoVegetacionVerificado { get; set; }
        public string PendienteVerificada { get; set; }
        public bool? TieneRiosQuebradasVerificado { get; set; }
        public int? CantidadNacientesVerificado { get; set; }
        public string UsoSueloVerificado { get; set; }

        // Datos de visita
        public DateTime? FechaVisitaProgramada { get; set; }
        public DateTime? FechaVisitaReal { get; set; }
        public TimeSpan? HoraInicioVisita { get; set; }
        public TimeSpan? HoraInicioReal { get; set; }
        public int? DuracionEstimada { get; set; }
        public string MedioTransporte { get; set; }
        public string ObjetivoVisita { get; set; }
        public string EquipoMateriales { get; set; }
        public string ObservacionesCoordinacion { get; set; }
        public string ObservacionesTecnicas { get; set; }

        // Evaluación
        public bool? CalificaParaPago { get; set; }
        public string RazonRechazo { get; set; }
        public DateTime? FechaEvaluacion { get; set; }

        // Auditoría
        public DateTime? FechaCreacion { get; set; }  // ← Nuevo
        public DateTime? FechaActualizacion { get; set; }  // ← Nuevo
    }
}