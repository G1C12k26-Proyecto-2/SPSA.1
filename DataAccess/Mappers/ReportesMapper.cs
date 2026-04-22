using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class ReportesMapper
    {
        public BaseClass BuildSolicitudObject(Dictionary<string, object> row)
        {
            var solicitud = new ReportesSolicitudesDTO();
            solicitud.Id = Convert.ToInt32(row["IdSolicitud"]);
            solicitud.NombreFinca = row["NombreFinca"].ToString();
            solicitud.Propietario = row["Propietario"] == DBNull.Value ? null : row["Propietario"].ToString();
            solicitud.Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString();
            solicitud.Provincia = row["Provincia"] == DBNull.Value ? null : row["Provincia"].ToString();
            solicitud.Canton = row["Canton"] == DBNull.Value ? null : row["Canton"].ToString();
            solicitud.Estado = row["Estado"].ToString();
            solicitud.FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"]);
            solicitud.PagoMensual = row["PagoMensual"] == DBNull.Value ? null : Convert.ToDecimal(row["PagoMensual"]);
            solicitud.HectareasOriginal = row["HectareasOriginal"] == DBNull.Value ? null : Convert.ToDecimal(row["HectareasOriginal"]);
            solicitud.TipoVegetacionOriginal = row["TipoVegetacionOriginal"] == DBNull.Value ? null : row["TipoVegetacionOriginal"].ToString();
            solicitud.IngenieroNombre = row["IngenieroNombre"] == DBNull.Value ? null : row["IngenieroNombre"].ToString();
            return solicitud;
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

        public SqlOperation GetReportesSolicitudesStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_ALL_SOLICITUDES";
            return operation;
        }
    }
}