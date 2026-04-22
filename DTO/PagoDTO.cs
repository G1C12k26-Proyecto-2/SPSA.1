namespace DTO
{
    public class PagoDTO : BaseClass
    {
        public int? SolicitudId { get; set; }
        public string? FincaNombre { get; set; }
        public string? PropietarioNombre { get; set; }
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? Distrito { get; set; }
        public decimal Hectareas { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public decimal MontoBase { get; set; }
        public decimal PorcentajeAjuste { get; set; }
        public decimal MontoTotal { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCalculo { get; set; }
        public DateTime? FechaProcesado { get; set; }
        public string? Observaciones { get; set; }
        public string? UsuarioProcesa { get; set; }
    }
}