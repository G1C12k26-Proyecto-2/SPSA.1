namespace DTO
{
    public class ReportesSolicitudesDTO : BaseClass
    {
        public string? NombreFinca { get; set; }
        public string? Propietario { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? PagoMensual { get; set; }
    }
}