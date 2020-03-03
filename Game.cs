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

        
        public void FillMatrix()
        {
            int length = CellMatrix.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    this.CellMatrix[x,y] = new Cell(false);
                }
            }
        }

        public void Play()
        {
            bool isRunning = true;

            this.FillMatrix();
            //this.SetLivingCells();
            while (isRunning)
            {

            }
        }

        public void SetLivingCells(List<KeyValuePair<int,int>> coordinateList)
        {
            foreach(KeyValuePair<int,int> coordinate in coordinateList)
            {
                CellMatrix[coordinate.Key, coordinate.Value].Alive = true;
            }
        }

    }
}
