using System;
using System.Linq;

namespace CQuote.Calculadora.Core
{
    public class ProductoResultado
    {
        public decimal PrecioFinal { get; set; }
        public decimal Margen { get; set; }
        public string Detalle { get; set; } = string.Empty;
    }

    public class CalculadoraPrecios
    {
        // --- CRISTAL ---
        public ProductoResultado CalcularCristal(
            decimal costoProveedor,
            decimal costoImportacion,
            decimal factor1,
            decimal factor2,
            decimal factor3,
            decimal merma,
            decimal factorCorte,
            decimal costoProcesoCorte,
            decimal costoProcesoTermico,
            decimal costoImpresion,
            decimal costoCantos,
            decimal costoBarrenos,
            decimal costoAvellanados,
            decimal costoResaques,
            decimal desperdicio,
            int cantidad,
            decimal margen,
            decimal areaTotal,
            decimal perimetroTotal,
            int barrenosTotales,
            int avellanadosTotales,
            int resaquesTotales)
        {
            var costoBase = costoProveedor + costoImportacion;
            var r1 = costoBase / factor1;
            var r2 = r1 / factor2;
            var r3 = r2 * factor3;
            var r4 = r3 * merma;

            var laminaConDesperdicio = (r3 * merma) / (1 - desperdicio);
            var corteAjustado = laminaConDesperdicio + (costoProcesoCorte * factorCorte);
            var conProcesoTermico = corteAjustado + costoProcesoTermico;
            var subtotal = conProcesoTermico;

            var mermaTotal = 0.95m;
            var costoTotalPvaM2 = subtotal / mermaTotal;
            var precioPvaM2 = costoTotalPvaM2 / (1 - margen);

            var costoCantosM2 = areaTotal > 0 ? (costoCantos * perimetroTotal) / areaTotal : 0;
            var costoBarrenosM2 = areaTotal > 0 ? (costoBarrenos * barrenosTotales) / areaTotal : 0;
            var costoAvellanadosM2 = areaTotal > 0 ? (costoAvellanados * avellanadosTotales) / areaTotal : 0;
            var costoResaquesM2 = areaTotal > 0 ? (costoResaques * resaquesTotales) / areaTotal : 0;
            var costoMaquinadosM2 = costoBarrenosM2 + costoAvellanadosM2 + costoResaquesM2;

            var costoTotal = costoTotalPvaM2 + costoImpresion + costoCantosM2 + costoMaquinadosM2;

            var precioImpresion = costoImpresion / (1 - margen);
            var precioCantosM2 = costoCantosM2 / (1 - margen);
            var precioBarrenosM2 = costoBarrenosM2 / (1 - margen);
            var precioAvellanadosM2 = costoAvellanadosM2 / (1 - margen);
            var precioResaquesM2 = costoResaquesM2 / (1 - margen);
            var precioMaquinadosM2 = precioBarrenosM2 + precioAvellanadosM2 + precioResaquesM2;
            var precioOtrosProcesos = precioImpresion + precioCantosM2 + precioMaquinadosM2;

            var precioTotal = precioPvaM2 + precioOtrosProcesos;
            var margenTotal = (precioTotal - costoTotal) / precioTotal;

            var detalle =
                $"--- CRISTAL ---\n" +
                $"Costo proveedor: {costoProveedor}\n" +
                $"Costo importación: {costoImportacion}\n" +
                $"Costo base: {costoBase}\n" +
                $"Paso 1: costoBase / factor1 = {r1}\n" +
                $"Paso 2: r1 / factor2 = {r2}\n" +
                $"Paso 3: r2 * factor3 = {r3}\n" +
                $"Paso 4: r3 * merma = {r4}\n" +
                $"Lámina con desperdicio: (r3 * merma) / (1 - desperdicio) = {laminaConDesperdicio}\n" +
                $"Corte ajustado: laminaConDesperdicio + (costoProcesoCorte * factorCorte) = {corteAjustado}\n" +
                $"Con proceso térmico: corteAjustado + costoProcesoTermico = {conProcesoTermico}\n" +
                $"Subtotal: {subtotal}\n" +
                $"Merma total: {mermaTotal}\n" +
                $"Costo total PVA m2: subtotal / mermaTotal = {costoTotalPvaM2}\n" +
                $"Precio PVA m2: costoTotalPvaM2 / (1 - margen) = {precioPvaM2}\n" +
                $"Costo cantos m2: {costoCantosM2}\n" +
                $"Costo barrenos m2: {costoBarrenosM2}\n" +
                $"Costo avellanados m2: {costoAvellanadosM2}\n" +
                $"Costo resaques m2: {costoResaquesM2}\n" +
                $"Costo maquinados m2: {costoMaquinadosM2}\n" +
                $"Costo total: {costoTotal}\n" +
                $"Precio impresión: {precioImpresion}\n" +
                $"Precio cantos m2: {precioCantosM2}\n" +
                $"Precio barrenos m2: {precioBarrenosM2}\n" +
                $"Precio avellanados m2: {precioAvellanadosM2}\n" +
                $"Precio resaques m2: {precioResaquesM2}\n" +
                $"Precio maquinados m2: {precioMaquinadosM2}\n" +
                $"Precio otros procesos: {precioOtrosProcesos}\n" +
                $"Precio total cristal: {precioTotal}\n" +
                $"Margen total: {margenTotal:P}";

            return new ProductoResultado { PrecioFinal = precioTotal, Margen = margenTotal, Detalle = detalle };
        }

