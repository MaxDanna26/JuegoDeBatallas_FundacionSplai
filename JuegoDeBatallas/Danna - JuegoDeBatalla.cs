using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poker
{
    internal class Program

    {
        static void Main(string[] args)
        {
            ////Baraja baraja1 = new Baraja(12);

            ////baraja1.LlenarBaraja();

            //Baraja baraja1 = new Baraja(48);

            //for (int i = 1; i <= 12; i++)
            //{
            //    Carta Oro = new Carta(i, "Oro");
            //    baraja1.Cartas.Add(Oro);

            //    Carta Espada = new Carta(i, "Espada");
            //    baraja1.Cartas.Add(Espada);

            //    Carta Palo = new Carta(i, "Palo");
            //    baraja1.Cartas.Add(Palo);

            //    Carta Copa = new Carta(i, "Copa");
            //    baraja1.Cartas.Add(Copa);
            //}

            //baraja1.MostrarBaraja();

            //baraja1.Robar();

            //baraja1.MostrarBaraja();

            ////baraja1.Robar(2);

            ////baraja1.RobarRandom(2);

            ////baraja1.MezclarBaraja();
            //
            Poker.Juego.JuegoBatalla();

            Console.ReadKey();


        }

    }
}
