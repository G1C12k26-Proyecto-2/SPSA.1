using System;

namespace DTO.Ingeniero
{
    public class HistorialEstadoDTO
    {
        public int IdAuditoria { get; set; }
        public int EntidadId { get; set; }
        public int IdSolicitud { get; set; }
        public int EstadoAnterior { get; set; }
        public string EstadoAnteriorNombre { get; set; }
        public int EstadoNuevo { get; set; }
        public string EstadoNuevoNombre { get; set; }
        public string Motivo { get; set; }
        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaCambio { get; set; }

        // Propiedades adicionales para el frontend
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public string Entidad { get; set; }

        // Icono según el tipo de acción
        public string Icono
        {
            get
            {
                if (EstadoNuevoNombre?.Contains("Solicitud") == true) return "📄";
                if (EstadoNuevoNombre?.Contains("Visita") == true) return "📅";
                if (EstadoNuevoNombre?.Contains("Proceso") == true) return "🔄";
                if (EstadoNuevoNombre?.Contains("Aprobada") == true) return "✅";
                if (EstadoNuevoNombre?.Contains("Rechazada") == true) return "❌";
                if (Entidad == "DETALLE_SOLICITUD") return "📋";
                return "📌";
            }
        }
    }
}