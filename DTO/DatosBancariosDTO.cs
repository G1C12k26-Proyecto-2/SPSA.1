namespace DTO
{
    public class DatosBancariosDTO : BaseClass
    {
        public int UsuarioId { get; set; }
        public string NombreTitular { get; set; } = "";
        public string CedulaTitular { get; set; } = "";
        public string Banco { get; set; } = "";
        public string TipoCuenta { get; set; } = "";
        public string NumeroCuenta { get; set; } = "";
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
