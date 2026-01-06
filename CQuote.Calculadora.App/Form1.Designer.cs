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
        button4 = new Button();
        SuspendLayout();
        // 
        // BtnCristal
        // 
        BtnCristal.Location = new Point(349, 37);
        BtnCristal.Name = "BtnCristal";
        BtnCristal.Size = new Size(94, 29);
        BtnCristal.TabIndex = 0;
        BtnCristal.Text = "button1";
        BtnCristal.UseVisualStyleBackColor = true;
        // 
        // Trview1
        // 
        Trview1.Location = new Point(23, 37);
        Trview1.Name = "Trview1";
        Trview1.Size = new Size(304, 510);
        Trview1.TabIndex = 1;
        // 
        // BtnPelicula
        // 
        BtnPelicula.Location = new Point(349, 85);
        BtnPelicula.Name = "BtnPelicula";
        BtnPelicula.Size = new Size(94, 29);
        BtnPelicula.TabIndex = 0;
        BtnPelicula.Text = "button1";
        BtnPelicula.UseVisualStyleBackColor = true;
        // 
        // BtnSeparador
        // 
        BtnSeparador.Location = new Point(349, 144);
        BtnSeparador.Name = "BtnSeparador";
        BtnSeparador.Size = new Size(94, 29);
        BtnSeparador.TabIndex = 0;
        BtnSeparador.Text = "button1";
        BtnSeparador.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new Point(623, 407);
        button4.Name = "button4";
        button4.Size = new Size(94, 29);
        button4.TabIndex = 0;
        button4.Text = "button1";
        button4.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(810, 630);
        Controls.Add(Trview1);
        Controls.Add(BtnSeparador);
        Controls.Add(BtnPelicula);
        Controls.Add(button4);
        Controls.Add(BtnCristal);
        Name = "Form1";
        Text = "Form1";
        // Load += Form1_Load; // Comentado para evitar error CS0103
        ResumeLayout(false);
    }

    #endregion

    private Button BtnCristal;
    private TreeView Trview1;
    private Button BtnPelicula;
    private Button BtnSeparador;
    private Button button4;
}
