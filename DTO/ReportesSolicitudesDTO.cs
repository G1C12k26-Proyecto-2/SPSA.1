namespace DTO
{
    public class ReportesSolicitudesDTO : BaseClass
    {
        public string? NombreFinca { get; set; }
        public string? Propietario { get; set; }
        public string? Email { get; set; }
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? PagoMensual { get; set; }
        public decimal? HectareasOriginal { get; set; }
        public string? TipoVegetacionOriginal { get; set; }
        public string? IngenieroNombre { get; set; }
    }
}