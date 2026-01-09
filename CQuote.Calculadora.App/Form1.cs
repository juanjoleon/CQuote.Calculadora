using System;
using System.Windows.Forms;
using CQuote.Calculadora.Core;

namespace CQuote.Calculadora.App
{
    public partial class Form1 : Form
    {
        private ConfigCristalControl configCristalControl;
        private ConfigSeparadorControl configSeparadorControl;
        private ConfigPeliculaControl configPeliculaControl;

        public Form1()
        {
            InitializeComponent();

            // Inicializar los UserControls
            configCristalControl = new ConfigCristalControl { Dock = DockStyle.Fill, Visible = false };
            configSeparadorControl = new ConfigSeparadorControl { Dock = DockStyle.Fill, Visible = false };
            configPeliculaControl = new ConfigPeliculaControl { Dock = DockStyle.Fill, Visible = false };

            // Agregarlos al Panel1
            panel1.Controls.Add(configCristalControl);
            panel1.Controls.Add(configSeparadorControl);
            panel1.Controls.Add(configPeliculaControl);

            // Asignar eventos a los botones
            BtnCristal.Click += BtnCristal_Click;
            BtnPelicula.Click += BtnPelicula_Click;
            BtnSeparador.Click += BtnSeparador_Click;
            BtnMon.Click += BtnMon_Click;
            BtnLam.Click += BtnLam_Click;
            BtnIns.Click += BtnIns_Click;
            BtnCalcular.Click += button4_Click;
            BtnBorrar.Click += BtnBorrar_Click;
            BtnDetalle.Click += BtnDetalle_Click;

            // Evento de selección de nodo
            Trview1.AfterSelect += Trview1_AfterSelect;
        }

