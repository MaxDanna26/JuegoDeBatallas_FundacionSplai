using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Juego
    {
        private static List<Jugador> jugadores = new List<Jugador>();
        private static List<Carta> cartasEnJuego = new List<Carta>();
        private static string ganador;
        private static bool hayCartas = true;


        public static void JuegoBatalla()
        {

            Console.WriteLine("Bienvenido usuario al juego de batallas: ");
            Console.WriteLine("-----------------------------------------");
            int CantJugadores;

            do
            {
                Console.WriteLine("Con cuantos jugadores desea jugar? ");
                CantJugadores = int.Parse(Console.ReadLine());

                if (CantJugadores < 2 || CantJugadores > 5)
                {
                    Console.WriteLine("El número de jugadores debe estar entre 2 y 5.");
                }
            } while (CantJugadores < 2 || CantJugadores > 5);

            for (int i = 0; i < CantJugadores; i++)
            {
                Console.WriteLine("Dime el nombre del jugador: ");
                string nombre = Console.ReadLine();

                Jugador jugador = new Jugador(nombre);
                jugadores.Add(jugador);
            }

            Baraja barajaJuego = new Baraja();
            barajaJuego.LlenarBaraja();

            RepartirCartas(barajaJuego, CantJugadores);

            Console.Clear();

            do
            {
                JugarRonda();

                AsignacionDePremio(ganador);

                ComprobacionDeMazos();

                Console.ReadKey();

            }while (hayCartas);

            Console.ReadKey();

        }  



        public static void RepartirCartas(Baraja barajaJuego,int CantJugadores)
        {
            barajaJuego.MezclarBaraja();

            while (barajaJuego.Cartas.Count>0)
            {
                for(int i = 0; i < CantJugadores; i++)
                {
                    Carta carta = barajaJuego.Robar();
                    
                    jugadores[i].MazoJugador.Cartas.Add(carta);
                }

            }
        }

        public static string JugarRonda()
        {

            Console.WriteLine("Jueguen sus cartas: ");
            Console.WriteLine("--------------------");

            bool empate = false;

            do {
                empate = false;
                int cartaMasAlta = 0;

                for (int i = 0; i < jugadores.Count; i++)
                {
                    Carta mano = jugadores[i].MazoJugador.Robar();
                    if (mano != null)
                    {
                        cartasEnJuego.Add(mano);
                        string nombreJugador = jugadores[i].Descripcion;
                        Console.WriteLine($"El jugador {nombreJugador} bajo la carta: ");
                        string descripcion = mano.Descripcion;
                        Console.WriteLine(descripcion);
                    }
                    else
                    {
                        Console.WriteLine("No hay mas cartas para este jugador.");
                        string nombrePerdedor = jugadores[i].Descripcion;
                        Console.WriteLine($"El jugador {nombrePerdedor} ha perdido!");
                    }

                    int actual = mano.Numero;
                    if (cartaMasAlta == actual)
                    {
                        empate = true;
                    }
                    else if (cartaMasAlta < actual)
                    {
                        ganador = jugadores[i].Descripcion;
                        cartaMasAlta = actual;
                    }

                }

                if (empate)
                {
                    Console.WriteLine("Hay empate, se jugara otra ronda!");
                    Console.WriteLine("---------------------------------");
                }
                else
                {
                    Console.WriteLine($"La carta mas alta es la de numero {cartaMasAlta} y gano el jugador {ganador}");
                }

            } while (empate);


            return ganador;
        }


        public static void AsignacionDePremio(string ganador)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Añadiendo cartas al ganador... ");

            for (int i = 0; i < jugadores.Count; i++)
            {
                string nombre = jugadores[i].Descripcion;
                if (nombre == ganador)
                {
                    jugadores[i].MazoJugador.Cartas.AddRange(cartasEnJuego);
                }
            }

        }

        public static void ComprobacionDeMazos()
        {
            for (int i = 0; i < jugadores.Count; i++)
            {
                string nombre = jugadores[i].Descripcion;
                int cantCartas = jugadores[i].MazoJugador.Cartas.Count;

                if(cantCartas > 0) 
                {
                    Console.WriteLine("Continuamos jugando..");
                }
                else if (cantCartas == 0)
                {
                    Console.WriteLine($"El jugador {nombre} quedo eliminado");
                    jugadores.Remove(jugadores[i]);
                    hayCartas = false;
                }
            }

            Console.WriteLine("--------- Fin De partida -------------");
            Console.WriteLine("                                      ");

        }

    }
}