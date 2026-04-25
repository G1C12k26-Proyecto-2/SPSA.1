using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaManager _auditoriaManager;

        public AuditoriaController(IAuditoriaManager auditoriaManager)
        {
            _auditoriaManager = auditoriaManager;
        }

        [HttpGet("GetAll")]
        public ApiResponse GetAll()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _auditoriaManager.GetAll();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetById")]
        public ApiResponse GetById(int pId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _auditoriaManager.GetById(pId);
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