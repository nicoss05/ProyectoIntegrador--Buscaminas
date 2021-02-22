using System;
using System.Windows.Forms;
using System.Drawing;

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private MiButton[,] botones;
        private Tablero tablero;
        private static Image bombaImagen = ((System.Drawing.Image)(Properties.Resources.bomba));
        private Bitmap bombaBitmap = new Bitmap(bombaImagen, new Size(20, 20));
        private int seg;
        private int min;
        private int hor;
        private int row;
        private int col;

        private void button1_Click(object sender, EventArgs e){
            
            row = 8;
            col = 8;
            timer1.Enabled = false;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            this.ClientSize = new System.Drawing.Size(300, 300);
            flowLayoutPanel1.Size = new System.Drawing.Size(160, 160);
            inicializarTableroJuego(8, 8);
        }
        private void button2_Click(object sender, EventArgs e){
            row = 16;
            col = 16;
            timer1.Enabled = false;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            this.ClientSize = new System.Drawing.Size(500, 500);
            flowLayoutPanel1.Size = new System.Drawing.Size(320, 320);
            inicializarTableroJuego(16, 16);
            
        }

        private void button3_Click(object sender, EventArgs e){
            row = 16;
            col = 30;
            timer1.Enabled = false;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            this.ClientSize = new System.Drawing.Size(650, 450);
            flowLayoutPanel1.Size = new System.Drawing.Size(600, 320);
            inicializarTableroJuego(30, 16);
        }
       
        private void inicializarTableroJuego(int col, int row)
        {
            seg = 0;
            min = 0;
            hor = 0;
            this.label3.Text = "0:0:0";

            flowLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue;
            tablero = new Tablero(row, col);
            botones = new MiButton[row, col];
            label2.Text = "" + tablero.getNCasillasNoPulsadas();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    botones[i, j] = new MiButton(i, j);
                    botones[i, j].Size = new System.Drawing.Size(20, 20);
                    botones[i, j].BackColor = System.Drawing.Color.SteelBlue;
                    botones[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    botones[i, j].Margin = new System.Windows.Forms.Padding(0);
                    botones[i, j].Padding = new System.Windows.Forms.Padding(0);
                    this.flowLayoutPanel1.Controls.Add(botones[i, j]);
                    
                    botones[i, j].Click += new System.EventHandler(this.button_Click);
                }
            flowLayoutPanel1.WrapContents = true;
            refrescarTableroUI(row, col);
        }
        private void refrescarTableroUI(int rows, int cols)
        {

            label2.Text = "" + tablero.getNumeroBombas();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    botones[i, j].Font = new Font("Arial", 6, FontStyle.Bold);
                    Casilla contenido = tablero.dameCasilla(i + 1, j + 1);
                    if (!contenido.isLevantada())
                        botones[i, j].Text = "";
                    else if (contenido.isBomba())
                    {
                        timer1.Enabled = false;

                        botones[i, j].BackgroundImage = bombaBitmap;
                        botones[i, j].BackColor = System.Drawing.Color.Lavender;
                       flowLayoutPanel1.Enabled = false;
                        DialogResult result;
                        result = MessageBox.Show("Te quedaste sin piernas! , quieres salir del juego?", "My Application",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.Close();
                        }
                        else { return; }
                    }
                    else
                    {
                        botones[i, j].BackColor = System.Drawing.Color.Lavender;
                        botones[i, j].FlatAppearance.BorderColor = Color.Black;
                        botones[i, j].Font = new Font("Arial", 7, FontStyle.Bold);
                        if (contenido.numeroBombas() == 1)
                        {
                            botones[i, j].ForeColor = System.Drawing.Color.SteelBlue;
                            botones[i, j].Text = "" + contenido.numeroBombas();
                        }
                        else if (contenido.numeroBombas() == 2)
                        {
                            botones[i, j].ForeColor = System.Drawing.Color.Green;
                            botones[i, j].Text = "" + contenido.numeroBombas();
                        }
                        else if (contenido.numeroBombas() > 2)
                        {
                            botones[i, j].ForeColor = System.Drawing.Color.Red;
                            botones[i, j].Text = "" + contenido.numeroBombas();
                        }
                        else { botones[i, j].Text = ""; }

                    }

                }
            }
            if (tablero.getNCasillasNoPulsadas() == tablero.getNumeroBombas())
            {
                DialogResult result;
                flowLayoutPanel1.Enabled = false;
                timer1.Enabled = false;

                result = MessageBox.Show("Ganaste en "+this.label3.Text+", salir del juego?", "My Application",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }

            }


        }
     
        private void button_Click(object sender, EventArgs e){
            timer1.Enabled = true;
            int fila = ((MiButton)sender).i;
            int colu = ((MiButton)sender).j;

            tablero.levanta(((MiButton)sender).i + 1,
                            ((MiButton)sender).j + 1);

            refrescarTableroUI(row, col);
        }   

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (min == 61) {
                hor += 1;
                min = 0;
            }
            if(seg ==61){
                min += 1;
                seg = 0;
            }
            seg+=1;
            this.label3.Text = "" + hor+":"+min+":"+ seg;
        }



    }
}
