namespace DTO.Ingeniero.RealizarVisita
{
    public class NuevaFotoVisitaDTO
    {
        public string NombreArchivo { get; set; }
        public string Base64Content { get; set; }  // Imagen en Base64
        public string TipoArchivo { get; set; }    // "foto_visita" o "evidencia_campo"
    }
}