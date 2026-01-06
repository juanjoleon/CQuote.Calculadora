using System;
using System.Windows.Forms;
using CQuote.Calculadora.Core;

namespace CQuote.Calculadora.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var calc = new CalculadoraPrecios();

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

            var total = cristal.PrecioFinal + pelicula.PrecioFinal + separador.PrecioFinal;

            string detalle =
                cristal.Detalle + "\n\n" +
                pelicula.Detalle + "\n\n" +
                separador.Detalle + "\n\n" +
                "--- TOTAL ENSAMBLE ---\n" +
                $"Precio final ensamble: {total}";

            MessageBox.Show(detalle, "Detalle de cálculos");
        }
    }
}
