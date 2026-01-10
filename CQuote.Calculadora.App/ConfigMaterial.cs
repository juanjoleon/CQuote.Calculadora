namespace CQuote.Calculadora.App
{
    public class ConfigMaterial
    {
        public string? Num { get; set; }          // Número del material
        public string? Descripcion { get; set; }  // Descripción del material
        public decimal CostoProveedor { get; set; } // Costo proveedor dinámico
        public decimal CostoImportacion { get; set; } // Importacion
        public decimal Factor1 { get; set; } // Factor
        public decimal Factor2 { get; set; } // Factor2
        public decimal Factor3 { get; set; } // Factor3
        public decimal Desperdicio { get; set; } // Desperdicio
        // Factores de corte
        public decimal FactorCorte1 { get; set; }
        public decimal FactorCorte2 { get; set; }
        public decimal FactorCorte3 { get; set; }
        // Nuevo: Costo del proceso de corte
        public decimal CostoProcesoCorte { get; set; }
        public string? TipoTemplado { get; set; } // Tipo de templado para proceso térmico
        public decimal Espesor { get; set; } // Espesor del material
        public string? Moneda { get; set; } // Moneda del costo proveedor
        public string? TipoCanto { get; set; } // Tipo de canto para cristal
        public decimal PerimetroTotal { get; set; } // Perímetro total (ml)
        public decimal AreaTotal { get; set; } // Área total (m2)
    }
}
