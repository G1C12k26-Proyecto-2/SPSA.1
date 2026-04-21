using AppLogic;
using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngenieroController : ControllerBase
    {
        private readonly IIngenieroManager _ingenieroManager;

        public IngenieroController()
        {
            _ingenieroManager = new IngenieroManager();
        }

        [HttpGet("Ingeniero/{ingenieroId}")]
        public async Task<IActionResult> GetDashboard(int ingenieroId)
        {
            try
            {
                //SE DEBE BORRAR ESTA LINEA
                ingenieroId = 57;//SE DEBE BORRAR ESTA LINEA
                //SE DEBE BORRAR ESTA LINEA
                var dashboard = await _ingenieroManager.GetDashboardAsync(ingenieroId);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = dashboard,
                    Message = "Dashboard cargado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar el dashboard: {ex.Message}"
                });
            }
        }
        [HttpGet("solicitud/{idSolicitud}")]
        public async Task<IActionResult> GetDetalleSolicitud(int idSolicitud)
        {
            try
            {
                var detalle = await _ingenieroManager.GetDetalleSolicitudCompletoAsync(idSolicitud);

                if (detalle?.Detalle?.IdSolicitud == 0)
                {
                    return NotFound(new ApiResponse
                    {
                        Result = "ERROR",
                        Message = $"No se encontró la solicitud con ID {idSolicitud}"
                    });
                }

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = detalle,
                    Message = "Detalle cargado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar el detalle: {ex.Message}"
                });
            }
        }
        [HttpGet("agenda/{ingenieroId}")]
        public async Task<IActionResult> GetAgenda(int ingenieroId, [FromQuery] int anio, [FromQuery] int mes)
        {
            try
            {

                //SE DEBE BORRAR ESTA LINEA
                ingenieroId = 57;//SE DEBE BORRAR ESTA LINEA
                //SE DEBE BORRAR ESTA LINEA

                // Si no se especifican año y mes, usar el actual
                if (anio == 0) anio = DateTime.Now.Year;
                if (mes == 0) mes = DateTime.Now.Month;

                var agenda = await _ingenieroManager.GetAgendaCompletaAsync(ingenieroId, anio, mes);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = agenda,
                    Message = "Agenda cargada exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar la agenda: {ex.Message}"
                });
            }
        }
        // GET: api/Ingeniero/agenda/{ingenieroId}/dia?fecha=2026-04-20
        [HttpGet("agenda/{ingenieroId}/dia")]
        public async Task<IActionResult> GetVisitasDia(int ingenieroId, [FromQuery] DateTime fecha)
        {
            try
            {
                //SE DEBE BORRAR ESTA LINEA
                ingenieroId = 57;//SE DEBE BORRAR ESTA LINEA
                //SE DEBE BORRAR ESTA LINEA

                var visitas = await _ingenieroManager.GetVisitasDiaAsync(ingenieroId, fecha);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = new { visitas = visitas },
                    Message = "Visitas del día cargadas exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar las visitas: {ex.Message}"
                });
            }
        }
    }
}