namespace CQuote.Calculadora.Core
{
    public class ProductoEntrada
    {
        public int Num { get; set; }
        public int Cantidad { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public string Lista { get; set; } = string.Empty;

        // Opciones adicionales
        public string? TipoCorte { get; set; }
        public string? TipoMaquinado { get; set; }
        public string? ProcesoTermico { get; set; }
        public string? Impresion { get; set; }

        public ProductoEntrada(int num, int cantidad, decimal alto, decimal ancho, string lista, string? tipoCorte, string? tipoMaquinado, string? procesoTermico, string? impresion)
        {
            Num = num;
            Cantidad = cantidad;
            Alto = alto;
            Ancho = ancho;
            Lista = lista;
            TipoCorte = tipoCorte;
            TipoMaquinado = tipoMaquinado;
            ProcesoTermico = procesoTermico;
            Impresion = impresion;
        }
    }
}
