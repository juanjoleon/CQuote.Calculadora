namespace CQuote.Calculadora.Core
{
    public class CalculadoraPrecios
    {
        public ProductoResultado Calcular(ProductoEntrada entrada, ProductoCosto costo)
        {
            var resultado = new ProductoResultado();

            if (entrada.Num <= 0)
                resultado.Mensajes.Add("Num es obligatorio y debe ser > 0.");
            if (entrada.Cantidad <= 0)
                resultado.Mensajes.Add("Cantidad debe ser > 0.");
            if (entrada.Alto <= 0 || entrada.Ancho <= 0)
                resultado.Mensajes.Add("Medidas deben ser > 0.");
            if (string.IsNullOrWhiteSpace(entrada.Lista))
                resultado.Mensajes.Add("Lista es obligatoria.");

            if (resultado.Mensajes.Count > 0) return resultado;

            resultado.M2 = Math.Round(entrada.Alto * entrada.Ancho, 4);
            resultado.Diagnostico.Add(("M2", resultado.M2));

            resultado.ML = Math.Round(2 * (entrada.Alto + entrada.Ancho), 4);
            resultado.Diagnostico.Add(("ML", resultado.ML));

            var baseQty = resultado.M2;
            resultado.SubTotal = Math.Round(costo.CostoUnitario * entrada.Cantidad * baseQty, 2);
            resultado.Diagnostico.Add(("SubTotal", resultado.SubTotal));

            var precioLista = resultado.SubTotal * costo.FactorLista;
            var conImpuesto = precioLista * (1 + costo.Impuesto);
            resultado.PrecioFinal = Math.Round(conImpuesto - costo.Descuento, 2);
            resultado.Diagnostico.Add(("PrecioFinal", resultado.PrecioFinal));

            return resultado;
        }
    }
}
