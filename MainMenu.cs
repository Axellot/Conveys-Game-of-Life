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
            List<KeyValuePair<int, int>> coordinatesList = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(23,24),
                new KeyValuePair<int, int>(23,23),
                new KeyValuePair<int, int>(23,22),
                new KeyValuePair<int, int>(24,22),
                new KeyValuePair<int, int>(25,22),
                new KeyValuePair<int, int>(25,23),
                new KeyValuePair<int, int>(25,24),
                new KeyValuePair<int, int>(23,26),
                new KeyValuePair<int, int>(23,27),
                new KeyValuePair<int, int>(23,28),
                new KeyValuePair<int, int>(24,28),
                new KeyValuePair<int, int>(25,28),
                new KeyValuePair<int, int>(25,27),
                new KeyValuePair<int, int>(25,26)
            };

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
                        int fieldSize = 0;
                        List<KeyValuePair<int, int>> userCells = new List<KeyValuePair<int, int>>();
                        bool gameMode = GetGameMode();
                        if (gameMode)
                        {
                            fieldSize = GetGamefieldLength();
                            userCells = StartProgram(fieldSize);
                        }
                        else
                        {
                            fieldSize = 50;
                            userCells = coordinatesList;
                        }
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

        public static bool GetGameMode()
        {
            while (true)
            {
                Console.WriteLine("Choose which game mode you want to start");
                Console.WriteLine("(1) Manual input, (2) Default field");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        return true;
                    case "2":
                        return false;
                    default:
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
