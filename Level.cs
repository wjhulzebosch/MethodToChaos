using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodToChaos
{
    internal class Level
    {
        public char[,] LevelArray;
        int height = 11;
        int width = 36;
        public Level()
        {
            string levelString =
                "=S======.===========================/" +
                "=.======.=====..............========/" +
                "=...........==.============.========/" +
                "==========.===.============.========/" +
                "==========.===.============.========/" +
                "==========.===.============.========/" +
                "==========.===.============.========/" +
                "==========.....============.========/" +
                "===========================.========/" +
                "===========================.......==/" +
                "=================================F==/";

            // Create a 2D char array
            LevelArray = new char[height, width];

            // Loop trough levelString, put each char in a cell of LevelArray
            int left = 0;
            int top = 0;
            foreach (char c in levelString)
            {
                if (c == '/')
                {
                    left = 0;
                    top++;
                }
                else
                {
                    LevelArray[top, left] = c;
                    left++;
                }
            }
        }
        
        public void ShowLevel()
        {
            // Clear screen
            Console.Clear();

            // Show the level on screen
            for (int top = 0; top < height; top++)
            {
                for (int left = 0; left < width; left++)
                {
                    Console.Write(LevelArray[top, left]);
                }
                Console.WriteLine();
            }
        }

        public Position GetStartPosition()
        {
            {
                // Loop trough LevelArray, find the start position
                for (int left = 0; left < 36; left++)
                {
                    for (int top = 0; top < 11; top++)
                    {
                        if (LevelArray[top, left] == 'S')
                        {
                            return new Position() { Left = left, Top = top };
                        }
                    }
                }
                return null;
            }
        }

        public Position GetExitPosition()
        {
            {
                // Loop trough LevelArray, find the exit position
                for (int left = 0; left < width; left++)
                {
                    for (int top = 0; top < height; top++)
                    {
                        if (LevelArray[top, left] == 'F')
                        {
                            return new Position() { Left = left, Top = top };
                        }
                    }
                }
                return null;
            }
        }
    }
}
