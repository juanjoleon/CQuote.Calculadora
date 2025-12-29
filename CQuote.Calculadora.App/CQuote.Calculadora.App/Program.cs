using CQuote.Calculadora.Core;

class Program
{
    static void Main()
    {
        var calc = new CalculadoraPrecios();

        var entrada = new ProductoEntrada(
            1001, // Num
            2,    // Cantidad
            1.2m, // Alto
            0.8m, // Ancho
            "A", // Lista
            "Recto", // TipoCorte
            "Pulido", // TipoMaquinado
            "Templado", // ProcesoTermico
            "Ninguna" // Impresion
        );

        var costo = new ProductoCosto(
            250m,   // CostoUnitario
            1.35m,  // FactorLista
            0.16m,  // Impuesto
            0m      // Descuento
        );

        var resultado = calc.Calcular(entrada, costo);

        Console.WriteLine($"M2: {resultado.M2}");
        Console.WriteLine($"ML: {resultado.ML}");
        Console.WriteLine($"SubTotal: {resultado.SubTotal}");
        Console.WriteLine($"PrecioFinal: {resultado.PrecioFinal}");

        if (resultado.Mensajes.Count > 0)
        {
            Console.WriteLine("Advertencias:");
            foreach (var msg in resultado.Mensajes)
                Console.WriteLine($"- {msg}");
        }

        Console.WriteLine("Diagnóstico paso a paso:");
        foreach (var paso in resultado.Diagnostico)
            Console.WriteLine($"{paso.Paso}: {paso.Valor}");
    }
}
