using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveys_Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainMenu();
            Game game = new Game();
            MainMenu.DrawMainMenu();
            //game.Play();
        }
    }
}
