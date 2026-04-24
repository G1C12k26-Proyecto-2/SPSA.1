using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public class SolicitudManager : ISolicitudManager
    {
        private readonly SolicitudCrud _crud;

        public SolicitudManager()
        {
            _crud = new SolicitudCrud();
        }

        public ApiResponse Create(CreateSolicitudDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(dto.NombreFinca))
                {
                    response.Result = "error";
                    response.Message = "El nombre de la finca es requerido.";
                    return response;
                }
                if (dto.UsuarioId <= 0)
                {
                    response.Result = "error";
                    response.Message = "Usuario inválido.";
                    return response;
                }

                int idSolicitud = _crud.CreateAndReturnId(dto);
                if (idSolicitud <= 0)
                {
                    response.Result = "error";
                    response.Message = "No se pudo crear la solicitud.";
                    return response;
                }

                _crud.UpsertDetalle(idSolicitud, dto);

                response.Result = "ok";
                response.Data = idSolicitud;
                response.Message = "Solicitud creada correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiResponse GetById(int idSolicitud)
        {
            var response = new ApiResponse();
            try
            {
                var list = _crud.RetrieveById<SolicitudDTO>(idSolicitud);
                if (list.Count == 0)
                {
                    response.Result = "error";
                    response.Message = "Solicitud no encontrada.";
                    return response;
                }
                response.Result = "ok";
                response.Data = list[0];
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiResponse GetByUsuario(int usuarioId)
        {
            var response = new ApiResponse();
            try
            {
                var list = _crud.RetrieveByUsuario<SolicitudDTO>(usuarioId);
                response.Result = "ok";
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiResponse Update(UpdateSolicitudDTO dto)
        {
            var response = new ApiResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(dto.NombreFinca))
                {
                    response.Result = "error";
                    response.Message = "El nombre de la finca es requerido.";
                    return response;
                }

                _crud.Update(dto);
                _crud.UpsertDetalleUpdate(dto.IdSolicitud, dto);

                response.Result = "ok";
                response.Message = "Solicitud actualizada correctamente.";
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