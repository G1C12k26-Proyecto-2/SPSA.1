using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {
        [HttpPost("CreatePropiedad")]
        public ApiResponse CreatePropiedad([FromBody] Propiedad propiedad)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                manager.Create(propiedad);

                response.Result = "ok";
                response.Message = "Propiedad creada correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("CreatePropiedadWithRecursos")]
        public ApiResponse CreatePropiedadWithRecursos([FromBody] PropiedadConRecursosDTO dto)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                manager.CreateWithRecursos(dto);

                response.Result = "ok";
                response.Message = "Propiedad y recursos hídricos creados correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut("UpdatePropiedad")]
        public ApiResponse UpdatePropiedad([FromBody] Propiedad propiedad)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                manager.Update(propiedad);

                response.Result = "ok";
                response.Message = "Propiedad actualizada correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpDelete("DeletePropiedad")]
        public ApiResponse DeletePropiedad([FromBody] Propiedad propiedad)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                manager.Delete(propiedad);

                response.Result = "ok";
                response.Message = "Propiedad eliminada correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("GetPropiedadById/{id}")]
        public ApiResponse GetPropiedadById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                var data = manager.RetrieveById(id);

                response.Result = "ok";
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("GetPropiedadDetalleById/{id}")]
        public ApiResponse GetPropiedadDetalleById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                var data = manager.RetrieveByIdWithDetail(id);

                response.Result = "ok";
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("GetAllPropiedades")]
        public ApiResponse GetAllPropiedades()
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                var data = manager.RetrieveAll();

                response.Result = "ok";
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("GetAllPropiedadesDetalle")]
        public ApiResponse GetAllPropiedadesDetalle()
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadManager();
                var data = manager.RetrieveAllWithDetail();

                response.Result = "ok";
                response.Data = data;
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