using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipsGame
{
    public class Ship
    {
        public string Name;
        public int Length;
        public char Symbol;
        public int hits;

        public Ship(string name, int length, char symbol)
        {
            Name = name;
            Length = length;
            Symbol = symbol;
        }

        public bool isShipSunk(int hits, int Length)
        {
            if (hits == Length)
            {
                return true;
            }
            return false;
        }
    }
}
