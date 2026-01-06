namespace CQuote.Calculadora.App;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        BtnCristal = new Button();
        Trview1 = new TreeView();
        BtnPelicula = new Button();
        BtnSeparador = new Button();
        BtnCalcular = new Button();
        BtnMon = new Button();
        BtnLam = new Button();
        BtnIns = new Button();
        BtnBorrar = new Button();
        SuspendLayout();
        // 
        // BtnCristal
        // 
        BtnCristal.Location = new Point(363, 157);
        BtnCristal.Name = "BtnCristal";
        BtnCristal.Size = new Size(94, 29);
        BtnCristal.TabIndex = 0;
        BtnCristal.Text = "button1";
        BtnCristal.UseVisualStyleBackColor = true;
        // 
        // Trview1
        // 
        Trview1.Location = new Point(-7, 157);
        Trview1.Name = "Trview1";
        Trview1.Size = new Size(304, 394);
        Trview1.TabIndex = 1;
        // 
        // BtnPelicula
        // 
        BtnPelicula.Location = new Point(363, 205);
        BtnPelicula.Name = "BtnPelicula";
        BtnPelicula.Size = new Size(94, 29);
        BtnPelicula.TabIndex = 0;
        BtnPelicula.Text = "button1";
        BtnPelicula.UseVisualStyleBackColor = true;
        // 
        // BtnSeparador
        // 
        BtnSeparador.Location = new Point(363, 264);
        BtnSeparador.Name = "BtnSeparador";
        BtnSeparador.Size = new Size(94, 29);
        BtnSeparador.TabIndex = 0;
        BtnSeparador.Text = "button1";
        BtnSeparador.UseVisualStyleBackColor = true;
        // 
        // BtnCalcular
        // 
        BtnCalcular.Location = new Point(644, 479);
        BtnCalcular.Name = "BtnCalcular";
        BtnCalcular.Size = new Size(94, 29);
        BtnCalcular.TabIndex = 0;
        BtnCalcular.Text = "Calcular";
        BtnCalcular.UseVisualStyleBackColor = true;
        BtnCalcular.Click += button4_Click_1;
        // 
        // BtnMon
        // 
        BtnMon.Location = new Point(535, 157);
        BtnMon.Name = "BtnMon";
        BtnMon.Size = new Size(94, 29);
        BtnMon.TabIndex = 0;
        BtnMon.Text = "button1";
        BtnMon.UseVisualStyleBackColor = true;
        // 
        // BtnLam
        // 
        BtnLam.Location = new Point(535, 205);
        BtnLam.Name = "BtnLam";
        BtnLam.Size = new Size(94, 29);
        BtnLam.TabIndex = 0;
        BtnLam.Text = "button1";
        BtnLam.UseVisualStyleBackColor = true;
        // 
        // BtnIns
        // 
        BtnIns.Location = new Point(535, 254);
        BtnIns.Name = "BtnIns";
        BtnIns.Size = new Size(94, 29);
        BtnIns.TabIndex = 0;
        BtnIns.Text = "button1";
        BtnIns.UseVisualStyleBackColor = true;
        // 
        // BtnBorrar
        // 
        BtnBorrar.Location = new Point(644, 531);
        BtnBorrar.Name = "BtnBorrar";
        BtnBorrar.Size = new Size(94, 29);
        BtnBorrar.TabIndex = 0;
        BtnBorrar.Text = "Borrar";
        BtnBorrar.UseVisualStyleBackColor = true;
        BtnBorrar.Click += button4_Click_1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(810, 630);
        Controls.Add(Trview1);
        Controls.Add(BtnSeparador);
        Controls.Add(BtnPelicula);
        Controls.Add(BtnBorrar);
        Controls.Add(BtnCalcular);
        Controls.Add(BtnIns);
        Controls.Add(BtnLam);
        Controls.Add(BtnMon);
        Controls.Add(BtnCristal);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button BtnCristal;
    private TreeView Trview1;
    private Button BtnPelicula;
    private Button BtnSeparador;
    private Button BtnCalcular;
    private Button BtnMon;
    private Button BtnLam;
    private Button BtnIns;
    private Button BtnBorrar;
}
