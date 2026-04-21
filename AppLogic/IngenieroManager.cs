using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO.Ingeniero;
using System;
using System.Threading.Tasks;

namespace AppLogic
{
    public class IngenieroManager : IIngenieroManager
    {
        private readonly IngenieroCrud _ingenieroCrud;

        public IngenieroManager()
        {
            _ingenieroCrud = new IngenieroCrud();
        }

        public async Task<IngenieroDashboardDTO> GetDashboardAsync(int ingenieroId)
        {
            try
            {
                var dashboard = await Task.Run(() => _ingenieroCrud.GetDashboard(ingenieroId));
                return dashboard;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener dashboard del ingeniero: {ex.Message}", ex);
            }
        }

        public async Task<DetalleSolicitudCompletoDTO> GetDetalleSolicitudCompletoAsync(int idSolicitud)
        {
            try
            {
                var detalle = await Task.Run(() => _ingenieroCrud.GetDetalleSolicitudCompleto(idSolicitud));
                return detalle;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalle de la solicitud: {ex.Message}", ex);
            }
        }

        public async Task<AgendaCompletaDTO> GetAgendaCompletaAsync(int ingenieroId, int anio, int mes)
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.GetAgendaCompleta(ingenieroId, anio, mes));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener agenda: {ex.Message}", ex);
            }
        }
        public async Task<List<VisitaDiaDTO>> GetVisitasDiaAsync(int ingenieroId, DateTime fecha)
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.GetVisitasDia(ingenieroId, fecha));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener visitas del día: {ex.Message}", ex);
            }
        }
    }
}