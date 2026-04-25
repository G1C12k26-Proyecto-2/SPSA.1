using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IAuditoriaManager
    {
        List<AuditoriaDTO> GetAll();
        AuditoriaDTO GetById(int pId);
    }

    public class AuditoriaManager : IAuditoriaManager
    {
        public List<AuditoriaDTO> GetAll()
        {
            var crud = new AuditoriaCrud();
            return crud.RetrieveAll<AuditoriaDTO>();
        }

        public AuditoriaDTO GetById(int pId)
        {
            var crud = new AuditoriaCrud();
            var results = crud.RetrieveById<AuditoriaDTO>(pId);
            return results.FirstOrDefault();
        }
    }
}