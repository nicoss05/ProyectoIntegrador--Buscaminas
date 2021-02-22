using System;

namespace Buscaminas
{
    class Tablero
    {
        private Casilla[,] casillas;
        private int filas = 0;
        private int columnas = 0;
        private int numeroBombas = 0;
        private int nCasillasNoPulsadas = 0;

        public int getNumeroBombas(){ 
             return numeroBombas;
        }
        public int getNCasillasNoPulsadas()
        {
            return nCasillasNoPulsadas;
        }
  
        public Tablero(int fils, int cols)
        {
            filas = fils + 2;
            columnas = cols + 2;
            nCasillasNoPulsadas = fils * cols;
            fils += 2;
            cols += 2;

            casillas = new Casilla[fils, cols];

            for (int i = 0; i < fils; i++)
                for (int j = 0; j < cols; j++)
                    casillas[i, j] = new Casilla();
            inicializa();
        }

        public void visualiza()
        {
            for (int i = 1; i < filas - 1; i++)
            {
                for (int j = 1; j < columnas - 1; j++)
                {
                    Console.Write(" ");
                    casillas[i, j].visualiza();
                   // Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void inicializa()
        {

            for (int i = 0; i < filas; i++)
            {
                casillas[i, 0].sumaUno();
                casillas[i, columnas - 1].sumaUno();
            }

            for (int i = 0; i < columnas; i++)
            {
                casillas[0, i].sumaUno();
                casillas[filas - 1, i].sumaUno();
            }

            Random rand = new Random();
            for (int i = 1; i < filas - 1; i++)
            {
                for (int j = 1; j < columnas - 1; j++)
                {
                    if (rand.Next(100) < 10)
                    {
                       // numeroCasillas--;
                        numeroBombas++;
                        //pon bomba
                        casillas[i, j].ponBomba();
                        //suma alrededor
                        for (int f = i - 1; f <= i + 1; f++)
                            for (int c = j - 1; c <= j + 1; c++)
                            {
                                casillas[f, c].sumaUno();
                               // numeroCasillas--;
                            }
                    }
                }
            }

        }

        internal void levanta(int fila, int columna)
        {
            
            if (!casillas[fila, columna].isLevantada()&& fila!=0 && columna!=0
                && fila != filas && columna != columnas && fila != filas-1 && columna != columnas-1)
            {
                nCasillasNoPulsadas--;
            }
            casillas[fila, columna].levanta();
            
            //si no hay bomba y el numerito es cero
            //levanta alrededor
            if (casillas[fila, columna].isVacia())
                for (int i = fila - 1; i <= fila + 1; i++)
                    for (int j = columna - 1; j <= columna + 1; j++)
                        if (!casillas[i, j].isLevantada())
                        {
                            this.levanta(i, j);
                            
                            
                        }
        }

        internal Casilla dameCasilla(int i, int j)
        {
            return casillas[i, j];
        }
    }
}
