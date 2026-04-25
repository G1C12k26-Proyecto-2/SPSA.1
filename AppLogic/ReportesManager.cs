using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IReportesManager
    {
        List<ReportesSolicitudesDTO> GetReportesSolicitudes();
        void UpdateStatusSolicitud(UpdateStatusDTO dto);
    }

    public class ReportesManager : IReportesManager
    {
        public List<ReportesSolicitudesDTO> GetReportesSolicitudes()
        {
            var crud = new ReportesCrud();
            return crud.GetReportesSolicitudes();
        }

        public void UpdateStatusSolicitud(UpdateStatusDTO dto)
        {
            var crud = new UpdateStatusCrud();
            crud.UpdateStatus(dto);
        }
    }
}