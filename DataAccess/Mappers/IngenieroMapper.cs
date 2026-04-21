using DTO.Ingeniero;
using System;
using System.Collections.Generic;

namespace DataAccess.Mappers
{
    public class IngenieroMapper
    {
        public ResumenEstadisticasIngenieroDTO MapToResumenEstadisticas(List<Dictionary<string, object>> result)
        {
            var resumen = new ResumenEstadisticasIngenieroDTO();

            if (result != null && result.Count > 0)
            {
                var row = result[0];

                // Calcular TotalSolicitudes sumando todos los estados
                int pendientes = Convert.ToInt32(row["Pendientes"]);
                int enProceso = Convert.ToInt32(row["EnProceso"]);
                int aprobadas = Convert.ToInt32(row["Aprobadas"]);
                int rechazadas = Convert.ToInt32(row["Rechazadas"]);

                resumen.TotalSolicitudes = pendientes + enProceso + aprobadas + rechazadas;
                resumen.Pendientes = pendientes;
                resumen.EnProceso = enProceso;
                resumen.Aprobadas = aprobadas;
                resumen.Rechazadas = rechazadas;
            }

            return resumen;
        }

        public List<SolicitudRecienteIngenieroDTO> MapToSolicitudesRecientes(List<Dictionary<string, object>> result)
        {
            var solicitudes = new List<SolicitudRecienteIngenieroDTO>();

            if (result != null)
            {
                foreach (var row in result)
                {
                    string provincia = row["Provincia"]?.ToString() ?? "";
                    string canton = row["Canton"]?.ToString() ?? "";
                    string distrito = row["Distrito"]?.ToString() ?? "";

                    string ubicacion = $"{provincia}, {canton}, {distrito}".TrimStart(',', ' ').TrimEnd(',', ' ');

                    var solicitud = new SolicitudRecienteIngenieroDTO
                    {
                        IdSolicitud = Convert.ToInt32(row["IdSolicitud"]),
                        NombreFinca = row["NombreFinca"]?.ToString() ?? "",
                        Propietario = row["Propietario"]?.ToString() ?? "",
                        Ubicacion = ubicacion,
                        Hectareas = Convert.ToDecimal(row["HectareasOriginal"]),
                        TipoVegetacion = row["TipoVegetacionOriginal"]?.ToString() ?? "",
                        Estado = row["Estado"]?.ToString() ?? "",
                        FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"])
                    };
                    solicitudes.Add(solicitud);
                }
            }

            return solicitudes;
        }

        public List<AgendaProximaIngenieroDTO> MapToAgendaProxima(List<Dictionary<string, object>> result)
        {
            var agenda = new List<AgendaProximaIngenieroDTO>();

            if (result != null)
            {
                foreach (var row in result)
                {
                    var evento = new AgendaProximaIngenieroDTO
                    {
                        IdEvento = Convert.ToInt32(row["IdEvento"]),
                        IdSolicitud = Convert.ToInt32(row["IdSolicitud"]),
                        NombreFinca = row["NombreFinca"]?.ToString() ?? "",
                        Ubicacion = row["Ubicacion"]?.ToString() ?? "",
                        FechaVisita = Convert.ToDateTime(row["FechaVisita"]),
                        HoraInicio = TimeSpan.Parse(row["HoraInicio"].ToString()),
                        Estado = row["Estado"]?.ToString() ?? ""
                    };
                    agenda.Add(evento);
                }
            }

            return agenda;
        }

        public ResumenMensualIngenieroDTO MapToResumenMensual(List<Dictionary<string, object>> result)
        {
            var resumen = new ResumenMensualIngenieroDTO();

            if (result != null && result.Count > 0)
            {
                var row = result[0];
                resumen.FincasEvaluadas = Convert.ToInt32(row["FincasEvaluadas"]);
                resumen.HectareasEvaluadas = Convert.ToDecimal(row["HectareasEvaluadas"]);
                resumen.TasaAprobacion = Convert.ToDecimal(row["TasaAprobacion"]);
                resumen.TiempoPromedioDias = Convert.ToDecimal(row["TiempoPromedioDias"]);
            }

            return resumen;
        }

