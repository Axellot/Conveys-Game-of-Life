namespace Conveys_Game_of_Life
{
    public static class Rules
    {
        public static void ApplyRules(Cell[,] cellMatrix)
        {
            foreach (Cell cell in cellMatrix)
            {
                if (cell.Alive)
                {
                    LivingCellRule(cell);
                }
                else
                {
                    DeadCellRule(cell);
                }
            }
        }

        public static void DeadCellRule(Cell cell)
        {
            if (cell.LivingNeighbors == 3)
            {
                cell.Alive = true;
            }
        }

        public static void LivingCellRule(Cell cell)
        {
            if (cell.LivingNeighbors > 1 && cell.LivingNeighbors < 4)
            {
                cell.Alive = true;
            }
            else
            {
                cell.Alive = false;
            }
        }
    }
}