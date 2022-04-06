using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoToucanGame
{
    public class Player
    {
        int score;
        string name; 

        public int Score { get { return score; } set { score = value; } }
        public string Name { get { return name; } }

        public Player(string name)
        {
            this.name = name;
        }
    }
}
