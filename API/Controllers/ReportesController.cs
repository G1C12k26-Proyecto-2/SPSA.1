using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReportesManager _reportesManager;

        public ReportesController(IReportesManager reportesManager)
        {
            _reportesManager = reportesManager;
        }

        [HttpGet("GetPagos")]
        public ApiResponse GetPagos()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _reportesManager.GetReportesPagos();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetSolicitudes")]
        public ApiResponse GetSolicitudes()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _reportesManager.GetReportesSolicitudes();
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