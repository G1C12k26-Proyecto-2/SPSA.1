using System.Collections.Generic;

namespace DTO.Ingeniero
{
    public class IngenieroDashboardDTO
    {
        public ResumenEstadisticasIngenieroDTO Resumen { get; set; }
        public List<SolicitudRecienteIngenieroDTO> SolicitudesRecientes { get; set; }
        public List<AgendaProximaIngenieroDTO> AgendaProxima { get; set; }
        public ResumenMensualIngenieroDTO ResumenMensual { get; set; }
    }
}