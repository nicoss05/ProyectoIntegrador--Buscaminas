using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    class Casilla {
        private bool levantada = false;
        private bool bomba = false;
        private int numero_bombas = 0;

        public Casilla()
        {

        }

        public bool isLevantada()
        {
            return levantada;
        }

        public void levanta()
        {
            levantada = true;
        }

        public bool isBomba()
        {
            return bomba;
        }

        public void ponBomba()
        {
            bomba = true;
        }

        public void sumaUno()
        {
            numero_bombas++;
        }

        public void visualiza()
        {
            if (!isLevantada())
                Console.Write("#");
            else if (isBomba())
                Console.Write("B");
            else if (numero_bombas == 0)
                Console.Write(".");
            else
                Console.Write(numero_bombas);

        }

        public bool isVacia()
        {
            return (!this.isBomba() && numero_bombas == 0);
        }

        internal int numeroBombas()
        {
            return numero_bombas;
        }
    }
}
