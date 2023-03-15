using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodToChaos
{
    internal class Player
    {
        public int Top;
        public int Left;

        public Player()
        {
            Top = Game.CurrentGame.Level.GetStartPosition().Top;
            Left = Game.CurrentGame.Level.GetStartPosition().Left;

            // Print position on screen
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Position: " + Left + ", " + Top);

        }

        internal void MoveDown(int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                if(!TryMove(1, 0))
                {
                    Console.WriteLine("Can't move down.");
                    break;
                }
            }
        }

        internal void MoveLeft(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (!TryMove(0, -1))
                {
                    Console.WriteLine("Can't move to the left.");
                    break;
                }
            }
        }

        internal void MoveRight(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (!TryMove(0, 1))
                {
                    Console.WriteLine("Can't move to the right.");
                    break;
                }
            }
        }

        internal void MoveUp(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (!TryMove(-1, 0))
                {
                    Console.WriteLine("Can't move up.");
                    break;
                }
            }
        }

        public bool TryMove(int top, int left)
        {
            // Check if new position is >= 0 and < window width
            if (Top + top < 0 || Top + top >= Console.WindowHeight)
            {
                return false;
            }

            if (Left + left < 0 || Left + left >= Console.WindowWidth)
            {
                return false;
            }

            // Check in level if new position is a .
            if (Game.CurrentGame.Level.LevelArray[Top + top, Left + left] == '.')
            {
                // Move cursor to current position
                Console.SetCursorPosition(Left, Top);
                Console.Write('.');
                
                // Move player
                Top += top;
                Left += left;

                Game.CurrentGame.Level.ShowLevel();

                // Move cursor to new position
                Console.SetCursorPosition(Left, Top);
                Console.Write('X');

                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Current Position: " + Top + ", " + Left);

                return true;
            }
            return false;
        }
    }
}
