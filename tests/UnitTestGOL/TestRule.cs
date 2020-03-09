using Conveys_Game_of_Life;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestGOL
{
    [TestClass]
    public class TestRule
    {
        [TestMethod]
        public void TestDeadCellRule()
        {
            Cell cell = new Cell(false, 0, 0);

            cell.LivingNeighbors = 3;
            Rules.DeadCellRule(cell);

            Debug.Assert(cell.Alive == true);
        }

        [TestMethod]
        public void TestLivingCellRule()
        {
            Cell cell = new Cell(true, 1, 1);

            cell.LivingNeighbors = 4;
            Rules.LivingCellRule(cell);

            Debug.Assert(cell.Alive == false);
        }
    }
}