        public IngenieroDashboardDTO MapToDashboard(
            ResumenEstadisticasIngenieroDTO resumen,
            List<SolicitudRecienteIngenieroDTO> solicitudesRecientes,
            List<AgendaProximaIngenieroDTO> agendaProxima,
            ResumenMensualIngenieroDTO resumenMensual)
        {
            return new IngenieroDashboardDTO
            {
                Resumen = resumen,
                SolicitudesRecientes = solicitudesRecientes,
                AgendaProxima = agendaProxima,
                ResumenMensual = resumenMensual
            };
        }
        public DetalleSolicitudDTO MapToDetalleSolicitud(List<Dictionary<string, object>> result)
        {
            var solicitud = new DetalleSolicitudDTO();

            if (result == null || result.Count == 0) return solicitud;

            var row = result[0];

            // ===== DATOS DE LA SOLICITUD =====
            solicitud.IdSolicitud = Convert.ToInt32(row["IdSolicitud"]);
            solicitud.NombreFinca = row["NombreFinca"]?.ToString() ?? "";
            solicitud.Estado = row["Estado"]?.ToString() ?? "";  // ← Estado viene de SOLICITUDES
            solicitud.FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"]);
            solicitud.PagoMensual = row["PagoMensual"] != DBNull.Value ? Convert.ToDecimal(row["PagoMensual"]) : (decimal?)null;

            // ===== DATOS DEL PROPIETARIO =====
            solicitud.UsuarioId = Convert.ToInt32(row["UsuarioId"]);
            solicitud.Propietario = row["Propietario"]?.ToString() ?? "";
            solicitud.Email = row["Email"]?.ToString() ?? "";
            
            // ===== UBICACIÓN =====
            solicitud.IdProvincia = row["IdProvincia"] != DBNull.Value ? Convert.ToInt32(row["IdProvincia"]) : (int?)null;
            solicitud.Provincia = row["Provincia"]?.ToString() ?? "";
            solicitud.IdCanton = row["IdCanton"] != DBNull.Value ? Convert.ToInt32(row["IdCanton"]) : (int?)null;
            solicitud.Canton = row["Canton"]?.ToString() ?? "";
            solicitud.IdDistrito = row["IdDistrito"] != DBNull.Value ? Convert.ToInt32(row["IdDistrito"]) : (int?)null;
            solicitud.Distrito = row["Distrito"]?.ToString() ?? "";
//            solicitud.DireccionExacta = row["DireccionExacta"]?.ToString() ?? "";

            // ===== DATOS ORIGINALES (del dueño) =====
            solicitud.HectareasOriginal = row["HectareasOriginal"] != DBNull.Value ? Convert.ToDecimal(row["HectareasOriginal"]) : (decimal?)null;
            solicitud.TipoVegetacionOriginal = row["TipoVegetacionOriginal"]?.ToString() ?? "";
            solicitud.PendienteOriginal = row["PendienteOriginal"]?.ToString() ?? "";
            solicitud.TieneRiosQuebradasOriginal = row["TieneRiosQuebradasOriginal"] != DBNull.Value ? Convert.ToBoolean(row["TieneRiosQuebradasOriginal"]) : (bool?)null;
            solicitud.CantidadNacientesOriginal = row["CantidadNacientesOriginal"] != DBNull.Value ? Convert.ToInt32(row["CantidadNacientesOriginal"]) : (int?)null;
            solicitud.UsoSueloOriginal = row["UsoSueloOriginal"]?.ToString() ?? "";

            // ===== DATOS VERIFICADOS (por el ingeniero) =====
            solicitud.HectareasVerificadas = row["HectareasVerificadas"] != DBNull.Value ? Convert.ToDecimal(row["HectareasVerificadas"]) : (decimal?)null;
            solicitud.TipoVegetacionVerificado = row["TipoVegetacionVerificado"]?.ToString() ?? "";
            solicitud.PendienteVerificada = row["PendienteVerificada"]?.ToString() ?? "";
            solicitud.TieneRiosQuebradasVerificado = row["TieneRiosQuebradasVerificado"] != DBNull.Value ? Convert.ToBoolean(row["TieneRiosQuebradasVerificado"]) : (bool?)null;
            solicitud.CantidadNacientesVerificado = row["CantidadNacientesVerificado"] != DBNull.Value ? Convert.ToInt32(row["CantidadNacientesVerificado"]) : (int?)null;
            solicitud.UsoSueloVerificado = row["UsoSueloVerificado"]?.ToString() ?? "";

            // ===== DATOS DE LA VISITA =====
            solicitud.FechaVisitaProgramada = row["FechaVisitaProgramada"] != DBNull.Value ? Convert.ToDateTime(row["FechaVisitaProgramada"]) : (DateTime?)null;
            solicitud.FechaVisitaReal = row["FechaVisitaReal"] != DBNull.Value ? Convert.ToDateTime(row["FechaVisitaReal"]) : (DateTime?)null;
            solicitud.HoraInicioVisita = row["HoraInicioVisita"] != DBNull.Value ? TimeSpan.Parse(row["HoraInicioVisita"].ToString()) : (TimeSpan?)null;
            solicitud.HoraInicioReal = row["HoraInicioReal"] != DBNull.Value ? TimeSpan.Parse(row["HoraInicioReal"].ToString()) : (TimeSpan?)null;
            solicitud.DuracionEstimada = row["DuracionEstimada"] != DBNull.Value ? Convert.ToInt32(row["DuracionEstimada"]) : (int?)null;
            solicitud.MedioTransporte = row["MedioTransporte"]?.ToString() ?? "";
            solicitud.ObjetivoVisita = row["ObjetivoVisita"]?.ToString() ?? "";
            solicitud.EquipoMateriales = row["EquipoMateriales"]?.ToString() ?? "";
            solicitud.ObservacionesCoordinacion = row["ObservacionesCoordinacion"]?.ToString() ?? "";
            solicitud.ObservacionesTecnicas = row["ObservacionesTecnicas"]?.ToString() ?? "";

            // ===== EVALUACIÓN =====
            solicitud.CalificaParaPago = row["CalificaParaPago"] != DBNull.Value ? Convert.ToBoolean(row["CalificaParaPago"]) : (bool?)null;
            solicitud.RazonRechazo = row["RazonRechazo"]?.ToString() ?? "";
            solicitud.FechaEvaluacion = row["FechaEvaluacion"] != DBNull.Value ? Convert.ToDateTime(row["FechaEvaluacion"]) : (DateTime?)null;

            // ===== INGENIERO ASIGNADO =====
            solicitud.IdIngeniero = row["IdIngeniero"] != DBNull.Value ? Convert.ToInt32(row["IdIngeniero"]) : (int?)null;
            solicitud.IngenieroNombre = row["IngenieroNombre"]?.ToString() ?? "";

            return solicitud;
        }

