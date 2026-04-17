using DataAccess.Dao;
using DTO;

namespace DataAccess.Mappers
{
    public class DashboardMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var dashboard = new DashboardDTO();
            dashboard.TotalUsuarios = Convert.ToInt32(row["TotalUsuarios"]);
            dashboard.UsuariosActivos = Convert.ToInt32(row["UsuariosActivos"]);
            dashboard.TotalFincas = Convert.ToInt32(row["TotalFincas"]);
            dashboard.SolicitudesPendientes = Convert.ToInt32(row["SolicitudesPendientes"]);
            dashboard.PagosDelMes = Convert.ToInt32(row["PagosDelMes"]);
            dashboard.MontoPagosDelMes = Convert.ToDecimal(row["MontoPagosDelMes"]);
            return dashboard;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_Dashboard_Get";
            return operation;
        }
    }
}