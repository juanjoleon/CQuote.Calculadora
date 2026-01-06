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

            // Asignar eventos a los botones
            BtnCristal.Click += BtnCristal_Click;
            BtnPelicula.Click += BtnPelicula_Click;
            BtnSeparador.Click += BtnSeparador_Click;
            button4.Click += button4_Click;
        }

        // --- Botones para agregar nodos ---
        private void BtnCristal_Click(object sender, EventArgs e)
        {
            Trview1.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
        }

        private void BtnPelicula_Click(object sender, EventArgs e)
        {
            Trview1.Nodes.Add(new TreeNode("Pelicula") { Name = "Pelicula" });
        }

        private void BtnSeparador_Click(object sender, EventArgs e)
        {
            Trview1.Nodes.Add(new TreeNode("Separador") { Name = "Separador" });
        }

        // --- Botón Calcular ---
        private void button4_Click(object sender, EventArgs e)
        {
            var calc = new CalculadoraPrecios();
            decimal total = 0;
            string detalle = "";

            foreach (TreeNode node in Trview1.Nodes)
            {
                ProductoResultado resultado = EjecutarProceso(node.Name, calc);
                total += resultado.PrecioFinal;
                detalle += resultado.Detalle + "\n\n";
            }

            detalle += $"--- TOTAL ENSAMBLE ---\nPrecio final ensamble: {total}";
            MessageBox.Show(detalle, "Detalle de cálculos dinámicos");
        }

        // --- Métodos privados con parámetros fijos ---
        private ProductoResultado EjecutarProceso(string proceso, CalculadoraPrecios calc)
        {
            switch (proceso)
            {
                case "Cristal":
                    return EjecutarCristal(calc);
                case "Pelicula":
                    return EjecutarPelicula(calc);
                case "Separador":
                    return EjecutarSeparador(calc);
                default:
                    throw new InvalidOperationException($"Proceso desconocido: {proceso}");
            }
        }

        private ProductoResultado EjecutarCristal(CalculadoraPrecios calc)
        {
            return calc.CalcularCristal(
                costoProveedor: 100, costoImportacion: 20,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                merma: 1.01m, factorCorte: 1.0m, costoProcesoCorte: 15,
                costoProcesoTermico: 10, costoImpresion: 5, costoCantos: 18,
                costoBarrenos: 2, costoAvellanados: 3, costoResaques: 4,
                desperdicio: 0.15m, cantidad: 2, margen: 0.25m,
                areaTotal: 2.4m, perimetroTotal: 6.4m,
                barrenosTotales: 2, avellanadosTotales: 1, resaquesTotales: 1);
        }

        private ProductoResultado EjecutarPelicula(CalculadoraPrecios calc)
        {
            return calc.CalcularPelicula(
                costoProveedor: 50, costoImportacion: 10,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                desperdicio: 0.10m, margen: 0.20m);
        }

        private ProductoResultado EjecutarSeparador(CalculadoraPrecios calc)
        {
            return calc.CalcularSeparador(
                costoProveedor: 30, costoImportacion: 5,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                margen: 0.15m, areaTotal: 2.4m, perimetroTotal: 6.4m);
        }
    }
}

