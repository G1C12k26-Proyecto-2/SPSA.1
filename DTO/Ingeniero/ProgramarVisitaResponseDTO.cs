namespace DTO.Ingeniero
{
    public class ProgramarVisitaResponseDTO
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int IdEvento { get; set; }
        public int IdSolicitud { get; set; }
        public string NuevoEstado { get; set; }
    }
}