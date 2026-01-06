namespace CQuote.Calculadora.Core
{
    public class Calculadora
    {
        public string CalcularCristalCompleto(
            decimal basePrecio,
            decimal factor,
            decimal tipoCorte,
            decimal maquinados,
            decimal otros,
            decimal merma,
            decimal desperdicio,
            decimal margen,
            decimal barrenoM2,
            decimal impresionM2,
            decimal pelicula,
            decimal separador,
            decimal areaM2 // área del cristal en m²
        )
        {
            // Paso 1: aplicar factor
            decimal precioFactor = basePrecio * factor;

            // Paso 2: aplicar tipo de corte
            decimal precioCorte = precioFactor + tipoCorte;

            // Paso 3: sumar maquinados
            decimal precioMaquinados = precioCorte + maquinados;

            // Paso 4: sumar otros
            decimal precioOtros = precioMaquinados + otros;

            // Paso 5: sumar merma
            decimal precioMerma = precioOtros + merma;

            // Paso 6: sumar desperdicio
            decimal precioDesperdicio = precioMerma + desperdicio;

            // Paso 7: barreno por m²
            decimal precioBarreno = precioDesperdicio + (barrenoM2 * areaM2);

            // Paso 8: impresión por m²
            decimal precioImpresion = precioBarreno + (impresionM2 * areaM2);

            // Paso 9: película
            decimal precioPelicula = precioImpresion + pelicula;

            // Paso 10: separador
            decimal precioSeparador = precioPelicula + separador;

            // Paso 11: aplicar margen
            decimal precioFinal = precioSeparador * (1 + margen);

            // Construir detalle
            string detalle =
                $"Base: {basePrecio}\n" +
                $"Factor aplicado ({factor}): {precioFactor}\n" +
                $"Tipo de corte: +{tipoCorte} → {precioCorte}\n" +
                $"Maquinados: +{maquinados} → {precioMaquinados}\n" +
                $"Otros: +{otros} → {precioOtros}\n" +
                $"Merma: +{merma} → {precioMerma}\n" +
                $"Desperdicio: +{desperdicio} → {precioDesperdicio}\n" +
                $"Barreno ({barrenoM2}/m² * {areaM2} m²): +{barrenoM2 * areaM2} → {precioBarreno}\n" +
                $"Impresión ({impresionM2}/m² * {areaM2} m²): +{impresionM2 * areaM2} → {precioImpresion}\n" +
                $"Película: +{pelicula} → {precioPelicula}\n" +
                $"Separador: +{separador} → {precioSeparador}\n" +
                $"Margen ({margen * 100}%): {precioFinal}\n" +
                $"-----------------------------\n" +
                $"PRECIO FINAL DEL ENSAMBLE: {precioFinal}";

            return detalle;
        }
    }
}
