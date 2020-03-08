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
            Game game = new Game();
            bool mainMenuBool = true;
            while (mainMenuBool)
            {
                Console.WriteLine("Welcome to Conway's Game of Life");
                Console.WriteLine("(1) Start Game, (2) End Program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        List<KeyValuePair<int, int>> userCells = StartProgram();
                        game.Play(userCells);
                        break;

                    case "2":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Command not accepted");
                        break;
                }
            }
        }

        public static List<KeyValuePair<int, int>> StartProgram()
        {
            List<KeyValuePair<int, int>> userLivingCells = new List<KeyValuePair<int, int>>();
            bool createCellsBool = true;
            do
            {
                int xCoordinate = 0;
                int yCoordinate = 0;

                xCoordinate = AskForCoordinates("x");
                yCoordinate = AskForCoordinates("y");

                KeyValuePair<int, int> cell = new KeyValuePair<int, int>(xCoordinate, yCoordinate);
                userLivingCells.Add(cell);

                AskForNewCell(ref createCellsBool);
            } while (createCellsBool);
            return userLivingCells;
        }

        public static int AskForCoordinates(string coordinateType)
        {
            while (true)
            {
                Console.WriteLine($"Please enter the {coordinateType}-Coordinate of the living cell!");
                string CoordinateInput = Console.ReadLine();
                if (Int32.TryParse(CoordinateInput, out int Coordinate))
                {
                    return Coordinate;
                }
                else
                {
                    Console.WriteLine("Please use only valid numbers!");
                }
            }
        }

        public static void AskForNewCell(ref bool createCellsBool)
        {
            bool userInputBool = true;
            while (userInputBool)
            {
                Console.WriteLine("Would you like to create another living cell?");
                Console.WriteLine("(1) Yes, (2) Start Game");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        userInputBool = false;
                        break;
                    case "2":
                        Console.Clear();
                        userInputBool = false;
                        createCellsBool = false;
                        break;
                    default:
                        Console.WriteLine("Command not accepted");
                        break;

                }
            }
        }
    }
}
