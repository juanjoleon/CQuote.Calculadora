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
            Rbfactorcorte1 = new RadioButton();
            Rbfactorcorte2 = new RadioButton();
            Rbfactorcorte3 = new RadioButton();
            Rbfactorcorte4 = new RadioButton();
            RbCurvoRecocido = new RadioButton();
            RbCurvoTemplado = new RadioButton();
            RbSemitemplado = new RadioButton();
            RbRecocido = new RadioButton();
            RbTemplado = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            RButtonFilosMuertos = new RadioButton();
            RbCPB = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            comboBox1.Location = new Point(175, 461);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            // 
            // Rbfactorcorte1
            // 
            Rbfactorcorte1.AutoSize = true;
            Rbfactorcorte1.Location = new Point(25, 35);
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
            Rbfactorcorte2.Location = new Point(110, 35);
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
            Rbfactorcorte3.Location = new Point(206, 33);
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
            Rbfactorcorte4.Location = new Point(306, 31);
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
            RbCurvoRecocido.Location = new Point(269, 37);
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
            RbCurvoTemplado.Location = new Point(155, 69);
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
            RbSemitemplado.Location = new Point(21, 69);
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
            RbRecocido.Location = new Point(21, 39);
            RbRecocido.Name = "RbRecocido";
            RbRecocido.Size = new Size(92, 24);
            RbRecocido.TabIndex = 10;
            RbRecocido.TabStop = true;
            RbRecocido.Text = "Recocido";
            RbRecocido.UseVisualStyleBackColor = true;
            // 
            // RbTemplado
            // 
            RbTemplado.AutoSize = true;
            RbTemplado.Location = new Point(155, 37);
            RbTemplado.Name = "RbTemplado";
            RbTemplado.Size = new Size(97, 24);
            RbTemplado.TabIndex = 10;
            RbTemplado.TabStop = true;
            RbTemplado.Text = "Templado";
            RbTemplado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Rbfactorcorte1);
            groupBox1.Controls.Add(Rbfactorcorte2);
            groupBox1.Controls.Add(Rbfactorcorte3);
            groupBox1.Controls.Add(Rbfactorcorte4);
            groupBox1.Location = new Point(36, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 77);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de corte";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RbRecocido);
            groupBox2.Controls.Add(RbTemplado);
            groupBox2.Controls.Add(RbCurvoRecocido);
            groupBox2.Controls.Add(RbSemitemplado);
            groupBox2.Controls.Add(RbCurvoTemplado);
            groupBox2.Location = new Point(36, 325);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(414, 109);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Proceso Térmico";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RButtonFilosMuertos);
            groupBox3.Controls.Add(RbCPB);
            groupBox3.Location = new Point(36, 215);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(408, 77);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tipo de canto";
            // 
            // RButtonFilosMuertos
            // 
            RButtonFilosMuertos.AutoSize = true;
            RButtonFilosMuertos.Location = new Point(25, 35);
            RButtonFilosMuertos.Name = "RButtonFilosMuertos";
            RButtonFilosMuertos.Size = new Size(118, 24);
            RButtonFilosMuertos.TabIndex = 5;
            RButtonFilosMuertos.TabStop = true;
            RButtonFilosMuertos.Text = "Filos Muertos";
            RButtonFilosMuertos.UseVisualStyleBackColor = true;
            RButtonFilosMuertos.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // RbCPB
            // 
            RbCPB.AutoSize = true;
            RbCPB.Location = new Point(144, 35);
            RbCPB.Name = "RbCPB";
            RbCPB.Size = new Size(56, 24);
            RbCPB.TabIndex = 5;
            RbCPB.TabStop = true;
            RbCPB.Text = "CPB";
            RbCPB.UseVisualStyleBackColor = true;
            RbCPB.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // ConfigCristalControl
            // 
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(comboBox1);
            Controls.Add(TxtCristalNum);
            Controls.Add(LblNombreCristal);
            Name = "ConfigCristalControl";
            Size = new Size(479, 510);
            Load += ConfigCristalControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBox1;
        private RadioButton Rbfactorcorte1;
        private RadioButton Rbfactorcorte2;
        private RadioButton Rbfactorcorte3;
        private RadioButton Rbfactorcorte4;
        private RadioButton RbCurvoRecocido;
        private RadioButton RbCurvoTemplado;
        private RadioButton RbSemitemplado;
        private RadioButton RbRecocido;
        private RadioButton RbTemplado;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private RadioButton RButtonFilosMuertos;
        private RadioButton RbCPB;
    }
}
