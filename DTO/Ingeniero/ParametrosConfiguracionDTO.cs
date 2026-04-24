using System.Collections.Generic;

namespace DTO.Ingeniero.RealizarVisita
{
    public class ParametrosConfiguracionDTO
    {
        public decimal PrecioBaseHectarea { get; set; }
        public int TopeMaximoAjuste { get; set; }
        public int AjusteRiosQuebradas { get; set; }
        public int AjustePorNaciente { get; set; }
        public Dictionary<string, int> AjustesVegetacion { get; set; }
        public Dictionary<string, int> AjustesPendiente { get; set; }
    }
}