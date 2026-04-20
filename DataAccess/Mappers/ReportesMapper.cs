using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class ReportesMapper
    {
        public BaseClass BuildPagoObject(Dictionary<string, object> row)
        {
            var pago = new ReportesPagosDTO();
            pago.Id = Convert.ToInt32(row["IdPago"]);
            pago.FincaNombre = row["FincaNombre"].ToString();
            pago.PropietarioNombre = row["PropietarioNombre"].ToString();
            pago.Provincia = row["Provincia"] == DBNull.Value ? null : row["Provincia"].ToString();
            pago.Canton = row["Canton"] == DBNull.Value ? null : row["Canton"].ToString();
            pago.Hectareas = Convert.ToDecimal(row["Hectareas"]);
            pago.MontoBase = Convert.ToDecimal(row["MontoBase"]);
            pago.PorcentajeAjuste = Convert.ToDecimal(row["PorcentajeAjuste"]);
            pago.MontoTotal = Convert.ToDecimal(row["MontoTotal"]);
            pago.Estado = row["Estado"].ToString();
            pago.FechaCalculo = Convert.ToDateTime(row["FechaCalculo"]);
            pago.UsuarioProcesa = row["UsuarioProcesa"] == DBNull.Value ? null : row["UsuarioProcesa"].ToString();
            return pago;
        }

        public BaseClass BuildSolicitudObject(Dictionary<string, object> row)
        {
            var solicitud = new ReportesSolicitudesDTO();
            solicitud.Id = Convert.ToInt32(row["IdSolicitud"]);
            solicitud.NombreFinca = row["NombreFinca"].ToString();
            solicitud.Propietario = row["Propietario"] == DBNull.Value ? null : row["Propietario"].ToString();
            solicitud.Estado = row["Estado"].ToString();
            solicitud.FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"]);
            solicitud.PagoMensual = row["PagoMensual"] == DBNull.Value ? null : Convert.ToDecimal(row["PagoMensual"]);
            return solicitud;
        }

        public List<BaseClass> BuildPagoObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows)
            {
                results.Add(BuildPagoObject(row));
            }
            return results;
        }

        public List<BaseClass> BuildSolicitudObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows)
            {
                results.Add(BuildSolicitudObject(row));
            }
            return results;
        }

        public SqlOperation GetReportesPagosStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Reportes_Pagos";
            return operation;
        }

        public SqlOperation GetReportesSolicitudesStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Reportes_Solicitudes";
            return operation;
        }
    }
}