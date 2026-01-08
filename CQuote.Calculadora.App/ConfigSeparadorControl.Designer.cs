namespace CQuote.Calculadora.App
{
    partial class ConfigSeparadorControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        public TextBox TxtNumSeparador;
        public Label LblNombreSeparador;

        private void InitializeComponent()
        {
            this.TxtNumSeparador = new System.Windows.Forms.TextBox();
            this.LblNombreSeparador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtNumSeparador
            // 
            this.TxtNumSeparador.Location = new System.Drawing.Point(20, 20);
            this.TxtNumSeparador.Name = "TxtNumSeparador";
            this.TxtNumSeparador.Size = new System.Drawing.Size(100, 27);
            this.TxtNumSeparador.TabIndex = 0;
            this.TxtNumSeparador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNumSeparador_KeyDown);
            // 
            // LblNombreSeparador
            // 
            this.LblNombreSeparador.AutoSize = true;
            this.LblNombreSeparador.Location = new System.Drawing.Point(20, 60);
            this.LblNombreSeparador.Name = "LblNombreSeparador";
            this.LblNombreSeparador.Size = new System.Drawing.Size(132, 20);
            this.LblNombreSeparador.TabIndex = 1;
            this.LblNombreSeparador.Text = "Descripción Separador";
            // 
            // ConfigSeparadorControl
            // 
            this.Controls.Add(this.TxtNumSeparador);
            this.Controls.Add(this.LblNombreSeparador);
            this.Name = "ConfigSeparadorControl";
            this.Size = new System.Drawing.Size(344, 426);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
