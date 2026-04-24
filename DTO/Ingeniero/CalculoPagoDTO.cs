namespace DTO.Ingeniero
{
    public class CalculoPagoDTO
    {
        // Valores base
        public decimal PrecioBaseHectarea { get; set; }
        public decimal HectareasUtilizadas { get; set; }
        public decimal MontoBase { get; set; }

        // Datos de vegetación
        public string TipoVegetacion { get; set; }
        public decimal PorcentajeVegetacion { get; set; }
        public decimal MontoAjusteVegetacion { get; set; }

        // Datos de pendiente
        public string Pendiente { get; set; }
        public decimal PorcentajePendiente { get; set; }
        public decimal MontoAjustePendiente { get; set; }

        // Datos de recursos hídricos
        public bool TieneRiosQuebradas { get; set; }
        public int CantidadNacientes { get; set; }
        public decimal PorcentajeHidrico { get; set; }
        public decimal MontoAjusteHidrico { get; set; }

        // Totales
        public decimal PorcentajeAjusteTotal { get; set; }
        public decimal TopeAplicado { get; set; }
        public decimal MontoTotalMensual { get; set; }

        // Error
        public string Error { get; set; }

        // Propiedades calculadas para el frontend
        public string Moneda { get; set; } = "₡";

        public string MontoBaseFormateado => $"{Moneda} {MontoBase:N0}";
        public string MontoTotalFormateado => $"{Moneda} {MontoTotalMensual:N0}";
        public string MontoAjusteVegetacionFormateado => $"{Moneda} {MontoAjusteVegetacion:N0}";
        public string MontoAjustePendienteFormateado => $"{Moneda} {MontoAjustePendiente:N0}";
        public string MontoAjusteHidricoFormateado => $"{Moneda} {MontoAjusteHidrico:N0}";

        // Porcentaje total aplicado (con tope)
        public decimal PorcentajeAplicado => PorcentajeAjusteTotal;

        // Monto total del ajuste
        public decimal MontoAjuste => MontoAjusteVegetacion + MontoAjustePendiente + MontoAjusteHidrico;
        public string MontoAjusteFormateado => $"{Moneda} {MontoAjuste:N0}";
    }
}