using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IPagoManager
    {
        List<PagoDTO> GetAll();
    }

    public class PagoManager : IPagoManager
    {
        public List<PagoDTO> GetAll()
        {
            var crud = new PagoCrud();
            return crud.RetrieveAll<PagoDTO>();
        }
    }
}