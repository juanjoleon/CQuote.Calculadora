using System;
using System.Windows.Forms;

namespace CQuote.Calculadora.App
{
    public partial class Detalle : Form
    {
        public Detalle()
        {
            InitializeComponent();
        }

        // Exponer el RichTextBox para asignar texto desde Form1
        public RichTextBox rtxtDetalle
        {
            get { return richTextBox1; }
        }
    }
}
