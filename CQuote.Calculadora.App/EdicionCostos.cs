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

        public void CargarMateriales(List<(string Tipo, ConfigMaterial Material, string? Padre)> materiales, string procesoTermico)
        {
            DtvDetalle.Columns.Clear();
            DtvDetalle.Rows.Clear();
            DtvDetalle.Columns.Add("Tipo", "Tipo");
            DtvDetalle.Columns.Add("Num", "Num");
            DtvDetalle.Columns.Add("Descripcion", "Descripción");
            DtvDetalle.Columns.Add("CostoProveedor", "Costo Proveedor");
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
            DtvDetalle.Columns.Add("TipoTemplado", "TIPOTEMPLADO");
            DtvDetalle.Columns.Add("Espesor", "Espesor");

            decimal sumaTotal = 0;
            decimal sumaEspesorLaminados = 0;
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
                    costoProcesoTermico = ObtenerCostoProcesoTermicoBD(procesoTermico, mat.TipoTemplado);
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
                DtvDetalle.Rows.Add(
                    tipo,
                    mat.Num,
                    mat.Descripcion,
                    mat.CostoProveedor,
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
                    mat.TipoTemplado ?? string.Empty,
                    mat.Espesor
                );
            }
            // Mostrar la suma en el label
            if (LblSubtotal != null)
                LblSubtotal.Text = $"Subtotal: {sumaTotal:C2}";

            // Consulta para laminado
            decimal energia = 0, mantenimiento = 0;
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
            decimal totalLaminado = sumaEspesorLaminados * (energia + mantenimiento) * 2.5m;
            if (LblLaminado != null)
                LblLaminado.Text = $"Laminado: {totalLaminado:C2} {moneda}";
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
    }
}
