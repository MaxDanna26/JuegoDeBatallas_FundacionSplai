using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Baraja
    {

        private List<Carta> cartas;
        public List<Carta> Cartas { get => cartas ; set => cartas = value; }


        public Baraja() 
        {            
            cartas = new List<Carta>();
        }


        public void LlenarBaraja()
        {

            for (int i = 1; i < 12; i++)
            {
                Carta Oro = new Carta(i, "Oro");
                Cartas.Add(Oro);

                Carta Espada = new Carta(i, "Espada");
                Cartas.Add(Espada);

                Carta Palo = new Carta(i, "Palo");
                Cartas.Add(Palo);

                Carta Copa = new Carta(i, "Copa");
                Cartas.Add(Copa);
            }
        }
        
        public Carta Robar()
        {
            if (cartas.Count > 0)
            {
                Carta carta = cartas[cartas.Count - 1];
                cartas.RemoveAt(cartas.Count - 1);
                return carta;
            }
            else
            {
                return null;
            }
        }

        public void Robar(int numero)
        {
            cartas.RemoveAt(numero);
        }

        public void RobarRandom(int numero)
        {
            Random rand = new Random();
            int indice = rand.Next(1,cartas.Count);
            cartas.RemoveAt(indice);
        }

        public void MostrarBaraja()
        {
            foreach (var elemento in cartas)
            {
              string descripcion =  elemento.Descripcion;
                Console.WriteLine(descripcion);
            }

            return;
        }

        public void MezclarBaraja()
        {
            Random random = new Random();
             cartas = cartas.OrderBy(_=> random.Next()).ToList();
        }





    }




        
    }


    

