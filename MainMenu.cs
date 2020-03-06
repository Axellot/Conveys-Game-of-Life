using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveys_Game_of_Life
{
    public static class MainMenu
    {
        public static void DrawMainMenu()
        {
            Console.WriteLine("Welcome to Conway's Game of Life");
            Console.WriteLine("(1) Start Game, (2) End Program");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    StartProgram();
                    break;

                case "2":
                    EndProgram();
                    break;

                default:
                    break;
            }
        }

        public static void StartProgram()
        {
            int xCoordinate = 0;
            int yCoordinate = 0;

            Console.WriteLine("Geben sie die X-Koordinate der lebenden Zelle ein!");
            string xCoordinateInput = Console.ReadLine();
            while (true)
            {
                if(Int32.TryParse(xCoordinateInput, out xCoordinate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bitte geben sie eine gültige Zahl ein!");
                }
            }

            Console.WriteLine("Geben sie die Y-Koordinate der lebenden Zelle ein!");
            string yCoordinateInput = Console.ReadLine();
            while (true)
            {
                if(Int32.TryParse(yCoordinateInput, out yCoordinate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bitte geben sie eine gültige Zahl ein!");
                }
            }

            Cell cell = new Cell(true, xCoordinate, yCoordinate);
        }

        public static void EndProgram()
        {

        }
    }
}
