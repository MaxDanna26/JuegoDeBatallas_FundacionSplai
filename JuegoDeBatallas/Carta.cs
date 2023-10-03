using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Carta
    {

        public List<Carta> Cartas { get => Cartas; set => Cartas = value; }

        private int numero;
        public int Numero
        {
            get => numero;
        }      
        
        private string palo;

        public Carta(int numero,string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }

        public Carta() { }

        public string Descripcion 
        { 
            get => $"{numero} de {palo}.";
        }

 



    }
}
