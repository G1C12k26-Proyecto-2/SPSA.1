using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public class DatosBancariosManager
    {
        private readonly DatosBancariosCrud _crud;

        public DatosBancariosManager()
        {
            _crud = new DatosBancariosCrud();
        }

        public ApiResponse GetByUsuario(int usuarioId)
        {
            var response = new ApiResponse();
            try
            {
                var dto = _crud.GetByUsuario(usuarioId);
                if (dto == null)
                {
                    response.Result = "error";
                    response.Message = "No se encontraron datos bancarios para el usuario.";
                    return response;
                }
                response.Result = "ok";
                response.Data = dto;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiResponse Insert(DatosBancariosDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                _crud.Insert(dto);
                response.Result = "ok";
                response.Message = "Datos bancarios registrados correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiResponse Upsert(DatosBancariosDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                var existing = _crud.GetByUsuario(dto.UsuarioId);
                if (existing != null)
                {
                    _crud.Update(dto);
                    response.Message = "Datos bancarios actualizados correctamente.";
                }
                else
                {
                    _crud.Insert(dto);
                    response.Message = "Datos bancarios registrados correctamente.";
                }
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
