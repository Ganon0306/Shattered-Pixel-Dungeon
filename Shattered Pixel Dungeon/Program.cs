using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shattered_Pixel_Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MapDrow mapDrow = new MapDrow();
            mapDrow.Initialize(20, 20);

            while (true)
            {

                mapDrow.Drow_Map();

            }
        }
    }
}
