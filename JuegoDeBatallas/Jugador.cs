using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Jugador
    {
        private Baraja mazoJugador;
        private string nombre;
        public Baraja MazoJugador { get => mazoJugador; set => mazoJugador = value; }

       public Jugador(string nombre)
        {
            this.mazoJugador = new Baraja();
            this.nombre = nombre;
        }

        public string Descripcion
        {
            get => nombre;
        }


    }
}
