namespace DTO
{
    public class AuditoriaDTO : BaseClass
    {
        public string? Accion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaCambio { get; set; }
        public string? Modulo { get; set; }
        public string? Entidad { get; set; }
        public int? EntidadId { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdUsuario { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Usuario { get; set; }
        public string? EstadoNuevo { get; set; }
        public string? EstadoNuevoNombre { get; set; }
        public string? EstadoAnterior { get; set; }
        public string? EstadoAnteriorNombre { get; set; }
        public string? Motivo { get; set; }
    }
}