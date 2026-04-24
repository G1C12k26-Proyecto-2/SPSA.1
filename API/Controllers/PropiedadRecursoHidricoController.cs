using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadRecursoHidricoController : ControllerBase
    {
        [HttpPost]
        public ApiResponse Create([FromBody] PropiedadRecursoHidrico recurso)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
                manager.Create(recurso);

                response.Result = "ok";
                response.Message = "Recurso hídrico de propiedad creado correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut]
        public ApiResponse Update([FromBody] PropiedadRecursoHidrico recurso)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
                manager.Update(recurso);

                response.Result = "ok";
                response.Message = "Recurso hídrico de propiedad actualizado correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpDelete]
        public ApiResponse Delete([FromBody] PropiedadRecursoHidrico recurso)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
                manager.Delete(recurso);

                response.Result = "ok";
                response.Message = "Recurso hídrico de propiedad eliminado correctamente.";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("{id}")]
        public ApiResponse RetrieveById(int id)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
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

        [HttpGet]
        public ApiResponse RetrieveAll()
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
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

        [HttpGet("ByPropiedad/{idPropiedad}")]
        public ApiResponse RetrieveByPropiedadId(int idPropiedad)
        {
            var response = new ApiResponse();

            try
            {
                var manager = new PropiedadRecursoHidricoManager();
                var data = manager.RetrieveByPropiedadId(idPropiedad);

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
