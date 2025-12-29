namespace CQuote.Calculadora.Core
{
    public class ProductoResultado
    {
        public decimal M2 { get; set; }
        public decimal ML { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioFinal { get; set; }
        public List<string> Mensajes { get; } = new();
        public List<(string Paso, decimal Valor)> Diagnostico { get; } = new();
    }
}
