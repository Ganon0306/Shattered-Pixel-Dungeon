using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shattered_Pixel_Dungeon
{
    internal class MapDrow
    {
        public int yPos;
        public int xPos;

        public int yPlayer = 10;
        public int xPlayer = 10;

        static Random rnd = new Random();

        static List<(int, int)> RandomRoom = new List<(int, int)>();

        public void Initialize(int xPos_, int yPos_)
        {
            xPos = xPos_;
            yPos = yPos_;            
        }

        public void Drow_Map()
        {
            char[,] map = new char[xPos + 2, yPos + 2];
            for (int i = 0; i < xPos + 2; i++)
            {
                for (int j = 0; j < yPos + 2; j++)
                {
                    if (i == 0 || i == xPos + 1 || j == 0 || j == yPos + 1) //테두리 좌표
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("■");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (i == xPlayer && j == yPlayer) // 플레이어 위치
                        {
                            Console.Write("★"); // 플레이어 표시
                        }
                        else
                        {
                            Console.Write("  "); // 맵 빈곳에는 공백 두칸
                        }
                    }
                }                
                Console.WriteLine();
            }

            foreach ((int posX, int posY) in RandomRoom)
            {
                int startX = 3;     //맵 중심
                int startY = 3;

                while (startX != posX || startY != posY)    //맵 중심으로 이동
                {
                    if (startX < posX)
                    {
                        startX++;
                    }
                    else if (startX > posX)
                    {
                        startX--;
                    }
                    else if (startY < posY)
                    {
                        startY++;
                    }
                    else if (startY > posY)
                    {
                        startY--;
                    }

                    map[startX, startY] = '□';      //이동한 경로에 타일
                    map[3, 3] = '□';    //맵 중심은 무조건 타일
                    map[xPlayer, yPlayer] = '★';
                }
            }
            for (int i = 0; i < 5 + 2; i++)
            {
                for (int j = 0; j < 5 + 2; j++)
                {
                    Console.Write("{0} ", map[i, j]);
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            char move = KeyInfo.KeyChar;

            if (move == 'a')
            {
                if (yPlayer > 1 && map[xPlayer, yPlayer - 1] != '■')
                {
                    yPlayer -= 1;
                }
            }
            else if (move == 'd')
            {
                if (yPlayer < yPos && map[xPlayer, yPlayer + 1] != '■')
                {
                    yPlayer += 1;
                }
            }
            else if (move == 'w')
            {
                if (xPlayer > 1 && map[xPlayer - 1, yPlayer] != '■')
                {
                    xPlayer -= 1;
                }
            }
            else if (move == 's')
            {
                if (xPlayer < xPos && map[xPlayer + 1, yPlayer] != '■')
                {
                    xPlayer += 1;
                }
            }
            Console.Clear();
        }

        public void MakeMap()
        {
            while (RandomRoom.Count < xPos)
            {
                int x = rnd.Next(1, xPos);
                int y = rnd.Next(1, yPos);

                if (!RandomRoom.Contains((x, y)))       //RanmdomRoom 리스트에 지금 포함할게 없으면 실행
                {
                    RandomRoom.Add((x, y));
                }
            }
        }




    }    
}
