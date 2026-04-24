using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace AppLogic.Interfaces
{
    public interface ISolicitudManager
    {
        ApiResponse Create(CreateSolicitudDTO dto);
        ApiResponse GetById(int idSolicitud);
        ApiResponse GetByUsuario(int usuarioId);
        ApiResponse Update(UpdateSolicitudDTO dto);
    }
}