        private void Trview1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is ConfigMaterial config)
            {
                // Ocultar todos
                configCristalControl.Visible = false;
                configSeparadorControl.Visible = false;
                configPeliculaControl.Visible = false;

                // Mostrar el que corresponda
                switch (e.Node.Name)
                {
                    case "Cristal":
                        configCristalControl.Visible = true;
                        configCristalControl.LoadConfig(config);
                        break;
                    case "Separador":
                        configSeparadorControl.Visible = true;
                        configSeparadorControl.LoadConfig(config);
                        break;
                    case "Pelicula":
                        configPeliculaControl.Visible = true;
                        configPeliculaControl.LoadConfig(config);
                        break;
                }
            }
        }

        // --- Botones para crear ensambles padres ---
        private void BtnMon_Click(object sender, EventArgs e)
        {
            var mon = new TreeNode("MON") { Name = "MON" };
            var cristal = new TreeNode("Cristal") { Name = "Cristal" };
            cristal.Tag = new ConfigMaterial { CostoProveedor = 100, Num = "1" }; // Asigna el número real aquí
            mon.Nodes.Add(cristal);
            Trview1.Nodes.Add(mon);
            Trview1.ExpandAll();
        }

        private void BtnIns_Click(object sender, EventArgs e)
        {
            var ins = new TreeNode("INS") { Name = "INS" };

            var cristal1 = new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "1" } };
            var separador = new TreeNode("Separador") { Name = "Separador", Tag = new ConfigMaterial { CostoProveedor = 30 } };
            var cristal2 = new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "2" } };

            ins.Nodes.Add(cristal1);
            ins.Nodes.Add(separador);
            ins.Nodes.Add(cristal2);

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
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "1" } });
                lam.Nodes.Add(new TreeNode("Pelicula") { Name = "Pelicula", Tag = new ConfigMaterial { CostoProveedor = 0 } });
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "2" } });

                parent.Nodes.Insert(index, lam);
                Trview1.ExpandAll();
            }
            else
            {
                // Si no hay selección, se agrega como raíz
                var lam = new TreeNode("LAM") { Name = "LAM" };
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "1" } });
                lam.Nodes.Add(new TreeNode("Pelicula") { Name = "Pelicula", Tag = new ConfigMaterial { CostoProveedor = 0 } });
                lam.Nodes.Add(new TreeNode("Cristal") { Name = "Cristal", Tag = new ConfigMaterial { CostoProveedor = 100, Num = "2" } });
                Trview1.Nodes.Add(lam);
                Trview1.ExpandAll();
            }
        }

        // --- Botones para agregar nodos después del seleccionado ---
        private void BtnCristal_Click(object sender, EventArgs e)
        {
            var nodo = new TreeNode("Cristal") { Name = "Cristal" };
            nodo.Tag = new ConfigMaterial { CostoProveedor = 100, Num = "1" };
            InsertarDespuesSeleccionado(nodo);
        }

        private void BtnPelicula_Click(object sender, EventArgs e)
        {
            var nodo = new TreeNode("Pelicula") { Name = "Pelicula" };
            nodo.Tag = new ConfigMaterial { CostoProveedor = 0 };
            InsertarDespuesSeleccionado(nodo);
        }

        private void BtnSeparador_Click(object sender, EventArgs e)
        {
            var nodo = new TreeNode("Separador") { Name = "Separador" };
            nodo.Tag = new ConfigMaterial { CostoProveedor = 0 };
            InsertarDespuesSeleccionado(nodo);
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
            // Validar que el combo de tipo de cambio tenga una opción válida
            if (CBTipodeCambio.SelectedItem == null || (CBTipodeCambio.SelectedItem.ToString() != "MXP" && CBTipodeCambio.SelectedItem.ToString() != "USD"))
            {
                MessageBox.Show("Debe seleccionar la moneda de cotización (MXP o USD) antes de calcular.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que todos los nodos de tipo Cristal, Pelicula y Separador tengan Num capturado y costo válido
            foreach (TreeNode root in Trview1.Nodes)
            {
                if (!ValidarNumMaterial(root))
                {
                    MessageBox.Show("Debe capturar el número y tener costo válido en cada material antes de calcular.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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

        private bool ValidarNumMaterial(TreeNode node)
        {
            if ((node.Name == "Cristal" || node.Name == "Pelicula" || node.Name == "Separador") && node.Tag is ConfigMaterial config)
            {
                // El número debe estar capturado y el costo debe ser distinto de cero
                if (string.IsNullOrWhiteSpace(config.Num) || config.CostoProveedor == 0)
                    return false;
            }
            foreach (TreeNode hijo in node.Nodes)
            {
                if (!ValidarNumMaterial(hijo))
                    return false;
            }
            return true;
        }

        // Método recursivo para recorrer hojas
        private void CalcularNodo(TreeNode node, CalculadoraPrecios calc, ref decimal total, ref string detalle)
        {
            if (node.Nodes.Count == 0 && node.Tag is ConfigMaterial config)
            {
                // Es hoja → calcular con configuración
                ProductoResultado resultado = EjecutarProceso(node.Name, calc, config);
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

        // --- Métodos privados con parámetros dinámicos (solo costoProveedor) ---
        private ProductoResultado EjecutarProceso(string proceso, CalculadoraPrecios calc, ConfigMaterial config)
        {
            switch (proceso)
            {
                case "Cristal":
                    return EjecutarCristal(calc, config);
                case "Pelicula":
                    return EjecutarPelicula(calc, config);
                case "Separador":
                    return EjecutarSeparador(calc, config);
                default:
                    throw new InvalidOperationException($"Proceso desconocido: {proceso}");
            }
        }

        private ProductoResultado EjecutarCristal(CalculadoraPrecios calc, ConfigMaterial config)
        {
            return calc.CalcularCristal(
                costoProveedor: config.CostoProveedor,
                costoImportacion: config.CostoImportacion, // dinámico
                factor1: config.Factor1, // dinámico
                factor2: config.Factor2, // dinámico
                factor3: config.Factor3, // dinámico
                merma: 1.01m, // fijo
                factorCorte1: config.FactorCorte1, // nuevo
                costoProcesoCorte: 15, // fijo
                costoProcesoTermico: 10, // fijo
                costoImpresion: 5, // fijo
                costoCantos: 18, // fijo
                costoBarrenos: 2, // fijo
                costoAvellanados: 3, // fijo
                costoResaques: 4, // fijo
                desperdicio: config.Desperdicio, // dinámico
                cantidad: 2, // fijo
                margen: 0.25m, // fijo
                areaTotal: 2.4m, // fijo
                perimetroTotal: 6.4m, // fijo
                barrenosTotales: 2, // fijo
                avellanadosTotales: 1, // fijo
                resaquesTotales: 1, // fijo
                factorCorte2: config.FactorCorte2, // nuevo
                factorCorte3: config.FactorCorte3  // nuevo
            );
        }

        private ProductoResultado EjecutarPelicula(CalculadoraPrecios calc, ConfigMaterial config)
        {
            // Calcular el desperdicio real para película
            decimal desperdicio = config.Desperdicio;
            if (desperdicio < 0 || desperdicio > 1) desperdicio = 0.10m; // fallback seguro
            return calc.CalcularPelicula(
                costoProveedor: config.CostoProveedor, // dinámico
                costoImportacion: config.CostoImportacion,
                factor1: config.Factor1,
                factor2: config.Factor2,
                factor3: config.Factor3,
                desperdicio: desperdicio,
                margen: 0.20m);
        }

        private ProductoResultado EjecutarSeparador(CalculadoraPrecios calc, ConfigMaterial config)
        {
            return calc.CalcularSeparador(
                costoProveedor: config.CostoProveedor, // dinámico
                costoImportacion: 5,
                factor1: 0.95m, factor2: 0.90m, factor3: 1.02m,
                margen: 0.15m, areaTotal: 2.4m, perimetroTotal: 6.4m);
        }

        // --- Botón Borrar ---
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (Trview1.SelectedNode != null)
            {
                Trview1.SelectedNode.Remove();
            }
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            var materiales = new List<(string Tipo, ConfigMaterial Material, string? Padre)>();
            RecopilarMateriales(Trview1.Nodes, materiales);
            string procesoTermico = ObtenerProcesoTermicoSeleccionado();
            string monedaCotizacion = CBTipodeCambio.SelectedItem?.ToString() ?? "";
            var frm = new EdicionCostos();
            frm.CargarMateriales(materiales, procesoTermico, monedaCotizacion);
            frm.ShowDialog();
        }

        private string ObtenerProcesoTermicoSeleccionado()
        {
            // Busca el control de tipo ConfigCristalControl visible y obtiene el radio button seleccionado
            if (configCristalControl.Visible)
            {
                var rbTemplado = configCristalControl.Controls.Find("RbTemplado", true);
                if (rbTemplado.Length > 0 && ((RadioButton)rbTemplado[0]).Checked)
                    return "Templado";
                var rbRecocido = configCristalControl.Controls.Find("RbRecocido", true);
                if (rbRecocido.Length > 0 && ((RadioButton)rbRecocido[0]).Checked)
                    return "Recocido";
                var rbCurvoTemplado = configCristalControl.Controls.Find("RbCurvoTemplado", true);
                if (rbCurvoTemplado.Length > 0 && ((RadioButton)rbCurvoTemplado[0]).Checked)
                    return "Curvo Templado";
                var rbCurvoRecocido = configCristalControl.Controls.Find("RbCurvoRecocido", true);
                if (rbCurvoRecocido.Length > 0 && ((RadioButton)rbCurvoRecocido[0]).Checked)
                    return "Curvo Recocido";
                var rbSemitemplado = configCristalControl.Controls.Find("RbSemitemplado", true);
                if (rbSemitemplado.Length > 0 && ((RadioButton)rbSemitemplado[0]).Checked)
                    return "Semitemplado";
            }
            return "Recocido"; // Valor por defecto
        }

        private void RecopilarMateriales(TreeNodeCollection nodes, List<(string Tipo, ConfigMaterial Material, string? Padre)> lista, string? padre = null)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is ConfigMaterial mat)
                {
                    lista.Add((node.Name, mat, padre));
                }
                if (node.Nodes.Count > 0)
                {
                    RecopilarMateriales(node.Nodes, lista, node.Name);
                }
            }
        }

        private void Trview1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }
    }
}
