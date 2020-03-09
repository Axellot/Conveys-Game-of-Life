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
            bool mainMenuBool = true;
            while (mainMenuBool)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Conway's Game of Life");
                Console.WriteLine("(1) Start Game, (2) End Program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        int fieldSize = GetGamefieldLength();
                        List<KeyValuePair<int, int>> userCells = StartProgram(fieldSize);
                        Game game = new Game(fieldSize);
                        game.Play(userCells);
                        break;

                    case "2":
                        mainMenuBool = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Command not accepted");
                        break;
                }
            }
        }

        public static List<KeyValuePair<int, int>> StartProgram(int fieldSize)
        {
            List<KeyValuePair<int, int>> userLivingCells = new List<KeyValuePair<int, int>>();
            bool createCellsBool = true;
            do
            {
                KeyValuePair<int, int> cell = new KeyValuePair<int, int>(AskForCoordinates("x", fieldSize), AskForCoordinates("y", fieldSize));
                userLivingCells.Add(cell);

                AskForNewCell(ref createCellsBool);
            } while (createCellsBool);
            return userLivingCells;
        }

        public static int GetGamefieldLength()
        {
            while (true)
            {
                Console.WriteLine("Please insert the size of the gamefield (between 10 and 50)!");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out int fieldSize) && fieldSize < 51 && fieldSize > 9)
                {
                    return fieldSize;
                }
                else
                {
                    Console.WriteLine("Please only user numbers between 10 and 50!");
                }
            }
        }

        public static int AskForCoordinates(string coordinateType, int fieldSize)
        {
            while (true)
            {
                Console.WriteLine($"Please enter the {coordinateType}-Coordinate of the living cell!");
                string CoordinateInput = Console.ReadLine();
                if (Int32.TryParse(CoordinateInput, out int coordinate) && coordinate < fieldSize && coordinate >= 0)
                {
                    return coordinate;
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
