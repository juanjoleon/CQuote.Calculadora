using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class EdicionCostos : Form
    {
        public EdicionCostos()
        {
            InitializeComponent();
        }

        public void CargarMateriales(List<(string Tipo, ConfigMaterial Material, string? Padre)> materiales, string procesoTermico, string monedaCotizacion)
        {
            DtvDetalle.Columns.Clear();
            DtvDetalle.Rows.Clear();
            DtvDetalle.Columns.Add("Tipo", "Tipo");
            DtvDetalle.Columns.Add("Num", "Num");
            DtvDetalle.Columns.Add("Descripcion", "Descripción");
            DtvDetalle.Columns.Add("CostoProveedor", "Costo Proveedor");
            DtvDetalle.Columns.Add("Moneda", "Moneda");
            DtvDetalle.Columns.Add("CostoImportacion", "Costo Importación");
            DtvDetalle.Columns.Add("Factor1", "Factor1");
            DtvDetalle.Columns.Add("Calculo1", "Cálculo1");
            DtvDetalle.Columns.Add("Factor2", "Factor2");
            DtvDetalle.Columns.Add("Calculo2", "Cálculo2");
            DtvDetalle.Columns.Add("Factor3", "Factor3");
            DtvDetalle.Columns.Add("Calculo3", "Cálculo3");
            DtvDetalle.Columns.Add("CostoLamina", "Costo Lámina");
            DtvDetalle.Columns.Add("Desperdicio", "Desperdicio");
            DtvDetalle.Columns.Add("CostoConDesperdicio", "Costo con Desperdicio");
            DtvDetalle.Columns.Add("CostoCorte", "Costo Corte");
            DtvDetalle.Columns.Add("NombreProcesoTermico", "Nombre Proceso Térmico");
            DtvDetalle.Columns.Add("CostoProcesoTermico", "Costo Proceso Térmico");
            DtvDetalle.Columns.Add("Total", "Total con Proceso Térmico");
            DtvDetalle.Columns.Add("CostoConvertido", "Costo Convertido");
            DtvDetalle.Columns.Add("TipoTemplado", "TIPOTEMPLADO");
            DtvDetalle.Columns.Add("Espesor", "Espesor");

            decimal sumaTotal = 0;
            decimal sumaEspesorLaminados = 0;
            decimal sumaTotalConvertido = 0;
            foreach (var (tipo, mat, padre) in materiales)
            {
                decimal calculo1 = 0, calculo2 = 0, calculo3 = 0, costoLamina = 0, costoConDesperdicio = 0, costoCorte = 0, costoProcesoTermico = 0, total = 0;
                if (tipo == "Cristal")
                {
                    calculo1 = (mat.CostoProveedor + mat.CostoImportacion) / (mat.Factor1 == 0 ? 1 : mat.Factor1);
                    calculo2 = calculo1 / (mat.Factor2 == 0 ? 1 : mat.Factor2);
                    calculo3 = calculo2 * mat.Factor3;
                    costoLamina = calculo3 * 1.01m; // merma fija
                    costoConDesperdicio = (1 - mat.Desperdicio * mat.FactorCorte2) != 0 ? (calculo3 * 1.01m) / (1 - mat.Desperdicio * mat.FactorCorte2) * mat.FactorCorte1 : 0;
                    costoCorte = mat.CostoProcesoCorte * mat.FactorCorte3;
                    // Para cristales, usa la configuración específica del nodo
                    string procesoTermicoCristal = mat.TipoTemplado ?? string.Empty;
                    costoProcesoTermico = ObtenerCostoProcesoTermicoBD(procesoTermicoCristal, mat.TipoTemplado);
                    total = costoConDesperdicio + costoCorte + costoProcesoTermico;
                }
                else if (tipo == "Pelicula")
                {
                    calculo1 = (mat.CostoProveedor + mat.CostoImportacion) / (mat.Factor1 == 0 ? 1 : mat.Factor1);
                    calculo2 = calculo1 / (mat.Factor2 == 0 ? 1 : mat.Factor2);
                    calculo3 = calculo2 * mat.Factor3;
                    costoLamina = calculo3;
                    costoConDesperdicio = (1 - mat.Desperdicio) != 0 ? calculo3 / (1 - mat.Desperdicio) : 0;
                    costoCorte = 0;
                    costoProcesoTermico = 0;
                    total = costoConDesperdicio;
                }
                else
                {
                    calculo1 = (mat.CostoProveedor + mat.CostoImportacion) / (mat.Factor1 == 0 ? 1 : mat.Factor1);
                    calculo2 = calculo1 / (mat.Factor2 == 0 ? 1 : mat.Factor2);
                    calculo3 = calculo2 * mat.Factor3;
                    costoLamina = calculo3;
                    costoConDesperdicio = calculo3;
                    costoCorte = 0;
                    costoProcesoTermico = 0;
                    total = costoConDesperdicio;
                }
                sumaTotal += total;
                // Sumar espesor de cristales que están dentro de LAM
                if (tipo == "Cristal" && padre == "LAM")
                {
                    sumaEspesorLaminados += mat.Espesor;
                }
                // Conversión de moneda
                decimal costoConvertido = total;
                string monedaSupplier = mat.Moneda ?? "MXP";
                if (monedaSupplier != monedaCotizacion)
                {
                    decimal tipoCambio = 1;
                    try
                    {
                        string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                        using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "SELECT Valor2 FROM Generales WHERE Concepto = N'Tipo de cambio' AND Valor = @Valor";
                            string valorCambio = monedaSupplier == "MXP" && monedaCotizacion == "USD" ? "MXP USD" : "USD MXP";
                            using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Valor", valorCambio);
                                var result = cmd.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                    tipoCambio = Convert.ToDecimal(result);
                            }
                        }
                    }
                    catch { tipoCambio = 1; }
                    if (monedaSupplier == "MXP" && monedaCotizacion == "USD")
                        costoConvertido = total / tipoCambio;
                    else if (monedaSupplier == "USD" && monedaCotizacion == "MXP")
                        costoConvertido = total * tipoCambio;
                }
                sumaTotalConvertido += costoConvertido;
                DtvDetalle.Rows.Add(
                    tipo,
                    mat.Num,
                    mat.Descripcion,
                    mat.CostoProveedor,
                    monedaSupplier,      // Moneda
                    mat.CostoImportacion,
                    mat.Factor1,
                    calculo1.ToString("C2"),
                    mat.Factor2,
                    calculo2.ToString("C2"),
                    mat.Factor3,
                    calculo3,
                    costoLamina,
                    mat.Desperdicio,
                    costoConDesperdicio,
                    costoCorte,
                    tipo == "Cristal" ? procesoTermico : string.Empty,
                    costoProcesoTermico,
                    total,
                    costoConvertido,      // Costo Convertido
                    mat.TipoTemplado ?? string.Empty,
                    mat.Espesor           // Espesor
                );
            }
            // Mostrar la suma en el label
            decimal energia = 0, mantenimiento = 0, totalLaminado = 0;
            string moneda = "";
            try
            {
                string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    string queryEnergia = "SELECT Valor2, Moneda FROM Generales WHERE Concepto = N'laminado' AND Valor1 = N'Energia'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryEnergia, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Valor2"] != DBNull.Value)
                                    energia += Convert.ToDecimal(reader["Valor2"]);
                                if (reader["Moneda"] != DBNull.Value)
                                    moneda = reader["Moneda"].ToString();
                            }
                        }
                    }
                    string queryMantenimiento = "SELECT Valor2 FROM Generales WHERE Concepto = N'laminado' AND Valor1 = N'Mantenimiento'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryMantenimiento, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Valor2"] != DBNull.Value)
                                    mantenimiento += Convert.ToDecimal(reader["Valor2"]);
                            }
                        }
                    }
                }
            }
            catch { }
            totalLaminado = sumaEspesorLaminados * (energia + mantenimiento) * 2.5m;
            // Convertir laminado si es necesario
            decimal totalLaminadoConvertido = totalLaminado;
            if (!string.IsNullOrEmpty(moneda) && moneda != monedaCotizacion)
            {
                decimal tipoCambio = 1;
                try
                {
                    string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                    using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT Valor2 FROM Generales WHERE Concepto = N'Tipo de cambio' AND Valor = @Valor";
                        string valorCambio = moneda == "MXP" && monedaCotizacion == "USD" ? "MXP USD" : "USD MXP";
                        using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Valor", valorCambio);
                            var result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                tipoCambio = Convert.ToDecimal(result);
                        }
                    }
                }
                catch { tipoCambio = 1; }
                if (moneda == "MXP" && monedaCotizacion == "USD")
                    totalLaminadoConvertido = totalLaminado / tipoCambio;
                else if (moneda == "USD" && monedaCotizacion == "MXP")
                    totalLaminadoConvertido = totalLaminado * tipoCambio;
            }
            decimal totalFinal = sumaTotalConvertido + totalLaminadoConvertido;
            if (LblSubtotal != null)
                LblSubtotal.Text = $"Subtotal: {totalFinal:C2} {monedaCotizacion}";
            if (LblSubtotalcm != null)
                LblSubtotalcm.Text = $"Subtotal c/margen: {(totalFinal / 0.95m):C2} {monedaCotizacion}";
            if (LblLaminado != null)
                LblLaminado.Text = $"Laminado: {totalLaminadoConvertido:C2} {monedaCotizacion}";
        }

        public void LlenarDgvTrabajos(List<(string Tipo, ConfigMaterial Material, string? Padre)> materiales)
        {
            dgvTrabajos.Columns.Clear();
            dgvTrabajos.Rows.Clear();
            dgvTrabajos.Columns.Add("Num", "Num");
            dgvTrabajos.Columns.Add("Nombre", "Nombre");
            dgvTrabajos.Columns.Add("TipoCanto", "Tipo de canto");
            dgvTrabajos.Columns.Add("CostoML", "Costo canto por ml");
            dgvTrabajos.Columns.Add("CostoM2", "Costo canto por m2");

            foreach (var (tipo, mat, padre) in materiales)
            {
                if (tipo != "Cristal") continue;
                // Determinar tipo de canto (asume propiedad mat.TipoCanto, si no existe, usar mat.TipoTemplado o similar)
                string tipoCanto = !string.IsNullOrEmpty(mat.TipoCanto) ? mat.TipoCanto : "Filos Muertos";
                decimal espesor = mat.Espesor;
                decimal costoEnergia = 0, costoMantenimiento = 0;
                string moneda = "";
                string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    // Energia
                    string queryEnergia = "SELECT Valor2, Moneda FROM Generales WHERE Concepto = N'Cantos' AND Valor = @TipoCanto AND CAST(Valor4 AS decimal(10,2)) = @Espesor AND Valor1 = N'Energia'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryEnergia, conn))
                    {
                        cmd.Parameters.AddWithValue("@TipoCanto", tipoCanto);
                        cmd.Parameters.AddWithValue("@Espesor", espesor);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["Valor2"] != DBNull.Value)
                                    costoEnergia = Convert.ToDecimal(reader["Valor2"]);
                                if (reader["Moneda"] != DBNull.Value)
                                    moneda = reader["Moneda"].ToString();
                            }
                        }
                    }
                    // Mantenimiento
                    string queryMantenimiento = "SELECT Valor2 FROM Generales WHERE Concepto = N'Cantos' AND Valor = @TipoCanto AND CAST(Valor4 AS decimal(10,2)) = @Espesor AND Valor1 = N'Mantenimiento'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryMantenimiento, conn))
                    {
                        cmd.Parameters.AddWithValue("@TipoCanto", tipoCanto);
                        cmd.Parameters.AddWithValue("@Espesor", espesor);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["Valor2"] != DBNull.Value)
                                    costoMantenimiento = Convert.ToDecimal(reader["Valor2"]);
                            }
                        }
                    }
                }
                decimal costoML = costoEnergia + costoMantenimiento;
                decimal ml = 6.4m; // Perímetro total fijo
                decimal area = 2.4m; // Área total fija
                decimal costoM2 = (costoML * ml) / area;
                dgvTrabajos.Rows.Add(mat.Num, mat.Descripcion, tipoCanto, costoML, costoM2.ToString("C2"));
            }
        }

        private decimal ObtenerCostoProcesoTermicoBD(string procesoTermico, string? tipoTemplado)
        {
            if (string.IsNullOrWhiteSpace(tipoTemplado))
                return 0;
            try
            {
                string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    decimal energia = 0, mantenimiento = 0;
                    string queryEnergia = @"SELECT Valor3 FROM Generales WHERE Concepto = N'Proceso termico' AND Valor = @ProcesoTermico AND Valor2 = @TipoTemplado AND Valor1 = N'Energia'";
                    string queryMantenimiento = @"SELECT Valor3 FROM Generales WHERE Concepto = N'Proceso termico' AND Valor = @ProcesoTermico AND Valor2 = @TipoTemplado AND Valor1 = N'Mantenimiento'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryEnergia, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProcesoTermico", procesoTermico);
                        cmd.Parameters.AddWithValue("@TipoTemplado", tipoTemplado);
                        var result = cmd.ExecuteScalar();
                        energia = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryMantenimiento, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProcesoTermico", procesoTermico);
                        cmd.Parameters.AddWithValue("@TipoTemplado", tipoTemplado);
                        var result = cmd.ExecuteScalar();
                        mantenimiento = result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                    return energia + mantenimiento;
                }
            }
            catch
            {
                return 0;
            }
        }

        private void EdicionCostos_Load(object sender, EventArgs e)
        {

        }

        private void LblSubtotalcm_Click(object sender, EventArgs e)
        {

        }
    }
}
