using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class PagoMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var pago = new PagoDTO();
            pago.Id = Convert.ToInt32(row["IdSolicitud"]);
            pago.NombreFinca = row["NombreFinca"].ToString();
            pago.Propietario = row["Propietario"] == DBNull.Value ? null : row["Propietario"].ToString();
            pago.Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString();
            pago.Provincia = row["Provincia"] == DBNull.Value ? null : row["Provincia"].ToString();
            pago.Canton = row["Canton"] == DBNull.Value ? null : row["Canton"].ToString();
            pago.Distrito = row["Distrito"] == DBNull.Value ? null : row["Distrito"].ToString();
            pago.Estado = row["Estado"].ToString();
            pago.FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"]);
            pago.PagoMensual = row["PagoMensual"] == DBNull.Value ? null : Convert.ToDecimal(row["PagoMensual"]);
            pago.FechaVisitaReal = row["FechaVisitaReal"] == DBNull.Value ? null : Convert.ToDateTime(row["FechaVisitaReal"]);
            pago.FechaEvaluacion = row["FechaEvaluacion"] == DBNull.Value ? null : Convert.ToDateTime(row["FechaEvaluacion"]);
            pago.IngenieroNombre = row["IngenieroNombre"] == DBNull.Value ? null : row["IngenieroNombre"].ToString();
            pago.HectareasVerificadas = row["HectareasVerificadas"] == DBNull.Value ? null : Convert.ToDecimal(row["HectareasVerificadas"]);
            pago.TipoVegetacionVerificado = row["TipoVegetacionVerificado"] == DBNull.Value ? null : row["TipoVegetacionVerificado"].ToString();
            pago.PendienteVerificada = row["PendienteVerificada"] == DBNull.Value ? null : row["PendienteVerificada"].ToString();
            pago.UsoSueloVerificado = row["UsoSueloVerificado"] == DBNull.Value ? null : row["UsoSueloVerificado"].ToString();
            pago.ObservacionesTecnicas = row["ObservacionesTecnicas"] == DBNull.Value ? null : row["ObservacionesTecnicas"].ToString();
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
            operation.ProcedureName = "SP_GET_SOLICITUDES_APROBADAS";
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_SOLICITUDES_APROBADAS";
            return operation;
        }
    }
}