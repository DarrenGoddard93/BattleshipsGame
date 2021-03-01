using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipsGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipTests
{
    [TestClass()]
    public class ShipTests
    {
        Ship myShip = new Ship("Test", 5, 'T');

        [TestMethod()]
        public void CreateShipObjectTest()
        {
            Assert.IsInstanceOfType(myShip, typeof(Ship));
        }

        [TestMethod()]
        public void isShipSunkTest()
        {
            int hits = 5;
            int length = myShip.Length;

            bool ResultShipIsSunk = myShip.isShipSunk(hits, length);

            Assert.IsTrue(ResultShipIsSunk);

        }

        [TestMethod()]
        public void isShipNotSunkTest()
        {
            int hits = 4;
            int length = myShip.Length;

            bool ResultShipIsSunk = myShip.isShipSunk(hits, length);

            Assert.IsFalse(ResultShipIsSunk);
        }


    }
}