        // --- PELÍCULA ---
        public ProductoResultado CalcularPelicula(
            decimal costoProveedor,
            decimal costoImportacion,
            decimal factor1,
            decimal factor2,
            decimal factor3,
            decimal desperdicio,
            decimal margen)
        {
            var costoBase = costoProveedor + costoImportacion;
            var r1 = costoBase / factor1;
            var r2 = r1 / factor2;
            var r3 = r2 * factor3;

            var costoPelicula = r3 / (1 - desperdicio);
            var precioPelicula = costoPelicula / (1 - margen);

            var detalle =
                $"--- PELÍCULA ---\n" +
                $"Costo proveedor: {costoProveedor}\n" +
                $"Costo importación: {costoImportacion}\n" +
                $"Costo base: {costoBase}\n" +
                $"Paso 1: costoBase / factor1 = {r1}\n" +
                $"Paso 2: r1 / factor2 = {r2}\n" +
                $"Paso 3: r2 * factor3 = {r3}\n" +
                $"Costo película con desperdicio: r3 / (1 - desperdicio) = {costoPelicula}\n" +
                $"Precio película: costoPelicula / (1 - margen) = {precioPelicula}";

            return new ProductoResultado { PrecioFinal = precioPelicula, Margen = margen, Detalle = detalle };
        }

        // --- SEPARADOR ---
        public ProductoResultado CalcularSeparador(
            decimal costoProveedor,
            decimal costoImportacion,
            decimal factor1,
            decimal factor2,
            decimal factor3,
            decimal margen,
            decimal areaTotal,
            decimal perimetroTotal)
        {
            var costoBase = costoProveedor + costoImportacion;
            var r1 = costoBase / factor1;
            var r2 = r1 / factor2;
            var r3 = r2 * factor3;

            var costoSeparadorM2 = areaTotal > 0 ? (r3 * perimetroTotal) / areaTotal : 0;
            var precioSeparador = costoSeparadorM2 / (1 - margen);

            var detalle =
                $"--- SEPARADOR ---\n" +
                $"Costo proveedor: {costoProveedor}\n" +
                $"Costo importación: {costoImportacion}\n" +
                $"Costo base: {costoBase}\n" +
                $"Paso 1: costoBase / factor1 = {r1}\n" +
                $"Paso 2: r1 / factor2 = {r2}\n" +
                $"Paso 3: r2 * factor3 = {r3}\n" +
                $"Costo separador (por m2): (r3 * perimetroTotal) / areaTotal = {costoSeparadorM2}\n" +
                $"Precio separador: costoSeparadorM2 / (1 - margen) = {precioSeparador}";

            return new ProductoResultado { PrecioFinal = precioSeparador, Margen = margen, Detalle = detalle };
        }
    }

    // --- PROGRAMA PRINCIPAL ---
    class Program
    {
        static void Main()
        {
            var calc = new CalculadoraPrecios();

            // Ejemplo de parámetros (puedes ajustar valores reales)
            var cristal = calc.CalcularCristal(
                costoProveedor: 100, costoImportacion: 20,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                merma: 1.01m, factorCorte: 1.0m, costoProcesoCorte: 15,
                costoProcesoTermico: 10, costoImpresion: 5, costoCantos: 18,
                costoBarrenos: 2, costoAvellanados: 3, costoResaques: 4,
                desperdicio: 0.15m, cantidad: 2, margen: 0.25m,
                areaTotal: 2.4m, perimetroTotal: 6.4m,
                barrenosTotales: 2, avellanadosTotales: 1, resaquesTotales: 1);

            var pelicula = calc.CalcularPelicula(
                costoProveedor: 50, costoImportacion: 10,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                desperdicio: 0.10m, margen: 0.20m);

            var separador = calc.CalcularSeparador(
                costoProveedor: 30, costoImportacion: 5,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                margen: 0.15m, areaTotal: 2.4m, perimetroTotal: 6.4m);

            // Mostrar resultados individuales
            Console.WriteLine(cristal.Detalle);
            Console.WriteLine(pelicula.Detalle);
            Console.WriteLine(separador.Detalle);

            // Sumar los tres
            var total = cristal.PrecioFinal + pelicula.PrecioFinal + separador.PrecioFinal;
            Console.WriteLine($"--- TOTAL ENSAMBLE ---");
            Console.WriteLine($"Precio final ensamble: {total}");
        }
    }
}
