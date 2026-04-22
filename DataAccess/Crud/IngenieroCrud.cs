using DataAccess.Dao;
using DataAccess.Mappers;
using DTO.Ingeniero;
using DTO.Ingeniero.RealizarVisita;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class IngenieroCrud : CrudFactory
    {
        private readonly IngenieroMapper _mapper;

        public IngenieroCrud()
        {
            _sqlDao = SqlDao.GetInstance();
            _mapper = new IngenieroMapper();
        }

        public override void Create(DTO.BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(DTO.BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(DTO.BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            throw new NotImplementedException();
        }

        // ========== MÉTODOS PARA DASHBOARD USANDO MAPPER ==========

        public ResumenEstadisticasIngenieroDTO GetResumenEstadisticas(int ingenieroId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_DASHBOARD_INGENIERO"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);

            return _mapper.MapToResumenEstadisticas(result);
        }

        public List<SolicitudRecienteIngenieroDTO> GetSolicitudesRecientes(int ingenieroId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_SOLICITUDES_BY_INGENIERO"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);

            return _mapper.MapToSolicitudesRecientes(result);
        }

        public List<AgendaProximaIngenieroDTO> GetAgendaProxima(int ingenieroId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PROXIMAS_VISITAS"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);

            return _mapper.MapToAgendaProxima(result);
        }

        public ResumenMensualIngenieroDTO GetResumenMensual(int ingenieroId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_RESUMEN_MENSUAL_INGENIERO"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);

            return _mapper.MapToResumenMensual(result);
        }

        public IngenieroDashboardDTO GetDashboard(int ingenieroId)
        {
            var resumen = GetResumenEstadisticas(ingenieroId);
            var solicitudesRecientes = GetSolicitudesRecientes(ingenieroId);
            var agendaProxima = GetAgendaProxima(ingenieroId);
            var resumenMensual = GetResumenMensual(ingenieroId);

            return _mapper.MapToDashboard(resumen, solicitudesRecientes, agendaProxima, resumenMensual);
        }

        public DetalleSolicitudDTO GetDetalleSolicitud(int idSolicitud)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_SOLICITUD_BY_ID"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToDetalleSolicitud(result);
        }

        public DetalleArchivosDTO GetDetalleArchivos(int idSolicitud)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_ARCHIVOS_BY_SOLICITUD"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            var archivos = _mapper.MapToArchivos(result);

            return _mapper.MapToDetalleArchivos(archivos);
        }

        public DetalleHistorialDTO GetDetalleHistorial(int idSolicitud)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_HISTORIAL_SOLICITUD"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            var historial = _mapper.MapToHistorial(result);

            return _mapper.MapToDetalleHistorial(historial);
        }

        public DetalleCalculoPagoDTO GetDetalleCalculoPago(int idSolicitud)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_CALCULAR_PAGO_EN_TIEMPO_REAL"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            var calculoPago = _mapper.MapToCalculoPago(result);

            return _mapper.MapToDetalleCalculoPago(calculoPago);
        }

        
        public DetalleSolicitudCompletoDTO GetDetalleSolicitudCompleto(int idSolicitud)
        {
            var detalle = GetDetalleSolicitud(idSolicitud);
            var archivos = GetDetalleArchivos(idSolicitud);
            var historial = GetDetalleHistorial(idSolicitud);
            var calculoPago = GetDetalleCalculoPago(idSolicitud);

            return _mapper.MapToDetalleSolicitudCompleto(detalle, archivos, historial, calculoPago);
        }

        public List<EventoCalendarioDTO> GetEventosCalendario(int ingenieroId, int anio, int mes)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_AGENDA_CALENDARIO"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);
            operation.AddIntParam("Anio", anio);
            operation.AddIntParam("Mes", mes);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToEventosCalendario(result);
        }

        public List<VisitaDiaDTO> GetVisitasDia(int ingenieroId, DateTime? fecha = null)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_AGENDA_DIA"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            if (fecha.HasValue)
            {
                operation.AddDateTimeParam("Fecha", fecha.Value);
            }

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToVisitasDia(result);
        }

        public AgendaCompletaDTO GetAgendaCompleta(int ingenieroId, int anio, int mes)
        {
            var eventosMes = GetEventosCalendario(ingenieroId, anio, mes);
            var visitasHoy = GetVisitasDia(ingenieroId, DateTime.Now);

            return _mapper.MapToAgendaCompleta(eventosMes, visitasHoy, mes, anio);
        }
        public List<SolicitudPendienteDTO> GetSolicitudesPendientes(int ingenieroId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_SOLICITUDES_PENDIENTES"
            };
            operation.AddIntParam("IdIngeniero", ingenieroId);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToSolicitudesPendientes(result);
        }

        public ProgramarVisitaResponseDTO ProgramarVisita(int ingenieroId, ProgramarVisitaRequestDTO request)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_PROGRAMAR_VISITA"
            };
            operation.AddIntParam("IdSolicitud", request.IdSolicitud);
            operation.AddIntParam("IdIngeniero", ingenieroId);
            operation.AddDateTimeParam("FechaVisita", request.FechaVisita);
            operation.AddTimeParam("HoraInicio", request.HoraInicio);
            operation.AddIntParam("DuracionEstimada", request.DuracionEstimada);
            operation.AddVarcharParam("MedioTransporte", request.MedioTransporte);
            operation.AddVarcharParam("ObjetivoVisita", request.ObjetivoVisita);
            operation.AddVarcharParam("EquipoMateriales", request.EquipoMateriales ?? "");
            operation.AddVarcharParam("ObservacionesCoordinacion", request.ObservacionesCoordinacion ?? "");

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);

            int idEvento = 0;
            if (result != null && result.Count > 0)
            {
                idEvento = Convert.ToInt32(result[0]["IdEvento"]);
            }

            return new ProgramarVisitaResponseDTO
            {
                Exito = true,
                Mensaje = "Visita programada exitosamente",
                IdEvento = idEvento,
                IdSolicitud = request.IdSolicitud,
                NuevoEstado = "En Proceso"
            };
        }
        // ========== MÉTODOS PARA EVALUACIÓN TÉCNICA ==========

        public DatosSolicitudVisitaDTO GetSolicitudParaRealizarVisita(int idSolicitud)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_SOLICITUD_BY_ID"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToDatosSolicitudVisita(result);
        }

        public ParametrosConfiguracionDTO GetParametrosConfiguracion()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_GET_PARAMETROS_CONFIGURACION"
            };

            var result = _sqlDao.ExecuteProcedureWithQuery(operation);
            return _mapper.MapToParametrosConfiguracion(result);
        }

        public bool GuardarRealizarVisita(int ingenieroId, RealizarVisitaRequestDTO request)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_UPSERT_DETALLE_SOLICITUD"
            };

            operation.AddIntParam("IdSolicitud", request.IdSolicitud);
            operation.AddIntParam("IdIngeniero", ingenieroId);

            // Datos verificados
            if (request.HectareasVerificadas.HasValue)
                operation.AddDecimalParam("HectareasVerificadas", request.HectareasVerificadas.Value);

            if (!string.IsNullOrEmpty(request.TipoVegetacionVerificado))
                operation.AddVarcharParam("TipoVegetacionVerificado", request.TipoVegetacionVerificado);

            if (!string.IsNullOrEmpty(request.PendienteVerificada))
                operation.AddVarcharParam("PendienteVerificada", request.PendienteVerificada);

            // Recurso hídrico - Convertir a los parámetros que espera el SP
            // El SP espera: @TieneRiosQuebradasVerificado (BIT) y @CantidadNacientesVerificado (INT)
            if (!string.IsNullOrEmpty(request.RecursoHidricoVerificado))
            {
                // Convertir el string a BIT para @TieneRiosQuebradasVerificado
                bool tieneRiosQuebradas = request.RecursoHidricoVerificado == "RIOS_QUEBRADAS";
                operation.AddBitParam("TieneRiosQuebradasVerificado", tieneRiosQuebradas);

                // Si es NACIENTES, enviar la cantidad (o 1 por defecto)
                if (request.RecursoHidricoVerificado == "NACIENTES")
                {
                    int cantidad = request.CantidadNacientesVerificado ?? 1;
                    operation.AddIntParam("CantidadNacientesVerificado", cantidad);
                }
                else
                {
                    // Si no es NACIENTES, enviar 0 o null
                    operation.AddIntParam("CantidadNacientesVerificado", 0);
                }
            }
            else
            {
                // Si no viene recurso hídrico, enviar valores por defecto
                operation.AddBitParam("TieneRiosQuebradasVerificado", false);
                operation.AddIntParam("CantidadNacientesVerificado", 0);
            }

            if (!string.IsNullOrEmpty(request.UsoSueloVerificado))
                operation.AddVarcharParam("UsoSueloVerificado", request.UsoSueloVerificado);

            if (request.FechaVisitaReal.HasValue)
                operation.AddDateTimeParam("FechaVisitaReal", request.FechaVisitaReal.Value);

            if (!string.IsNullOrEmpty(request.HoraInicioReal))
            {
                TimeSpan hora = TimeSpan.Parse(request.HoraInicioReal);
                operation.AddTimeParam("HoraInicioReal", hora);
            }

            if (!string.IsNullOrEmpty(request.ObservacionesTecnicas))
                operation.AddVarcharParam("ObservacionesTecnicas", request.ObservacionesTecnicas);

            // CalificaParaPago - Enviar como VARCHAR
            if (!string.IsNullOrEmpty(request.CalificaParaPago))
                operation.AddVarcharParam("CalificaParaPago", request.CalificaParaPago);

            if (!string.IsNullOrEmpty(request.RazonRechazo))
                operation.AddVarcharParam("RazonRechazo", request.RazonRechazo);

            _sqlDao.ExecuteProcedure(operation);
            return true;
        }

        public bool ActualizarEstadoSolicitud(int idSolicitud, string nuevoEstado, string razon = null)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SP_UPDATE_STATUS_SOLICITUD"
            };
            operation.AddIntParam("IdSolicitud", idSolicitud);
            operation.AddVarcharParam("NuevoEstado", nuevoEstado);
            if (!string.IsNullOrEmpty(razon))
                operation.AddVarcharParam("RazonRechazo", razon);

            _sqlDao.ExecuteProcedure(operation);
            return true;
        }
       
    }
}