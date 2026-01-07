namespace CQuote.Calculadora.App
{
    partial class ConfigCristalControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox TxtCristalNum;
        private System.Windows.Forms.Label LblNombreCristal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.TxtCristalNum = new System.Windows.Forms.TextBox();
            this.LblNombreCristal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtCristalNum
            // 
            this.TxtCristalNum.Location = new System.Drawing.Point(20, 20);
            this.TxtCristalNum.Name = "TxtCristalNum";
            this.TxtCristalNum.Size = new System.Drawing.Size(100, 23);
            this.TxtCristalNum.TabIndex = 0;
            this.TxtCristalNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCristalNum_KeyDown);
            // 
            // LblNombreCristal
            // 
            this.LblNombreCristal.AutoSize = true;
            this.LblNombreCristal.Location = new System.Drawing.Point(20, 60);
            this.LblNombreCristal.Name = "LblNombreCristal";
            this.LblNombreCristal.Size = new System.Drawing.Size(120, 15);
            this.LblNombreCristal.TabIndex = 1;
            this.LblNombreCristal.Text = "Descripción Cristal";
            // 
            // ConfigCristalControl
            // 
            this.Controls.Add(this.TxtCristalNum);
            this.Controls.Add(this.LblNombreCristal);
            this.Name = "ConfigCristalControl";
            this.Size = new System.Drawing.Size(250, 100);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
