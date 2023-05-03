using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_01_Linq
{
    public class Room
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }


       public List<Room> GetRoom()
        {
            return new List<Room>()
              {
                  new Room {Length = 50 , Height = 3, Width = 10 },
                  new Room {Length = 25 , Height = 4, Width = 15 },
                  new Room {Length = 95 , Height = 5, Width = 20 },
                  new Room {Length = 30 , Height = 7, Width = 40 },
                  new Room {Length = 10 , Height = 3, Width = 90 },
                  new Room {Length = 5  , Height = 2, Width = 30 }
              };

        }

       
    }
}
