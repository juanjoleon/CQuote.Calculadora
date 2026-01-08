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
            TxtCristalNum = new TextBox();
            LblNombreCristal = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            Rbfactorcorte1 = new RadioButton();
            Rbfactorcorte2 = new RadioButton();
            Rbfactorcorte3 = new RadioButton();
            Rbfactorcorte4 = new RadioButton();
            RbCurvoRecocido = new RadioButton();
            RbCurvoTemplado = new RadioButton();
            RbSemitemplado = new RadioButton();
            RbRecocido = new RadioButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // TxtCristalNum
            // 
            TxtCristalNum.Location = new Point(20, 20);
            TxtCristalNum.Name = "TxtCristalNum";
            TxtCristalNum.Size = new Size(100, 27);
            TxtCristalNum.TabIndex = 0;
            TxtCristalNum.KeyDown += TxtCristalNum_KeyDown;
            // 
            // LblNombreCristal
            // 
            LblNombreCristal.AutoSize = true;
            LblNombreCristal.Location = new Point(20, 60);
            LblNombreCristal.Name = "LblNombreCristal";
            LblNombreCristal.Size = new Size(132, 20);
            LblNombreCristal.TabIndex = 1;
            LblNombreCristal.Text = "Descripción Cristal";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(199, 292);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 95);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "Tipo corte";
            // 
            // Rbfactorcorte1
            // 
            Rbfactorcorte1.AutoSize = true;
            Rbfactorcorte1.Location = new Point(124, 95);
            Rbfactorcorte1.Name = "Rbfactorcorte1";
            Rbfactorcorte1.Size = new Size(68, 24);
            Rbfactorcorte1.TabIndex = 5;
            Rbfactorcorte1.TabStop = true;
            Rbfactorcorte1.Text = "Recto";
            Rbfactorcorte1.UseVisualStyleBackColor = true;
            Rbfactorcorte1.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Rbfactorcorte2
            // 
            Rbfactorcorte2.AutoSize = true;
            Rbfactorcorte2.Location = new Point(209, 95);
            Rbfactorcorte2.Name = "Rbfactorcorte2";
            Rbfactorcorte2.Size = new Size(90, 24);
            Rbfactorcorte2.TabIndex = 5;
            Rbfactorcorte2.TabStop = true;
            Rbfactorcorte2.Text = "En forma";
            Rbfactorcorte2.UseVisualStyleBackColor = true;
            Rbfactorcorte2.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Rbfactorcorte3
            // 
            Rbfactorcorte3.AutoSize = true;
            Rbfactorcorte3.Location = new Point(305, 93);
            Rbfactorcorte3.Name = "Rbfactorcorte3";
            Rbfactorcorte3.Size = new Size(84, 24);
            Rbfactorcorte3.TabIndex = 5;
            Rbfactorcorte3.TabStop = true;
            Rbfactorcorte3.Text = "Maquila";
            Rbfactorcorte3.UseVisualStyleBackColor = true;
            Rbfactorcorte3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // Rbfactorcorte4
            // 
            Rbfactorcorte4.AutoSize = true;
            Rbfactorcorte4.Location = new Point(405, 91);
            Rbfactorcorte4.Name = "Rbfactorcorte4";
            Rbfactorcorte4.Size = new Size(78, 24);
            Rbfactorcorte4.TabIndex = 5;
            Rbfactorcorte4.TabStop = true;
            Rbfactorcorte4.Text = "Lámina";
            Rbfactorcorte4.UseVisualStyleBackColor = true;
            Rbfactorcorte4.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // RbCurvoRecocido
            // 
            RbCurvoRecocido.AutoSize = true;
            RbCurvoRecocido.Location = new Point(492, 151);
            RbCurvoRecocido.Name = "RbCurvoRecocido";
            RbCurvoRecocido.Size = new Size(130, 24);
            RbCurvoRecocido.TabIndex = 7;
            RbCurvoRecocido.TabStop = true;
            RbCurvoRecocido.Text = "Curvo recocido";
            RbCurvoRecocido.UseVisualStyleBackColor = true;
            // 
            // RbCurvoTemplado
            // 
            RbCurvoTemplado.AutoSize = true;
            RbCurvoTemplado.Location = new Point(347, 151);
            RbCurvoTemplado.Name = "RbCurvoTemplado";
            RbCurvoTemplado.Size = new Size(139, 24);
            RbCurvoTemplado.TabIndex = 8;
            RbCurvoTemplado.TabStop = true;
            RbCurvoTemplado.Text = "Curvo Templado";
            RbCurvoTemplado.UseVisualStyleBackColor = true;
            // 
            // RbSemitemplado
            // 
            RbSemitemplado.AutoSize = true;
            RbSemitemplado.Location = new Point(222, 151);
            RbSemitemplado.Name = "RbSemitemplado";
            RbSemitemplado.Size = new Size(128, 24);
            RbSemitemplado.TabIndex = 9;
            RbSemitemplado.TabStop = true;
            RbSemitemplado.Text = "Semitemplado";
            RbSemitemplado.UseVisualStyleBackColor = true;
            // 
            // RbRecocido
            // 
            RbRecocido.AutoSize = true;
            RbRecocido.Location = new Point(124, 153);
            RbRecocido.Name = "RbRecocido";
            RbRecocido.Size = new Size(92, 24);
            RbRecocido.TabIndex = 10;
            RbRecocido.TabStop = true;
            RbRecocido.Text = "Recocido";
            RbRecocido.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 130);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 6;
            label2.Text = "Proceso térmico";
            // 
            // ConfigCristalControl
            // 
            Controls.Add(RbCurvoRecocido);
            Controls.Add(RbCurvoTemplado);
            Controls.Add(RbSemitemplado);
            Controls.Add(RbRecocido);
            Controls.Add(label2);
            Controls.Add(Rbfactorcorte4);
            Controls.Add(Rbfactorcorte3);
            Controls.Add(Rbfactorcorte2);
            Controls.Add(Rbfactorcorte1);
            Controls.Add(comboBox1);
            Controls.Add(TxtCristalNum);
            Controls.Add(label1);
            Controls.Add(LblNombreCristal);
            Name = "ConfigCristalControl";
            Size = new Size(627, 427);
            Load += ConfigCristalControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBox1;
        private Label label1;
        private RadioButton Rbfactorcorte1;
        private RadioButton Rbfactorcorte2;
        private RadioButton Rbfactorcorte3;
        private RadioButton Rbfactorcorte4;
        private RadioButton RbCurvoRecocido;
        private RadioButton RbCurvoTemplado;
        private RadioButton RbSemitemplado;
        private RadioButton RbRecocido;
        private Label label2;
    }
}
