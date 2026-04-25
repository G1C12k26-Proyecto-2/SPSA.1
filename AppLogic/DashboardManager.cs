using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IDashboardManager
    {
        DashboardDTO GetDashboard();
    }

    public class DashboardManager : IDashboardManager
    {
        public DashboardDTO GetDashboard()
        {
            var crud = new DashboardCrud();
            var results = crud.RetrieveAll<DashboardDTO>();
            return results.FirstOrDefault();
        }
    }
}