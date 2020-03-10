namespace Conveys_Game_of_Life
{
    public class Cell
    {
        public bool Alive { get; set; }
        public int LivingNeighbors { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Cell(bool alive, int xCoordinate, int yCoordinate)
        {
            this.Alive = alive;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public void GetLivingNeighborCells(Cell[,] cellMatrix)
        {
            this.LivingNeighbors = 0;

            for (int x = this.XCoordinate - 1; x <= this.XCoordinate + 1; x++)
            {
                for (int y = this.YCoordinate - 1; y <= this.YCoordinate + 1; y++)
                {
                    CheckNeighbors(x, y, cellMatrix);
                }
            }
        }


        private void CheckNeighbors(int x, int y, Cell[,] cellMatrix)
        {
            if (!(x == this.XCoordinate && y == this.YCoordinate))
            {
                if (!(x < 0 || y < 0 || x > cellMatrix.GetLength(0) - 1 || y > cellMatrix.GetLength(1) - 1))
                {
                    if (cellMatrix[x, y].Alive)
                    {
                        this.LivingNeighbors++;
                    }
                }
            }
        }
    }
}