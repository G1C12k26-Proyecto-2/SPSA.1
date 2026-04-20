using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IReportesManager
    {
        List<ReportesPagosDTO> GetReportesPagos();
        List<ReportesSolicitudesDTO> GetReportesSolicitudes();
    }

    public class ReportesManager : IReportesManager
    {
        public List<ReportesPagosDTO> GetReportesPagos()
        {
            var crud = new ReportesCrud();
            return crud.GetReportesPagos();
        }

        public List<ReportesSolicitudesDTO> GetReportesSolicitudes()
        {
            var crud = new ReportesCrud();
            return crud.GetReportesSolicitudes();
        }
    }
}