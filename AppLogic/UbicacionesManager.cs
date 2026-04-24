using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public class UbicacionesManager : IUbicacionesManager
    {
        public ApiResponse Resolve(ResolveUbicacionRequestDTO dto)
        {
            try
            {
                var crud = new UbicacionesCrud();
                var result = crud.Resolve(dto);
                return new ApiResponse { Result = "success", Data = result };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = "error", Message = ex.Message };
            }
        }
    }
}