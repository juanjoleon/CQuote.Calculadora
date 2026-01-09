using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CQuote.Calculadora.App
{
    public partial class ConfigSeparadorControl : UserControl
    {
        private ConfigMaterial? config;

        public ConfigSeparadorControl()
        {
            InitializeComponent();
        }

        // Public API to bind the selected node's configuration
        public void LoadConfig(ConfigMaterial config)
        {
            this.config = config;
            if (config != null)
            {
                TxtNumSeparador.Text = config.Num ?? string.Empty;
                LblNombreSeparador.Text = config.Descripcion ?? "Descripción Separador";
                // Si tienes un TextBox para el costo, agrégalo aquí
                // TxtSeparadorCosto.Text = config.CostoProveedor.ToString();
            }
            else
            {
                TxtNumSeparador.Text = string.Empty;
                LblNombreSeparador.Text = "Descripción Separador";
                // TxtSeparadorCosto.Text = string.Empty;
            }
        }

        // Example save handler—wire it to your Save button
        private void BtnGuardarSeparador_Click(object? sender, EventArgs e)
        {
            if (config == null) return;

            if (this.Controls.ContainsKey("TxtNumSeparador"))
                config.Num = ((TextBox)this.Controls["TxtNumSeparador"]).Text;

            if (this.Controls.ContainsKey("LblNombreSeparador"))
                config.Descripcion = ((Label)this.Controls["LblNombreSeparador"]).Text;

            if (this.Controls.ContainsKey("TxtSeparadorCosto") &&
                decimal.TryParse(((TextBox)this.Controls["TxtSeparadorCosto"]).Text, out var costo))
            {
                config.CostoProveedor = costo;
            }

            MessageBox.Show("Configuración de Separador actualizada.");
        }

        private void TxtNumSeparador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarSeparador(TxtNumSeparador.Text);
            }
        }

        private void BuscarSeparador(string numero)
        {
            string connectionString = "Server=lapjjlg\\SQLEXPRESS;Database=CQuote;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Buscar descripción y costos en Materiales y Costos
                string queryMateriales = "SELECT DESCRIPCION FROM Materiales WHERE Tipo='Separador' AND Num=@Num";
                using (SqlCommand cmd = new SqlCommand(queryMateriales, conn))
                {
                    cmd.Parameters.AddWithValue("@Num", numero);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descripcion = reader["DESCRIPCION"].ToString();
                            if (config != null)
                            {
                                config.Num = numero;
                                config.Descripcion = descripcion;
                            }
                            LblNombreSeparador.Text = descripcion;
                        }
                    }
                }
                string queryCostos = @"SELECT TOP 1 Costo, Importacion, Factor, Factor2, Factor3, Moneda, Desperdicio 
                                       FROM Costos 
                                       WHERE Actual='True' AND Tipo='Separador' AND Mercado='NAL' AND Num=@Num";
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
                            if (reader["Moneda"] != DBNull.Value)
                                config.Moneda = reader["Moneda"].ToString();
                        }
                    }
                }
            }
        }
    }
}