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
        public void Play()
        {
            this.FillMatrix();
            List<KeyValuePair<int, int>> coordinatesList = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(0,1),
                new KeyValuePair<int, int>(4,5),
                new KeyValuePair<int, int>(4,6),
                new KeyValuePair<int, int>(4,7)
            };
            this.SetLivingCells(coordinatesList);

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                DrawGameField();
                foreach (Cell cell in CellMatrix)
                {
                    cell.GetLivingNeighborCells(this.CellMatrix);
                }
                Console.ReadKey();
            }
        }

        public void FillMatrix()
        {
            int length = CellMatrix.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    this.CellMatrix[x,y] = new Cell(false, x, y);
                }
            }
        }

        public void SetLivingCells(List<KeyValuePair<int,int>> coordinateList)
        {
            foreach(KeyValuePair<int,int> coordinate in coordinateList)
            {
                CellMatrix[coordinate.Key, coordinate.Value].Alive = true;
            }
        }

        public void DrawGameField()
        {
            int counter = 0;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t\t");
            foreach (Cell cell in CellMatrix)
            {
                
                if (cell.Alive)
                {
                    this.DrawLivingCell();
                }
                else
                {
                    this.DrawDeadCell();
                }
                counter++;
                if(counter % 15 == 0)
                {
                    Console.Write("\n\t\t");
                }
            }
        }

        private void DrawLivingCell()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" O ");
            Console.ResetColor();
        }

        private void DrawDeadCell()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" O ");
            Console.ResetColor();
        }
    }
}
