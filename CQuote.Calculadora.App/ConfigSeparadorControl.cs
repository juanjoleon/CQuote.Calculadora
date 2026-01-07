using System;
using System.Windows.Forms;

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
                if (this.Controls.ContainsKey("TxtSeparadorNum"))
                    ((TextBox)this.Controls["TxtSeparadorNum"]).Text = config.Num ?? string.Empty;

                if (this.Controls.ContainsKey("LblNombreSeparador"))
                    ((Label)this.Controls["LblNombreSeparador"]).Text = config.Descripcion ?? "Descripción Separador";

                if (this.Controls.ContainsKey("TxtSeparadorCosto"))
                    ((TextBox)this.Controls["TxtSeparadorCosto"]).Text = config.CostoProveedor.ToString();
            }
            else
            {
                if (this.Controls.ContainsKey("TxtSeparadorNum"))
                    ((TextBox)this.Controls["TxtSeparadorNum"]).Text = string.Empty;

                if (this.Controls.ContainsKey("LblNombreSeparador"))
                    ((Label)this.Controls["LblNombreSeparador"]).Text = "Descripción Separador";

                if (this.Controls.ContainsKey("TxtSeparadorCosto"))
                    ((TextBox)this.Controls["TxtSeparadorCosto"]).Text = string.Empty;
            }
        }

        // Example save handler—wire it to your Save button
        private void BtnGuardarSeparador_Click(object? sender, EventArgs e)
        {
            if (config == null) return;

            if (this.Controls.ContainsKey("TxtSeparadorNum"))
                config.Num = ((TextBox)this.Controls["TxtSeparadorNum"]).Text;

            if (this.Controls.ContainsKey("LblNombreSeparador"))
                config.Descripcion = ((Label)this.Controls["LblNombreSeparador"]).Text;

            if (this.Controls.ContainsKey("TxtSeparadorCosto") &&
                decimal.TryParse(((TextBox)this.Controls["TxtSeparadorCosto"]).Text, out var costo))
            {
                config.CostoProveedor = costo;
            }

            MessageBox.Show("Configuración de Separador actualizada.");
        }
    }
}