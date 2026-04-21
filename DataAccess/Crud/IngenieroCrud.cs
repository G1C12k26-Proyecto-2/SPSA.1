using DataAccess.Dao;
using DataAccess.Mappers;
using DTO.Ingeniero;
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
    }
}