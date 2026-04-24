using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroController : ControllerBase
    {
        [HttpGet("GetAllParametros")]
        public ApiResponse GetAllParametros()
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
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

        [HttpGet("GetParametroById/{id}")]
        public ApiResponse GetParametroById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
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

        [HttpGet("GetParametrosByCategoria/{categoria}")]
        public ApiResponse GetParametrosByCategoria(string categoria)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
                var data = manager.RetrieveByCategoria(categoria);

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

        [HttpGet("GetParametroByClave/{clave}")]
        public ApiResponse GetParametroByClave(string clave)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
                var data = manager.RetrieveByClave(clave);

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

        [HttpPut("UpdateParametro")]
        public ApiResponse UpdateParametro([FromBody] ParametroUpdateDTO dto)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
                manager.UpdateParametro(dto);

                response.Result = "ok";
                response.Message = "Parámetro actualizado correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("CreateParametro")]
        public ApiResponse CreateParametro([FromBody] ParametroDTO parametro)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new ParametroManager();
                manager.Create(parametro);

                response.Result = "ok";
                response.Message = "Parámetro creado correctamente.";
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
