using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGOL
{
    [TestClass]
    private class TestGame
    {
        [TestMethod]
        private void TestRules()
        {
            Game game = new Game();
            game.FillMatrix();
            Debug.Assert(game.CellMatrix.Length, 225);
        }
    }
}
