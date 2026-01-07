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
                string queryMateriales = "SELECT DESCRIPCION FROM Materiales WHERE Tipo='Cristal' AND Num=@Num";
                using (SqlCommand cmd = new SqlCommand(queryMateriales, conn))
                {
                    cmd.Parameters.AddWithValue("@Num", numero);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descripcion = reader["DESCRIPCION"].ToString();
                            LblNombreCristal.Text = descripcion;
                            if (config != null)
                            {
                                config.Num = numero;
                                config.Descripcion = descripcion;
                            }
                        }
                    }
                }

                // 2. Buscar costo proveedor en Costos
                string queryCostos = @"SELECT Costo FROM Costos 
                                       WHERE Actual='True' AND Tipo='Cristal' AND Mercado='NAL' AND Num=@Num";
                using (SqlCommand cmd = new SqlCommand(queryCostos, conn))
                {
                    cmd.Parameters.AddWithValue("@Num", numero);
                    object result = cmd.ExecuteScalar();
                    if (result != null && config != null)
                    {
                        decimal costoProveedor = Convert.ToDecimal(result);
                        config.CostoProveedor = costoProveedor;
                        MessageBox.Show($"Costo proveedor actualizado: {costoProveedor}");
                    }
                }
            }
        }
    }
}
