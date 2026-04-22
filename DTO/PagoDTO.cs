namespace DTO
{
    public class PagoDTO : BaseClass
    {
        public string? NombreFinca { get; set; }
        public string? Propietario { get; set; }
        public string? Email { get; set; }
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? Distrito { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal? PagoMensual { get; set; }
        public DateTime? FechaVisitaReal { get; set; }
        public DateTime? FechaEvaluacion { get; set; }
        public string? IngenieroNombre { get; set; }
        public decimal? HectareasVerificadas { get; set; }
        public string? TipoVegetacionVerificado { get; set; }
        public string? PendienteVerificada { get; set; }
        public string? UsoSueloVerificado { get; set; }
        public string? ObservacionesTecnicas { get; set; }
    }
}