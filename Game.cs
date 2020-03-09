using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Conveys_Game_of_Life
{
    public class Game
    {
        public bool isRunning { get; set; } = true;
        public Cell[,] CellMatrix { get; set; }
        public StringBuilder outputString = new StringBuilder();

        public Game(int userLength)
        {
            CellMatrix = new Cell[userLength, userLength];
        }

        public void Play(List<KeyValuePair<int, int>> userCells)
        {
            this.FillMatrix();
            this.SetLivingCells(userCells);
            Thread inputThread = new Thread(new ThreadStart(InputListener));
            inputThread.Start();
            while (this.isRunning)
            {
                Console.CursorVisible = false;
                Console.Clear();
                DrawGameField();
                foreach (Cell cell in CellMatrix)
                {
                    cell.GetLivingNeighborCells(this.CellMatrix);
                }
                Rules.ApplyRules(this.CellMatrix);

                Thread.Sleep(250);
            }
            inputThread.Abort();
        }

        public void InputListener()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    this.isRunning = false;
                }
            }
        }

        public void FillMatrix()
        {
            int length = CellMatrix.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    this.CellMatrix[x, y] = new Cell(false, x, y);
                }
            }
        }

        public void SetLivingCells(List<KeyValuePair<int, int>> coordinateList)
        {
            foreach (KeyValuePair<int, int> coordinate in coordinateList)
            {
                CellMatrix[coordinate.Key, coordinate.Value].Alive = true;
            }
        }

        public void DrawGameField()
        {
            outputString.Clear();
            int LineCounter = 0;
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
                LineCounter++;
                if (LineCounter % this.CellMatrix.GetLength(0) == 0)
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