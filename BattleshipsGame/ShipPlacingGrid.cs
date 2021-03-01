using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipsGame
{
    public class ShipPlacingGrid
    {
        int x;
        int y;
        Random randomnumber = new Random();

        public List<Ship> Ships = new List<Ship>
        {
            new Ship("Battleship", 5, 'B'),
            new Ship("Destroyer", 4, 'D'),
            new Ship("Destroyer2", 4, 'd')
        };

        public char[,] PlacingGrid = new char[10, 10]
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

        private int get_random_row()
        {
            int randomX = randomnumber.Next(0, 10);
            return randomX;
        }

        private int get_random_col()
        {
            int randomY = randomnumber.Next(0, 10);
            return randomY;
        }

        private int get_random_direction()
        {
            int random_direction = randomnumber.Next(0, 2);
            return random_direction;
        }

        public bool CanPlaceShipInBoundaries(int direction, int X, int Y)
        {
            foreach (var Ship in Ships)
            {
                if (direction == 0)
                {
                    if (X + Ship.Length > 10)
                    {
                        return false; 
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (Y + Ship.Length > 10)
                    {
                        return false; 
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckIfSpaceTaken(int direction, int XCoord, int YCoord)
        {
            foreach (var Ship in Ships)
            {
                if (direction == 0)
                {
                    for (x = XCoord; x < XCoord + Ship.Length; x++)
                    {
                        if (PlacingGrid[YCoord, x] == Ship.Symbol)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (y = YCoord; y < YCoord + Ship.Length; y++)
                    {
                        if (PlacingGrid[y, XCoord] == Ship.Symbol)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceShip()
        {
            foreach (var Ship in Ships)
            {
                bool canPlace = false;
                while (canPlace == false)
                {
                    int XCord = get_random_row();
                    int YCord = get_random_col();
                    int direction = get_random_direction();

                    if (CanPlaceShipInBoundaries(direction, XCord, YCord) == false || CheckIfSpaceTaken(direction, XCord, YCord) == false)
                    {
                        canPlace = false;
                        continue;
                    }
                    else
                    {
                        if (direction == 0)
                        {
                            for (x = XCord; x < XCord + Ship.Length; x++)
                            {
                                PlacingGrid[YCord, x] = Ship.Symbol;
                            }
                        }
                        else
                        {
                            for (y = YCord; y < YCord + Ship.Length; y++)
                            {
                                PlacingGrid[y, XCord] = Ship.Symbol;
                            }
                        }
                    }
                    canPlace = true;
                }
            }
        }
    }

}

