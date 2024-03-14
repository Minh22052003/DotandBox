using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Player
    {
        public Player() { }
        public string Name { get; private set; }
        public bool Turn { get; private set; }=false;
        public void setTurn(bool turn)
        {
            Turn = turn;
        }
        public int Score { get; private set; }
        public void setScore(int score)
        {
            Score += score;
        }

        public int timeEnd { get; private set; } = 300;
        public void setTimeEnd(int time)
        {
            timeEnd = time;
        }

    }
}
