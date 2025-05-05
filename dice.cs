using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceApp
{
    class Dice
    {
        private int ladoSorteado = 1;

        public int LadoSorteado { get => ladoSorteado; set => ladoSorteado = value; }

        public Dice() { }

        public int Roll()
        {
            Random sortear = new Random();
            LadoSorteado = sortear.Next(1, 7); // de 1 a 6
            return LadoSorteado;
        }
    }
}
