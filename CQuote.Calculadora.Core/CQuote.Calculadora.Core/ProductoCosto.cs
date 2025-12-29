namespace CQuote.Calculadora.Core
{
    public class ProductoCosto
    {
        public decimal CostoUnitario { get; set; }
        public decimal FactorLista { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }

        public ProductoCosto(decimal costoUnitario, decimal factorLista, decimal impuesto, decimal descuento)
        {
            CostoUnitario = costoUnitario;
            FactorLista = factorLista;
            Impuesto = impuesto;
            Descuento = descuento;
        }
    }
}
