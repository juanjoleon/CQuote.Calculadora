namespace CQuote.Calculadora.App
{
    partial class EdicionCostos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DtvDetalle = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DtvDetalle).BeginInit();
            SuspendLayout();
            // 
            // DtvDetalle
            // 
            DtvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtvDetalle.Location = new Point(31, 48);
            DtvDetalle.Name = "DtvDetalle";
            DtvDetalle.RowHeadersWidth = 51;
            DtvDetalle.Size = new Size(1357, 224);
            DtvDetalle.TabIndex = 0;
            // 
            // EdicionCostos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 886);
            Controls.Add(DtvDetalle);
            Name = "EdicionCostos";
            Text = "EdicionCostos";
            ((System.ComponentModel.ISupportInitialize)DtvDetalle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DtvDetalle;
    }
}