using System;

namespace DTO.Ingeniero.RealizarVisita
{
    public class DatosSolicitudVisitaDTO
    {
        public int IdSolicitud { get; set; }
        public string NombreFinca { get; set; }
        public string Estado { get; set; }
        public string Propietario { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        // Datos originales (para mostrar comparativo)
        public decimal? HectareasOriginal { get; set; }
        public string TipoVegetacionOriginal { get; set; }
        public string PendienteOriginal { get; set; }
        public bool? TieneRiosQuebradasOriginal { get; set; }
        public int? CantidadNacientesOriginal { get; set; }
        public string UsoSueloOriginal { get; set; }

        // Datos de visita programada
        public DateTime? FechaVisitaProgramada { get; set; }
        public TimeSpan? HoraInicioVisita { get; set; }
        public string MedioTransporte { get; set; }
        public string ObjetivoVisita { get; set; }
        public string EquipoMateriales { get; set; }
        public string ObservacionesCoordinacion { get; set; }

        // Ingeniero asignado
        public int? IdIngeniero { get; set; }
        public string IngenieroNombre { get; set; }

        public string UbicacionCompleta => $"{Provincia}, {Canton}, {Distrito}".Trim(',', ' ');
    }
}