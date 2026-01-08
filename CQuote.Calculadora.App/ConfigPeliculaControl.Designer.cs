namespace CQuote.Calculadora.App
{
    partial class ConfigPeliculaControl
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
        private void InitializeComponent()
        {
            TxtNumPelicula = new TextBox();
            LblNombrePelicula = new Label();
            SuspendLayout();
            // 
            // TxtNumPelicula
            // 
            TxtNumPelicula.Location = new Point(20, 20);
            TxtNumPelicula.Name = "TxtNumPelicula";
            TxtNumPelicula.Size = new Size(100, 27);
            TxtNumPelicula.TabIndex = 0;
            TxtNumPelicula.KeyDown += TxtNumPelicula_KeyDown;
            // 
            // LblNombrePelicula
            // 
            LblNombrePelicula.AutoSize = true;
            LblNombrePelicula.Location = new Point(20, 60);
            LblNombrePelicula.Name = "LblNombrePelicula";
            LblNombrePelicula.Size = new Size(132, 20);
            LblNombrePelicula.TabIndex = 1;
            LblNombrePelicula.Text = "Descripción Película";
            // 
            // ConfigPeliculaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LblNombrePelicula);
            Controls.Add(TxtNumPelicula);
            Name = "ConfigPeliculaControl";
            Size = new Size(344, 426);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox TxtNumPelicula;
        public Label LblNombrePelicula;
    }
}
