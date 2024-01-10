using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedConsoleGame
{
    internal class Room
    {
        public int Doors { get; set; }
        public bool Torch { get; set; }

        public Room()
        {
            Random leftOrRightDoor = new Random();
            Random torchOrNot = new Random();

            Torch = torchOrNot.Next(2) == 0;
            Doors = leftOrRightDoor.Next(1, 3);
        }
    }
}