        public DetalleArchivosDTO MapToDetalleArchivos(List<ArchivosDTO> archivos)
        {
            return new DetalleArchivosDTO
            {
                Archivos = archivos ?? new List<ArchivosDTO>()
            };
        }

        public DetalleHistorialDTO MapToDetalleHistorial(List<HistorialEstadoDTO> historial)
        {
            return new DetalleHistorialDTO
            {
                Historial = historial ?? new List<HistorialEstadoDTO>()
            };
        }

        public DetalleCalculoPagoDTO MapToDetalleCalculoPago(CalculoPagoDTO calculoPago)
        {
            return new DetalleCalculoPagoDTO
            {
                CalculoPago = calculoPago ?? new CalculoPagoDTO()
            };
        }

        public DetalleSolicitudCompletoDTO MapToDetalleSolicitudCompleto(
            DetalleSolicitudDTO detalle,
            DetalleArchivosDTO archivos,
            DetalleHistorialDTO historial,
            DetalleCalculoPagoDTO calculoPago)
        {
            return new DetalleSolicitudCompletoDTO
            {
                Detalle = detalle,
                Archivos = archivos,
                Historial = historial,
                CalculoPago = calculoPago
            };
        }

        public List<ArchivosDTO> MapToArchivos(List<Dictionary<string, object>> result)
        {
            var archivos = new List<ArchivosDTO>();

            if (result == null) return archivos;

            foreach (var row in result)
            {
                var archivo = new ArchivosDTO
                {
                    IdArchivo = Convert.ToInt32(row["IdArchivo"]),
                    IdDetalle = Convert.ToInt32(row["IdDetalle"]),
                    TipoArchivo = row["TipoArchivo"]?.ToString() ?? "",
                    NombreArchivo = row["NombreArchivo"]?.ToString() ?? "",
                    UrlArchivo = row["UrlArchivo"]?.ToString() ?? "",
                    FechaSubida = Convert.ToDateTime(row["FechaSubida"])
                };
                archivos.Add(archivo);
            }

            return archivos;
        }

