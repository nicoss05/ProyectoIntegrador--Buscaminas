using System;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2()
        {

            InitializeComponent();

        }
        private MiButton[,] botones;
        private Tablero tablero;
        private int seg;
        private int min;
        private int hor;
        private int row;
        private int col;

        private void buttonprueba_Click(object sender, EventArgs e)
        {
            row = 8;
            col = 8;

        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

    }
}
