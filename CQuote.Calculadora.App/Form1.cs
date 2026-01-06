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
            BtnMon.Click += BtnMon_Click;
            BtnLam.Click += BtnLam_Click;
            BtnIns.Click += BtnIns_Click;
            BtnCalcular.Click += button4_Click;
            BtnBorrar.Click += BtnBorrar_Click;
        }

        // --- Botones para crear ensambles padres ---
        private void BtnMon_Click(object sender, EventArgs e)
        {
            var mon = new TreeNode("MON") { Name = "MON" };
            mon.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
            Trview1.Nodes.Add(mon);
            Trview1.ExpandAll();
        }

        private void BtnIns_Click(object sender, EventArgs e)
        {
            var ins = new TreeNode("INS") { Name = "INS" };
            ins.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
            ins.Nodes.Add(new TreeNode("Separador") { Name = "Separador" });
            ins.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
            Trview1.Nodes.Add(ins);
            Trview1.ExpandAll();
        }

        private void BtnLam_Click(object sender, EventArgs e)
        {
            if (Trview1.SelectedNode != null && Trview1.SelectedNode.Name == "Cristal")
            {
                TreeNode parent = Trview1.SelectedNode.Parent;
                int index = Trview1.SelectedNode.Index;

                // Eliminar el cristal seleccionado
                Trview1.SelectedNode.Remove();

                // Insertar el ensamble LAM en su lugar
                var lam = new TreeNode("LAM") { Name = "LAM" };
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
                lam.Nodes.Add(new TreeNode("Pelicula") { Name = "Pelicula" });
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });

                parent.Nodes.Insert(index, lam);
                Trview1.ExpandAll();
            }
            else
            {
                // Si no hay selección, se agrega como raíz
                var lam = new TreeNode("LAM") { Name = "LAM" };
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
                lam.Nodes.Add(new TreeNode("Pelicula") { Name = "Pelicula" });
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal" });
                Trview1.Nodes.Add(lam);
                Trview1.ExpandAll();
            }
        }

        // --- Botones para agregar nodos después del seleccionado ---
        private void BtnCristal_Click(object sender, EventArgs e)
        {
            InsertarDespuesSeleccionado(new TreeNode("Cristal") { Name = "Cristal" });
        }

        private void BtnPelicula_Click(object sender, EventArgs e)
        {
            InsertarDespuesSeleccionado(new TreeNode("Pelicula") { Name = "Pelicula" });
        }

        private void BtnSeparador_Click(object sender, EventArgs e)
        {
            InsertarDespuesSeleccionado(new TreeNode("Separador") { Name = "Separador" });
        }

        private void InsertarDespuesSeleccionado(TreeNode nuevo)
        {
            if (Trview1.SelectedNode != null)
            {
                TreeNode parent = Trview1.SelectedNode.Parent ?? Trview1.Nodes[0];
                int index = Trview1.SelectedNode.Index;
                parent.Nodes.Insert(index + 1, nuevo);
                Trview1.ExpandAll();
            }
            else
            {
                Trview1.Nodes.Add(nuevo);
            }
        }

        // --- Botón Calcular ---
        private void button4_Click(object sender, EventArgs e)
        {
            var calc = new CalculadoraPrecios();
            decimal total = 0;
            string detalle = "";

            foreach (TreeNode root in Trview1.Nodes)
            {
                CalcularNodo(root, calc, ref total, ref detalle);
            }

            detalle += $"--- TOTAL ENSAMBLE ---\nPrecio final ensamble: {total}";

            // Abrir el FormDetalle y mostrar el texto en el RichTextBox
            var frmDetalle = new Detalle();
            frmDetalle.rtxtDetalle.Text = detalle;
            frmDetalle.ShowDialog();
        }

        // Método recursivo para recorrer hojas
        private void CalcularNodo(TreeNode node, CalculadoraPrecios calc, ref decimal total, ref string detalle)
        {
            if (node.Nodes.Count == 0)
            {
                // Es hoja → calcular
                ProductoResultado resultado = EjecutarProceso(node.Name, calc);
                total += resultado.PrecioFinal;
                detalle += resultado.Detalle + "\n\n";
            }
            else
            {
                // Es padre → recorrer hijos
                detalle += $"=== Ensamble {node.Text} ===\n";
                foreach (TreeNode hijo in node.Nodes)
                {
                    CalcularNodo(hijo, calc, ref total, ref detalle);
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar TreeView vacío
            Trview1.Nodes.Clear();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        // --- Botón Borrar ---
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (Trview1.SelectedNode != null)
            {
                Trview1.SelectedNode.Remove();
            }
        }
    }
}
