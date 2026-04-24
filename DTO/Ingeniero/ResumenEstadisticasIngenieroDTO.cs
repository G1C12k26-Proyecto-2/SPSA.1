namespace DTO.Ingeniero
{
    public class ResumenEstadisticasIngenieroDTO
    {
        public int TotalSolicitudes { get; set; }
        public int Pendientes { get; set; }
        public int EnProceso { get; set; }
        public int Aprobadas { get; set; }
        public int Rechazadas { get; set; }
    }
}