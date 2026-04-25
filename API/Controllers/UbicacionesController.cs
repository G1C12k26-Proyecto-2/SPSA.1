using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionesManager _ubicacionesManager;

        public UbicacionesController(IUbicacionesManager ubicacionesManager)
        {
            _ubicacionesManager = ubicacionesManager;
        }

        [HttpPost("Resolve")]
        public ApiResponse Resolve([FromBody] ResolveUbicacionRequestDTO dto)
            => _ubicacionesManager.Resolve(dto);
    }
}