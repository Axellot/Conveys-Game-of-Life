using System;
using Conveys_Game_of_Life;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGOL
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestFillMatrix()
        {
            Game game = new Game();
            game.FillMatrix();
            
            Debug.Assert(game.CellMatrix.Length == 225);
        }
    }
}
