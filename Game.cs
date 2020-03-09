using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conveys_Game_of_Life
{
    public class Game
    {
        public Cell[,] CellMatrix { get; set; }
        public StringBuilder outputString = new StringBuilder();

        public Game(int userLength)
        {
            CellMatrix = new Cell[userLength, userLength];
        }

        public void Play(List<KeyValuePair<int, int>> userCells)
        {
            this.FillMatrix();
            List<KeyValuePair<int, int>> coordinatesList = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(13,14),
                new KeyValuePair<int, int>(13,13),
                new KeyValuePair<int, int>(13,12),
                new KeyValuePair<int, int>(14,12),
                new KeyValuePair<int, int>(15,12),
                new KeyValuePair<int, int>(15,13),
                new KeyValuePair<int, int>(15,14),
                new KeyValuePair<int, int>(13,16),
                new KeyValuePair<int, int>(13,17),
                new KeyValuePair<int, int>(13,18),
                new KeyValuePair<int, int>(14,18),
                new KeyValuePair<int, int>(15,18),
                new KeyValuePair<int, int>(15,17),
                new KeyValuePair<int, int>(15,16)
            };

            userCells = coordinatesList;

            this.SetLivingCells(userCells);

            bool isRunning = true;
            while (isRunning)
            {
                Console.CursorVisible = false;
                Console.Clear();
                DrawGameField();
                foreach (Cell cell in CellMatrix)
                {
                    cell.GetLivingNeighborCells(this.CellMatrix);
                }
                Rules.ApplyRules(this.CellMatrix);
                Thread.Sleep(500);
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
            outputString.Clear();
            int counter = 0;
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
                if(counter % this.CellMatrix.GetLength(0) == 0)
                {
                    outputString.Append("\n");
                }
            }
            Console.WriteLine(outputString.ToString());
        }

        private void DrawLivingCell()
        {
            outputString.Append(" O ");
        }

        private void DrawDeadCell()
        {
            outputString.Append("   ");
        }
    }
}
