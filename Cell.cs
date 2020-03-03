using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveys_Game_of_Life
{
    public class Cell
    {
        public bool Alive { get; set; }

        public Cell(bool alive)
        {
            this.Alive = alive;
        }


    }
}
