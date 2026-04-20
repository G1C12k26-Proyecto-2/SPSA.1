namespace DTO
{
    public class AuditoriaDTO : BaseClass
    {
        public int UsuarioId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Modulo { get; set; }
        public string? Accion { get; set; }
        public string? Descripcion { get; set; }
        public string? IpAddress { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}