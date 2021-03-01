using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipsGame
{
    public class Grid
    {
        public char[,] Board = new char[10, 10]
        {
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'},
        {'O', 'O', 'O','O', 'O', 'O', 'O', 'O','O','O'}
        };

        public void Print_Board()
        {
            int x;
            int y;
            Console.WriteLine("A B C D E F G H I J |");
            Console.WriteLine("--------------------|");
            for (x = 0; x < 10; x++)
            {
                for (y = 0; y < 10; y++)
                {
                    Console.Write("{0} ", Board[x, y]);
                }
                Console.WriteLine("|" + x);
                Console.Write(Environment.NewLine);
            }
        }
    }

}

