using AppLogic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DatosBancariosController : ControllerBase
    {
        private readonly DatosBancariosManager _manager;

        public DatosBancariosController(DatosBancariosManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetByUsuario/{usuarioId}")]
        public ApiResponse GetByUsuario(int usuarioId)
            => _manager.GetByUsuario(usuarioId);

        [HttpPost("Upsert")]
        public ApiResponse Upsert([FromBody] DatosBancariosDTO dto)
            => _manager.Upsert(dto);
    }
}
