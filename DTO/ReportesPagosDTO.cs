namespace DTO
{
    public class ReportesPagosDTO : BaseClass
    {
        public string? FincaNombre { get; set; }
        public string? PropietarioNombre { get; set; }
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public decimal Hectareas { get; set; }
        public decimal MontoBase { get; set; }
        public decimal PorcentajeAjuste { get; set; }
        public decimal MontoTotal { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaCalculo { get; set; }
        public string? UsuarioProcesa { get; set; }
    }
}