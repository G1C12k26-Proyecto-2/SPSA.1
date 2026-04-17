namespace DTO
{
    public class DashboardDTO : BaseClass
    {
        public int TotalUsuarios { get; set; }
        public int UsuariosActivos { get; set; }
        public int TotalFincas { get; set; }
        public int SolicitudesPendientes { get; set; }
        public int PagosDelMes { get; set; }
        public decimal MontoPagosDelMes { get; set; }
    }
}