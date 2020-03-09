using Conveys_Game_of_Life;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestGOL
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestFillMatrix()
        {
            Game game = new Game(15);
            game.FillMatrix();

            Debug.Assert(game.CellMatrix.Length == 225);
        }

        [TestMethod]
        public void TestSetLivingCells()
        {
            List<KeyValuePair<int, int>> coordinates = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(4,5),
                new KeyValuePair<int, int>(4,6),
                new KeyValuePair<int, int>(4,7)
            };

            Game game = new Game(15);
            game.FillMatrix();
            game.SetLivingCells(coordinates);

            int counter = 0;
            foreach (var x in game.CellMatrix)
            {
                if (x.Alive)
                {
                    counter++;
                }
            }

            Debug.Assert(counter == 3);
        }
    }
}