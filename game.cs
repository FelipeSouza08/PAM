using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceApp
{
    public class Game
    {
        private int playerPoint;
        private int streak;

        public int PlayerPoint { get => playerPoint; set => playerPoint = value; }
        public int Streak { get => streak; set => streak = value; }

        public Game() { }

        public Boolean CheckWinner(int escolhido, int sorteado)
        {
            if (escolhido == sorteado)
            {
                PlayerPoint++;
                Streak++;
                return true;
            }
            else
            {
                Streak = 0;
                return false;
            }
        }
    }
}
