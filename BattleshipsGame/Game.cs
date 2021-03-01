using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipsGame
{
    public class Game
    {
        ShipPlacingGrid shipPlacing = new ShipPlacingGrid();
        Grid grid = new Grid();
        int xCoord;
        int yCoord;
        int hitcount = 0;

        private void GameIntro()
        {
            Console.WriteLine("Welcome to my game of Battleships!" + "\n" + "Find all the ships to win!" + "\n"
                + "Hiding in the grid is:" + "\n" + "1 Battleship with a length of 5" + "\n" +"2 Destroyers with a length of 4" + "\n"
                + "Good Luck" + "\n");
        }

        private int GetX()
        {
            string[] ArrayOfLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            Console.WriteLine("Enter X co-ordinate: ");
            string XCoordasString = Console.ReadLine().ToUpper();
            xCoord = Array.IndexOf(ArrayOfLetters, XCoordasString);
            
            if (xCoord > 9 || xCoord < 0)
            {
                Console.WriteLine("Error, enter a letter between A and J!");
                GetX();
            }
            return xCoord;
        }

        private int GetY()
        {
            Console.WriteLine("Enter Y co-ordinate: ");
            string YCoord = Console.ReadLine();

            bool ValidateSuccess = int.TryParse(YCoord, out yCoord);

            if (ValidateSuccess == false)
            {
                Console.WriteLine("String could not be parsed.");
                GetY();
            }
            else if (yCoord > 9 || yCoord < 0)
            {
                Console.WriteLine("Error, enter a value between 0 and 9!");
                GetY();
            }
            return yCoord;
        }

        public void start_game()
        {
            GameIntro();
            shipPlacing.PlaceShip();
            grid.Print_Board();
            PlayerTurn();
        }

        private void PlayerTurn()
        {
            int TotalShipLengthToReach = shipPlacing.Ships[0].Length + shipPlacing.Ships[1].Length + shipPlacing.Ships[2].Length;

            while (hitcount < TotalShipLengthToReach)
            {
                AttackGrid();
            }
            EndGame();
        }

        public bool CheckIfShipHit(int xCoord, int yCoord)
        {
            if (shipPlacing.PlacingGrid[yCoord, xCoord] == 'O')
            {
                return false;
            }
            return true;
        }

        private void AttackGrid()
        {
            GetX();
            GetY();

            CheckIfShipHit(xCoord, yCoord);

            if (CheckIfShipHit(xCoord, yCoord) == false)
            {
                grid.Board[yCoord, xCoord] = 'X'; 
            }
            else if (shipPlacing.PlacingGrid[yCoord, xCoord] == shipPlacing.Ships[0].Symbol)
            {
                hitcount++;
                grid.Board[yCoord, xCoord] = shipPlacing.Ships[0].Symbol;
                shipPlacing.PlacingGrid[yCoord, xCoord] = '-';
                shipPlacing.Ships[0].hits++;
            }
            else if (shipPlacing.PlacingGrid[yCoord, xCoord] == shipPlacing.Ships[1].Symbol)
            {
                hitcount++;
                grid.Board[yCoord, xCoord] = shipPlacing.Ships[1].Symbol;
                shipPlacing.PlacingGrid[yCoord, xCoord] = '-';
                shipPlacing.Ships[1].hits++;
            }
            else if (shipPlacing.PlacingGrid[yCoord, xCoord] == shipPlacing.Ships[2].Symbol)
            {
                hitcount++;
                grid.Board[yCoord, xCoord] = shipPlacing.Ships[2].Symbol;
                shipPlacing.PlacingGrid[yCoord, xCoord] = '-';
                shipPlacing.Ships[2].hits++;
            }
            CheckForSunkShip();
            grid.Print_Board();
        }


        private void CheckForSunkShip()
        {
            foreach (var Ship in shipPlacing.Ships)
            {
                bool isSunk = Ship.isShipSunk(Ship.hits, Ship.Length);
                int x;
                int y;

                if (isSunk == true)
                {
                    Console.WriteLine($"You sank my {Ship.Name}");

                    for (x = 0; x < 10; x++)
                    {
                        for (y = 0; y < 10; y++)
                        {
                            if (grid.Board[y, x] == Ship.Symbol)
                            {
                                grid.Board[y, x] = 'S';
                            }
                        }
                    }
                }
            }
        }

        private void EndGame()
        {
            Console.WriteLine("\n" + "Congratulations, you hit all the ships!" + "\n" + "YOU WIN!");
            Console.ReadLine();
        }

    }
}
