using System;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var calc = new CQuote.Calculadora.Core.Calculadora();

            string detalle = calc.CalcularCristalCompleto(
                basePrecio: 100,
                factor: 1.15m,
                tipoCorte: 12,
                maquinados: 30,
                otros: 15,
                merma: 5,
                desperdicio: 10,
                margen: 0.20m,   // 20% margen
                barrenoM2: 8,
                impresionM2: 20,
                pelicula: 25,
                separador: 40,
                areaM2: 2.5m     // ejemplo: cristal de 2.5 m²
            );

            MessageBox.Show(detalle, "Detalle del cálculo completo del ensamble");
        }
    }
}
