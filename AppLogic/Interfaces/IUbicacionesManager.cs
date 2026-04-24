using DTO;

namespace AppLogic.Interfaces
{
    public interface IUbicacionesManager
    {
        ApiResponse Resolve(ResolveUbicacionRequestDTO dto);
    }
}