using System;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class ConfigPeliculaControl : UserControl
    {
        private ConfigMaterial? config;

        public ConfigPeliculaControl()
        {
            InitializeComponent();
        }

        // Public API to bind the selected node's configuration
        public void LoadConfig(ConfigMaterial config)
        {
            this.config = config;

            if (config != null)
            {
                if (this.Controls.ContainsKey("TxtPeliculaNum"))
                    ((TextBox)this.Controls["TxtPeliculaNum"]).Text = config.Num ?? string.Empty;

                if (this.Controls.ContainsKey("LblNombrePelicula"))
                    ((Label)this.Controls["LblNombrePelicula"]).Text = config.Descripcion ?? "Descripción Película";

                if (this.Controls.ContainsKey("TxtPeliculaCosto"))
                    ((TextBox)this.Controls["TxtPeliculaCosto"]).Text = config.CostoProveedor.ToString();
            }
            else
            {
                if (this.Controls.ContainsKey("TxtPeliculaNum"))
                    ((TextBox)this.Controls["TxtPeliculaNum"]).Text = string.Empty;

                if (this.Controls.ContainsKey("LblNombrePelicula"))
                    ((Label)this.Controls["LblNombrePelicula"]).Text = "Descripción Película";

                if (this.Controls.ContainsKey("TxtPeliculaCosto"))
                    ((TextBox)this.Controls["TxtPeliculaCosto"]).Text = string.Empty;
            }
        }

        // Example save handler—wire it to your Save button
        private void BtnGuardarPelicula_Click(object? sender, EventArgs e)
        {
            if (config == null) return;

            if (this.Controls.ContainsKey("TxtPeliculaNum"))
                config.Num = ((TextBox)this.Controls["TxtPeliculaNum"]).Text;

            if (this.Controls.ContainsKey("LblNombrePelicula"))
                config.Descripcion = ((Label)this.Controls["LblNombrePelicula"]).Text;

            if (this.Controls.ContainsKey("TxtPeliculaCosto") &&
                decimal.TryParse(((TextBox)this.Controls["TxtPeliculaCosto"]).Text, out var costo))
            {
                config.CostoProveedor = costo;
            }

            MessageBox.Show("Configuración de Película actualizada.");
        }
    }
}