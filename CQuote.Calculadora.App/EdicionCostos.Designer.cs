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
            label1 = new Label();
            LblSubtotal = new Label();
            LblLaminado = new Label();
            LblSubtotalcm = new Label();
            ((System.ComponentModel.ISupportInitialize)DtvDetalle).BeginInit();
            SuspendLayout();
            // 
            // DtvDetalle
            // 
            DtvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtvDetalle.Location = new Point(31, 48);
            DtvDetalle.Name = "DtvDetalle";
            DtvDetalle.RowHeadersWidth = 51;
            DtvDetalle.Size = new Size(1785, 266);
            DtvDetalle.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // LblSubtotal
            // 
            LblSubtotal.AutoSize = true;
            LblSubtotal.Location = new Point(1409, 340);
            LblSubtotal.Name = "LblSubtotal";
            LblSubtotal.Size = new Size(50, 20);
            LblSubtotal.TabIndex = 2;
            LblSubtotal.Text = "label2";
            // 
            // LblLaminado
            // 
            LblLaminado.AutoSize = true;
            LblLaminado.Location = new Point(1286, 340);
            LblLaminado.Name = "LblLaminado";
            LblLaminado.Size = new Size(50, 20);
            LblLaminado.TabIndex = 2;
            LblLaminado.Text = "label2";
            // 
            // LblSubtotalcm
            // 
            LblSubtotalcm.AutoSize = true;
            LblSubtotalcm.Location = new Point(1409, 370);
            LblSubtotalcm.Name = "LblSubtotalcm";
            LblSubtotalcm.Size = new Size(120, 20);
            LblSubtotalcm.TabIndex = 3;
            LblSubtotalcm.Text = "Subtotal c/margen";
            // 
            // EdicionCostos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1828, 886);
            Controls.Add(LblSubtotalcm);
            Controls.Add(LblLaminado);
            Controls.Add(LblSubtotal);
            Controls.Add(label1);
            Controls.Add(DtvDetalle);
            Name = "EdicionCostos";
            Text = "EdicionCostos";
            Load += EdicionCostos_Load;
            ((System.ComponentModel.ISupportInitialize)DtvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DtvDetalle;
        private Label label1;
        private Label LblSubtotal;
        private Label LblLaminado;
        private Label LblSubtotalcm;
    }
}