using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveys_Game_of_Life
{
    public class Game
    {
        public Cell[,] CellMatrix { get; set; } = new Cell[15, 15];

        /// <summary>
        /// Fills the initial matrix with dead cells
        /// </summary>
        public void FillMatrix()
        {
            for(int i = 0; i < CellMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < CellMatrix.GetLength(1); i++)
                {
                    this.CellMatrix[j,i] = new Cell(false);
                }
            }
        }



    }
}
