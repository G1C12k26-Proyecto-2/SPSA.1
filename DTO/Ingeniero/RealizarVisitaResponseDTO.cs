using System.Collections.Generic;

namespace DTO.Ingeniero.RealizarVisita
{
    public class RealizarVisitaResponseDTO
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int IdSolicitud { get; set; }
        public string NuevoEstado { get; set; }
        public List<string> FotosSubidas { get; set; }  // URLs de las fotos guardadas
    }
}