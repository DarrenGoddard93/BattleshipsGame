using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipsGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipTests
{
    [TestClass()]
    public class ShipPlacingTests
    {
        Ship myShip = new Ship("Test", 2, 'T');
        ShipPlacingGrid PlacingGrid = new ShipPlacingGrid();

        [TestMethod()]
        public void PlacingShipWillFitOnGrid()
        {
            int direction = 0;
            int x = 2;
            int y = 2;

            bool ShipWillFitOnGrid = PlacingGrid.CanPlaceShipInBoundaries(direction, x, y);

            if (x + myShip.Length > 10)
            {
                Assert.IsFalse(ShipWillFitOnGrid);
            }

        }
    }
}
