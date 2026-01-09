using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class ConfigCristalControl : UserControl
    {
        private ConfigMaterial? config;

        public ConfigCristalControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(ConfigMaterial config)
        {
            this.config = config;
            if (config != null)
            {
                TxtCristalNum.Text = config.Num ?? "";
                LblNombreCristal.Text = config.Descripcion ?? "Descripción Cristal";
                // Validar que Num no sea nulo ni vacío antes de consultar
                if (!string.IsNullOrWhiteSpace(config.Num))
                {
                    string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT TIPOTEMPLADO FROM Materiales WHERE Tipo='Cristal' AND Num=@Num";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Num", config.Num);
                            var result = cmd.ExecuteScalar();
                            config.TipoTemplado = result != null && result != DBNull.Value ? result.ToString() : string.Empty;
                        }
                    }
                    // Asignar factores y costo de corte por defecto al cargar
                    ObtenerFactoresCorte("Recto");
                }
                else
                {
                    config.TipoTemplado = string.Empty;
                }
            }
        }

        // Nuevo método para obtener el costo del proceso térmico
        public decimal ObtenerCostoProcesoTermico(string procesoTermico, string tipoTemplado)
        {
            string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                decimal energia = 0, mantenimiento = 0;
                string queryEnergia = @"SELECT Valor3 FROM Generales WHERE Concepto = N'Proceso termico' AND Valor = @ProcesoTermico AND Valor2 = @TipoTemplado AND Valor1 = N'Energia'";
                string queryMantenimiento = @"SELECT Valor3 FROM Generales WHERE Concepto = N'Proceso termico' AND Valor = @ProcesoTermico AND Valor2 = @TipoTemplado AND Valor1 = N'Mantenimiento'";
                using (SqlCommand cmd = new SqlCommand(queryEnergia, conn))
                {
                    cmd.Parameters.AddWithValue("@ProcesoTermico", procesoTermico);
                    cmd.Parameters.AddWithValue("@TipoTemplado", tipoTemplado);
                    var result = cmd.ExecuteScalar();
                    energia = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
                using (SqlCommand cmd = new SqlCommand(queryMantenimiento, conn))
                {
                    cmd.Parameters.AddWithValue("@ProcesoTermico", procesoTermico);
                    cmd.Parameters.AddWithValue("@TipoTemplado", tipoTemplado);
                    var result = cmd.ExecuteScalar();
                    mantenimiento = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
                return energia + mantenimiento;
            }
        }

        private void TxtCristalNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCristal(TxtCristalNum.Text);
            }
        }

        private void BuscarCristal(string numero)
        {
            string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Buscar descripción en Materiales
                string queryMateriales = "SELECT DESCRIPCION, TIPOTEMPLADO, ESPESOR FROM Materiales WHERE Tipo='Cristal' AND Num=@Num";
                using (SqlCommand cmd = new SqlCommand(queryMateriales, conn))
                {
                    cmd.Parameters.AddWithValue("@Num", numero);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descripcion = reader["DESCRIPCION"].ToString();
                            string tipoTemplado = reader["TIPOTEMPLADO"].ToString();
                            decimal espesor = reader["ESPESOR"] != DBNull.Value ? Convert.ToDecimal(reader["ESPESOR"]) : 0;
                            LblNombreCristal.Text = descripcion;
                            if (config != null)
                            {
                                config.Num = numero;
                                config.Descripcion = descripcion;
                                config.TipoTemplado = tipoTemplado;
                                config.Espesor = espesor;
                            }
                        }
                    }
                }

                // 2. Buscar costo proveedor y parámetros adicionales en Costos
                string queryCostos = @"SELECT TOP 1 Costo, Importacion, Factor, Factor2, Factor3, Moneda, Desperdicio 
                                       FROM Costos 
                                       WHERE Actual='True' AND Tipo='Cristal' AND Mercado='NAL' AND Num=@Num";
                using (SqlCommand cmd = new SqlCommand(queryCostos, conn))
                {
                    cmd.Parameters.AddWithValue("@Num", numero);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && config != null)
                        {
                            if (reader["Costo"] != DBNull.Value)
                                config.CostoProveedor = Convert.ToDecimal(reader["Costo"]);
                            if (reader["Importacion"] != DBNull.Value)
                                config.CostoImportacion = Convert.ToDecimal(reader["Importacion"]);
                            if (reader["Factor"] != DBNull.Value)
                                config.Factor1 = Convert.ToDecimal(reader["Factor"]);
                            if (reader["Factor2"] != DBNull.Value)
                                config.Factor2 = Convert.ToDecimal(reader["Factor2"]);
                            if (reader["Factor3"] != DBNull.Value)
                                config.Factor3 = Convert.ToDecimal(reader["Factor3"]);
                            if (reader["Desperdicio"] != DBNull.Value)
                                config.Desperdicio = Convert.ToDecimal(reader["Desperdicio"]);
                        }
                    }
                }
            }
        }

        private void ConfigCristalControl_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbfactorcorte1.Checked)
                ObtenerFactoresCorte("Recto");
            else if (Rbfactorcorte2.Checked)
                ObtenerFactoresCorte("En forma");
            else if (Rbfactorcorte3.Checked)
                ObtenerFactoresCorte("Maquila");
            else if (Rbfactorcorte4.Checked)
                ObtenerFactoresCorte("Lámina");
        }

        private void ObtenerFactoresCorte(string tipoCorte)
        {
            string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Obtener factores de corte
                string query = @"SELECT Valor3, Valor4, Valor5 FROM Generales WHERE Concepto = N'corte' AND Valor = @TipoCorte";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoCorte", tipoCorte);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && config != null)
                        {
                            config.FactorCorte1 = reader["Valor3"] != DBNull.Value ? Convert.ToDecimal(reader["Valor3"]) : 1.0m;
                            config.FactorCorte2 = reader["Valor4"] != DBNull.Value ? Convert.ToDecimal(reader["Valor4"]) : 1.0m;
                            config.FactorCorte3 = reader["Valor5"] != DBNull.Value ? Convert.ToDecimal(reader["Valor5"]) : 1.0m;
                        }
                    }
                }
                // Obtener costo del proceso de corte (Energia + Mantenimiento)
                string queryEnergia = @"SELECT Valor2 FROM Generales WHERE Concepto = N'corte' AND Valor = @TipoCorte AND Valor1 = N'Energia'";
                string queryMantenimiento = @"SELECT Valor2 FROM Generales WHERE Concepto = N'corte' AND Valor = @TipoCorte AND Valor1 = N'Mantenimiento'";
                decimal energia = 0, mantenimiento = 0;
                using (SqlCommand cmd = new SqlCommand(queryEnergia, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoCorte", tipoCorte);
                    var result = cmd.ExecuteScalar();
                    energia = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
                using (SqlCommand cmd = new SqlCommand(queryMantenimiento, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoCorte", tipoCorte);
                    var result = cmd.ExecuteScalar();
                    mantenimiento = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
                if (config != null)
                {
                    config.CostoProcesoCorte = energia + mantenimiento;
                }
            }
        }
    }
}
