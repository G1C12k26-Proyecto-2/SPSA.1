using DTO.Ingeniero;
using DTO.Ingeniero.RealizarVisita;
using DTO.Ingeniero.Solicitud;
using System.Threading.Tasks;

namespace AppLogic.Interfaces
{
    public interface IIngenieroManager
    {
        Task<IngenieroDashboardDTO> GetDashboardAsync(int ingenieroId);
        Task<DetalleSolicitudCompletoDTO> GetDetalleSolicitudCompletoAsync(int idSolicitud);
        Task<AgendaCompletaDTO> GetAgendaCompletaAsync(int ingenieroId, int anio, int mes);
        Task<List<VisitaDiaDTO>> GetVisitasDiaAsync(int ingenieroId, DateTime fecha);
        Task<List<SolicitudPendienteDTO>> GetSolicitudesPendientesAsync(int ingenieroId);
        Task<ProgramarVisitaResponseDTO> ProgramarVisitaAsync(int ingenieroId, ProgramarVisitaRequestDTO request);
        Task<DatosSolicitudVisitaDTO> GetSolicitudParaRealizarVisitaAsync(int idSolicitud);
        Task<ParametrosConfiguracionDTO> GetParametrosConfiguracionAsync();
        Task<RealizarVisitaResponseDTO> GuardarRealizarVisitaAsync(int ingenieroId, RealizarVisitaRequestDTO request);

    }
}