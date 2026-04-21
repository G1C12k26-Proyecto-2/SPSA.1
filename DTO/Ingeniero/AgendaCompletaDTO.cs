using System.Collections.Generic;

namespace DTO.Ingeniero
{
    public class AgendaCompletaDTO
    {
        public List<EventoCalendarioDTO> EventosMes { get; set; }
        public List<VisitaDiaDTO> VisitasHoy { get; set; }
        public DateTime FechaActual { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int TotalVisitasMes { get; set; }
        public int TotalPendientes { get; set; }
        public int TotalEnProceso { get; set; }
    }
}