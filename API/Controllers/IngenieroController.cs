using AppLogic;
using AppLogic.Interfaces;
using DTO;
using DTO.Ingeniero;
using DTO.Ingeniero.RealizarVisita;
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
        private readonly ICloudinaryService _cloudinaryService;  // ← Agregar

        // Modificar constructor
        public IngenieroController(ICloudinaryService cloudinaryService)  
        {
            _ingenieroManager = new IngenieroManager(cloudinaryService);  
            _cloudinaryService = cloudinaryService;
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
        // GET: api/Ingeniero/solicitudes/pendientes/{ingenieroId}
        [HttpGet("solicitudes/pendientes/{ingenieroId}")]
        public async Task<IActionResult> GetSolicitudesPendientes(int ingenieroId)
        {
            try
            {
                //SE DEBE BORRAR ESTA LINEA
                ingenieroId = 57;//SE DEBE BORRAR ESTA LINEA

                var solicitudes = await _ingenieroManager.GetSolicitudesPendientesAsync(ingenieroId);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = solicitudes,
                    Message = "Solicitudes pendientes cargadas exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar solicitudes pendientes: {ex.Message}"
                });
            }
        }

        // POST: api/Ingeniero/visita/programar
        [HttpPost("visita/programar")]
        public async Task<IActionResult> ProgramarVisita([FromBody] ProgramarVisitaRequestDTO request)
        {
            try
            {
                //SE DEBE BORRAR ESTA LINEA
                int ingenieroId = 57;//SE DEBE BORRAR ESTA LINEA
                //SE DEBE BORRAR ESTA LINEA

                var resultado = await _ingenieroManager.ProgramarVisitaAsync(ingenieroId, request);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = resultado,
                    Message = resultado.Mensaje
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al programar visita: {ex.Message}"
                });
            }
        }
        [HttpGet("realizar-visita/{idSolicitud}")]
        public async Task<IActionResult> GetSolicitudParaRealizarVisita(int idSolicitud)
        {
            try
            {
                var solicitud = await _ingenieroManager.GetSolicitudParaRealizarVisitaAsync(idSolicitud);

                if (solicitud?.IdSolicitud == 0)
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
                    Data = solicitud,
                    Message = "Datos cargados exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar los datos: {ex.Message}"
                });
            }
        }

        [HttpGet("realizar-visita/parametros")]
        public async Task<IActionResult> GetParametrosConfiguracion()
        {
            try
            {
                var parametros = await _ingenieroManager.GetParametrosConfiguracionAsync();

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = parametros,
                    Message = "Parámetros cargados exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al cargar parámetros: {ex.Message}"
                });
            }
        }

        [HttpPost("realizar-visita/guardar")]
        public async Task<IActionResult> GuardarRealizarVisita([FromBody] RealizarVisitaRequestDTO request)
        {
            try
            {
                int ingenieroId = 57; // SE DEBE BORRAR - Obtener del token

                var resultado = await _ingenieroManager.GuardarRealizarVisitaAsync(ingenieroId, request);

                return Ok(new ApiResponse
                {
                    Result = "SUCCESS",
                    Data = resultado,
                    Message = resultado.Mensaje
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Result = "ERROR",
                    Message = $"Error al guardar: {ex.Message}"
                });
            }
        }
    }
}