        public List<HistorialEstadoDTO> MapToHistorial(List<Dictionary<string, object>> result)
        {
            var historial = new List<HistorialEstadoDTO>();

            if (result == null) return historial;

            foreach (var row in result)
            {
                var item = new HistorialEstadoDTO
                {
                    IdAuditoria = Convert.ToInt32(row["IdAuditoria"]),
                    EntidadId = row["EntidadId"] != DBNull.Value ? Convert.ToInt32(row["EntidadId"]) : 0,
                    IdSolicitud = row["IdSolicitud"] != DBNull.Value ? Convert.ToInt32(row["IdSolicitud"]) : 0,
                    EstadoAnterior = row["EstadoAnterior"] != DBNull.Value ? Convert.ToInt32(row["EstadoAnterior"]) : 0,
                    EstadoAnteriorNombre = row["EstadoAnteriorNombre"]?.ToString() ?? "",
                    EstadoNuevo = row["EstadoNuevo"] != DBNull.Value ? Convert.ToInt32(row["EstadoNuevo"]) : 0,
                    EstadoNuevoNombre = row["EstadoNuevoNombre"]?.ToString() ?? "",
                    Motivo = row["Motivo"]?.ToString() ?? "",
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    UsuarioNombre = row["UsuarioNombre"]?.ToString() ?? "",
                    FechaCambio = Convert.ToDateTime(row["FechaCambio"]),
                    // Campos adicionales
                    Accion = row["Accion"]?.ToString() ?? "",
                    Descripcion = row["Descripcion"]?.ToString() ?? "",
                    Modulo = row["Modulo"]?.ToString() ?? "",
                    Entidad = row["Entidad"]?.ToString() ?? ""
                };
                historial.Add(item);
            }

            return historial;
        }

