using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IReportesManager
    {
        List<ReportesSolicitudesDTO> GetReportesSolicitudes();
    }

    public class ReportesManager : IReportesManager
    {
        public List<ReportesSolicitudesDTO> GetReportesSolicitudes()
        {
            var crud = new ReportesCrud();
            return crud.GetReportesSolicitudes();
        }
    }
}