using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoManager _pagoManager;

        public PagoController(IPagoManager pagoManager)
        {
            _pagoManager = pagoManager;
        }

        [HttpGet("GetAll")]
        public ApiResponse GetAll()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _pagoManager.GetAll();
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