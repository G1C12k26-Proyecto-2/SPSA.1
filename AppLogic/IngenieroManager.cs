using API.Interfaces;
using AppLogic.Interfaces;
using DataAccess.Crud;
using DataAccess.Dao;
using DTO.Ingeniero;
using DTO.Ingeniero.RealizarVisita;
using System;
using System.Threading.Tasks;

namespace AppLogic
{
    public class IngenieroManager : IIngenieroManager
    {
        private readonly IngenieroCrud _ingenieroCrud;
        private readonly ICloudinaryStorageService _cloudinaryService;

        public IngenieroManager(ICloudinaryStorageService cloudinaryService)
        {
            _ingenieroCrud = new IngenieroCrud();
            _cloudinaryService = cloudinaryService;
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
        public async Task<List<SolicitudPendienteDTO>> GetSolicitudesPendientesAsync(int ingenieroId)
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.GetSolicitudesPendientes(ingenieroId));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener solicitudes pendientes: {ex.Message}", ex);
            }
        }

        public async Task<ProgramarVisitaResponseDTO> ProgramarVisitaAsync(int ingenieroId, ProgramarVisitaRequestDTO request)
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.ProgramarVisita(ingenieroId, request));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al programar visita: {ex.Message}", ex);
            }
        }
        public async Task<DatosSolicitudVisitaDTO> GetSolicitudParaRealizarVisitaAsync(int idSolicitud)
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.GetSolicitudParaRealizarVisita(idSolicitud));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener solicitud: {ex.Message}", ex);
            }
        }

        public async Task<ParametrosConfiguracionDTO> GetParametrosConfiguracionAsync()
        {
            try
            {
                return await Task.Run(() => _ingenieroCrud.GetParametrosConfiguracion());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener parámetros: {ex.Message}", ex);
            }
        }

        public async Task<RealizarVisitaResponseDTO> GuardarRealizarVisitaAsync(int ingenieroId, RealizarVisitaRequestDTO request)
        {
            try
            {
                // 1. Guardar la evaluación (SP_UPSERT_DETALLE_SOLICITUD)
                var guardado = await Task.Run(() => _ingenieroCrud.GuardarRealizarVisita(ingenieroId, request));

                // 2. Procesar las fotos si existen
                if (request.FotosCampo != null && request.FotosCampo.Any())
                {
                    foreach (var foto in request.FotosCampo)
                    {
                        if (!string.IsNullOrEmpty(foto.Base64Content))
                        {
                            // Subir a Cloudinary
                            var uploadResult = await _cloudinaryService.UploadImageFromBase64Async(
                                foto.Base64Content,
                                foto.NombreArchivo,
                                $"solicitudes/{request.IdSolicitud}"
                            );

                            // Guardar en BD usando el CRUD
                            if (uploadResult.Success)
                            {
                                _ingenieroCrud.GuardarFotoSolicitud(
                                    request.IdSolicitud,
                                    ingenieroId,
                                    uploadResult.Url,  // 👈 extraer la URL del DTO
                                    foto.NombreArchivo,
                                    foto.TipoArchivo
                                );
                            }
                        }
                    }
                }

                return new RealizarVisitaResponseDTO
                {
                    Exito = true,
                    Mensaje = request.CalificaParaPago == "Aprobado" ? "Solicitud aprobada exitosamente" : "Solicitud rechazada",
                    IdSolicitud = request.IdSolicitud,
                    NuevoEstado = request.CalificaParaPago == "Aprobado" ? "Aprobada" : "Rechazada"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar: {ex.Message}", ex);
            }
        }
    }
}
