using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class PagoMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var pago = new PagoDTO();
            pago.Id = Convert.ToInt32(row["IdPago"]);
            pago.SolicitudId = row["SolicitudId"] == DBNull.Value ? null : Convert.ToInt32(row["SolicitudId"]);
            pago.FincaNombre = row["FincaNombre"].ToString();
            pago.PropietarioNombre = row["PropietarioNombre"].ToString();
            pago.Provincia = row["Provincia"] == DBNull.Value ? null : row["Provincia"].ToString();
            pago.Canton = row["Canton"] == DBNull.Value ? null : row["Canton"].ToString();
            pago.Distrito = row["Distrito"] == DBNull.Value ? null : row["Distrito"].ToString();
            pago.Hectareas = Convert.ToDecimal(row["Hectareas"]);
            pago.PeriodoInicio = Convert.ToDateTime(row["PeriodoInicio"]);
            pago.PeriodoFin = Convert.ToDateTime(row["PeriodoFin"]);
            pago.MontoBase = Convert.ToDecimal(row["MontoBase"]);
            pago.PorcentajeAjuste = Convert.ToDecimal(row["PorcentajeAjuste"]);
            pago.MontoTotal = Convert.ToDecimal(row["MontoTotal"]);
            pago.Estado = row["Estado"].ToString();
            pago.FechaCalculo = Convert.ToDateTime(row["FechaCalculo"]);
            pago.FechaProcesado = row["FechaProcesado"] == DBNull.Value ? null : Convert.ToDateTime(row["FechaProcesado"]);
            pago.Observaciones = row["Observaciones"] == DBNull.Value ? null : row["Observaciones"].ToString();
            pago.UsuarioProcesa = row["UsuarioProcesa"] == DBNull.Value ? null : row["UsuarioProcesa"].ToString();
            return pago;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Reportes_Pagos";
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Reportes_Pagos";
            return operation;
        }
    }
}