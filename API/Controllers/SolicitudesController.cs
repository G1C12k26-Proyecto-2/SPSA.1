using AppLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudManager _solicitudManager;

        public SolicitudesController(ISolicitudManager solicitudManager)
        {
            _solicitudManager = solicitudManager;
        }

        [HttpPost("Create")]
        public ApiResponse Create([FromBody] CreateSolicitudDTO dto)
            => _solicitudManager.Create(dto);

        [HttpGet("GetById/{id}")]
        public ApiResponse GetById(int id)
            => _solicitudManager.GetById(id);

        [HttpGet]
        public ApiResponse GetByUsuario([FromQuery] int usuarioId)
            => _solicitudManager.GetByUsuario(usuarioId);

        [HttpPut("Update")]
        public ApiResponse Update([FromBody] UpdateSolicitudDTO dto)
            => _solicitudManager.Update(dto);
    }
}