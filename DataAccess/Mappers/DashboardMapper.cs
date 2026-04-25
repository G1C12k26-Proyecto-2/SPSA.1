using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class DashboardMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var dashboard = new DashboardDTO();
            dashboard.TotalPendientes = Convert.ToInt32(row["TotalPendientes"]);
            dashboard.TotalEnProceso = Convert.ToInt32(row["TotalEnProceso"]);
            dashboard.TotalAprobadas = Convert.ToInt32(row["TotalAprobadas"]);
            dashboard.TotalRechazadas = Convert.ToInt32(row["TotalRechazadas"]);
            dashboard.TotalSolicitudes = Convert.ToInt32(row["TotalSolicitudes"]);
            dashboard.TotalPagosMenuales = Convert.ToDecimal(row["TotalPagosMensuales"]);
            dashboard.PromedioPagoAprobado = Convert.ToDecimal(row["PromedioPagoAprobado"]);
            return dashboard;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_DASHBOARD_ADMIN";
            return operation;
        }
    }
}