        public CalculoPagoDTO MapToCalculoPago(List<Dictionary<string, object>> result)
        {
            var calculo = new CalculoPagoDTO();

            if (result == null || result.Count == 0) return calculo;

            var row = result[0];

            // Verificar si hay error
            if (row.ContainsKey("Error") && row["Error"] != DBNull.Value && !string.IsNullOrEmpty(row["Error"]?.ToString()))
            {
                calculo.Error = row["Error"]?.ToString();
                return calculo;
            }

            // Valores base
            calculo.PrecioBaseHectarea = row["PrecioBaseHectarea"] != DBNull.Value ? Convert.ToDecimal(row["PrecioBaseHectarea"]) : 0;
            calculo.HectareasUtilizadas = row["HectareasUtilizadas"] != DBNull.Value ? Convert.ToDecimal(row["HectareasUtilizadas"]) : 0;
            calculo.MontoBase = row["MontoBase"] != DBNull.Value ? Convert.ToDecimal(row["MontoBase"]) : 0;

            // Vegetación
            calculo.TipoVegetacion = row["TipoVegetacion"]?.ToString() ?? "";
            calculo.PorcentajeVegetacion = row["PorcentajeVegetacion"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajeVegetacion"]) : 0;
            calculo.MontoAjusteVegetacion = row["MontoAjusteVegetacion"] != DBNull.Value ? Convert.ToDecimal(row["MontoAjusteVegetacion"]) : 0;

            // Pendiente
            calculo.Pendiente = row["Pendiente"]?.ToString() ?? "";
            calculo.PorcentajePendiente = row["PorcentajePendiente"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajePendiente"]) : 0;
            calculo.MontoAjustePendiente = row["MontoAjustePendiente"] != DBNull.Value ? Convert.ToDecimal(row["MontoAjustePendiente"]) : 0;

            // Recursos hídricos
            calculo.TieneRiosQuebradas = row["TieneRiosQuebradas"] != DBNull.Value && Convert.ToBoolean(row["TieneRiosQuebradas"]);
            calculo.CantidadNacientes = row["CantidadNacientes"] != DBNull.Value ? Convert.ToInt32(row["CantidadNacientes"]) : 0;
            calculo.PorcentajeHidrico = row["PorcentajeHidrico"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajeHidrico"]) : 0;
            calculo.MontoAjusteHidrico = row["MontoAjusteHidrico"] != DBNull.Value ? Convert.ToDecimal(row["MontoAjusteHidrico"]) : 0;

            // Totales
            calculo.PorcentajeAjusteTotal = row["PorcentajeAjusteTotal"] != DBNull.Value ? Convert.ToDecimal(row["PorcentajeAjusteTotal"]) : 0;
            calculo.TopeAplicado = row["TopeAplicado"] != DBNull.Value ? Convert.ToDecimal(row["TopeAplicado"]) : 0;
            calculo.MontoTotalMensual = row["MontoTotalMensual"] != DBNull.Value ? Convert.ToDecimal(row["MontoTotalMensual"]) : 0;

            return calculo;
        }
        // ========== MAPEOS PARA AGENDA ==========

        public List<EventoCalendarioDTO> MapToEventosCalendario(List<Dictionary<string, object>> result)
        {
            var eventos = new List<EventoCalendarioDTO>();

            if (result == null) return eventos;

            foreach (var row in result)
            {
                var evento = new EventoCalendarioDTO
                {
                    IdEvento = Convert.ToInt32(row["IdEvento"]),
                    IdSolicitud = Convert.ToInt32(row["IdSolicitud"]),
                    NombreFinca = row["NombreFinca"]?.ToString() ?? "",
                    Titulo = row["Titulo"]?.ToString() ?? "",
                    FechaVisita = Convert.ToDateTime(row["FechaVisita"]),
                    HoraInicio = TimeSpan.Parse(row["HoraInicio"].ToString()),
                    DuracionEstimada = row["DuracionEstimada"] != DBNull.Value ? Convert.ToInt32(row["DuracionEstimada"]) : (int?)null,
                    Ubicacion = row["Ubicacion"]?.ToString() ?? "",
                    Notas = row["Notas"]?.ToString() ?? "",
                    Estado = row["Estado"]?.ToString() ?? "",
                    HoraFormateada = row["HoraFormateada"]?.ToString() ?? "",
                    EstadoClase = row["EstadoClase"]?.ToString() ?? "",
                    Propietario = row["Propietario"]?.ToString() ?? "",
                    Provincia = row["Provincia"]?.ToString() ?? "",
                    Canton = row["Canton"]?.ToString() ?? "",
                    Distrito = row["Distrito"]?.ToString() ?? ""
                };
                eventos.Add(evento);
            }

            return eventos;
        }

        public List<VisitaDiaDTO> MapToVisitasDia(List<Dictionary<string, object>> result)
        {
            var visitas = new List<VisitaDiaDTO>();

            if (result == null) return visitas;

            foreach (var row in result)
            {
                var visita = new VisitaDiaDTO
                {
                    IdEvento = Convert.ToInt32(row["IdEvento"]),
                    IdSolicitud = Convert.ToInt32(row["IdSolicitud"]),
                    NombreFinca = row["NombreFinca"]?.ToString() ?? "",
                    Titulo = row["Titulo"]?.ToString() ?? "",
                    FechaVisita = Convert.ToDateTime(row["FechaVisita"]),
                    HoraInicio = TimeSpan.Parse(row["HoraInicio"].ToString()),
                    DuracionEstimada = row["DuracionEstimada"] != DBNull.Value ? Convert.ToInt32(row["DuracionEstimada"]) : (int?)null,
                    Ubicacion = row["Ubicacion"]?.ToString() ?? "",
                    Notas = row["Notas"]?.ToString() ?? "",
                    Estado = row["Estado"]?.ToString() ?? "",
                    Provincia = row["Provincia"]?.ToString() ?? "",
                    Canton = row["Canton"]?.ToString() ?? "",
                    Distrito = row["Distrito"]?.ToString() ?? "",
                    Propietario = row["Propietario"]?.ToString() ?? "",
                    EmailPropietario = row["EmailPropietario"]?.ToString() ?? ""
                };
                visitas.Add(visita);
            }

            return visitas;
        }

        public AgendaCompletaDTO MapToAgendaCompleta(
            List<EventoCalendarioDTO> eventosMes,
            List<VisitaDiaDTO> visitasHoy,
            int mes,
            int anio)
        {
            var totalPendientes = eventosMes.Count(e => e.Estado?.ToLower() == "pendiente");
            var totalEnProceso = eventosMes.Count(e => e.Estado?.ToLower() == "en proceso");

            return new AgendaCompletaDTO
            {
                EventosMes = eventosMes,
                VisitasHoy = visitasHoy,
                FechaActual = DateTime.Now,
                Mes = mes,
                Anio = anio,
                TotalVisitasMes = eventosMes.Count,
                TotalPendientes = totalPendientes,
                TotalEnProceso = totalEnProceso
            };
        }
    }
}