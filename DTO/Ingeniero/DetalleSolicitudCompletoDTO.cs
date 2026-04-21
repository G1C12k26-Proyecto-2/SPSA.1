namespace DTO.Ingeniero
{
    public class DetalleSolicitudCompletoDTO
    {
        public DetalleSolicitudDTO Detalle { get; set; }
        public DetalleArchivosDTO Archivos { get; set; }
        public DetalleHistorialDTO Historial { get; set; }
        public DetalleCalculoPagoDTO CalculoPago { get; set; }
    }
}