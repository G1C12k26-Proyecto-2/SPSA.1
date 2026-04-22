namespace DTO
{
    public class DashboardDTO : BaseClass
    {
        public int TotalPendientes { get; set; }
        public int TotalEnProceso { get; set; }
        public int TotalAprobadas { get; set; }
        public int TotalRechazadas { get; set; }
        public int TotalSolicitudes { get; set; }
        public decimal TotalPagosMenuales { get; set; }
        public decimal PromedioPagoAprobado { get; set; }
    }
}