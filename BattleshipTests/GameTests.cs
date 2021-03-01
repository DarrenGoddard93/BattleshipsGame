using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipsGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipTests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void CheckIfShipHitTest()
        {
            Game gametest = new Game();
            int xCoord = 1;
            int yCoord = 1;
            bool expected = true;
            bool isAvailable;

            ShipPlacingGrid shipPlacing = new ShipPlacingGrid();
            shipPlacing.PlacingGrid[yCoord, xCoord] = 'O';

            if (gametest.CheckIfShipHit(yCoord, xCoord))
            {
                isAvailable = true;
                Assert.AreEqual(expected, isAvailable);
            }
        }
    }
}