﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MethodToChaos
{
    internal class Game
    {
        public static Game CurrentGame;
        public Level Level;
        public Game()
        {
            // Set up a static reference to this game
            CurrentGame = this;


            // Set up level
            Level = new Level();
            Level.ShowLevel();

            // Set up player
            Player player = new Player();

            while (player.Left != Level.GetExitPosition().Left && player.Top != Level.GetExitPosition().Top)
            {
                // The player isn't at the exit.
                // Ask for a new input.
                string userInput = Console.ReadLine();
                if(ValidateInput(userInput))
                {
                    // Check if the user wants to move up
                    if (userInput.StartsWith("MoveUp"))
                    {
                        player.MoveUp(GetNumberOfSteps(userInput));
                    }
                    // Check if the user wants to move down
                    else if (userInput.StartsWith("MoveDown"))
                    {
                        player.MoveDown(GetNumberOfSteps(userInput));
                    }
                    // Check if the user wants to move left
                    else if (userInput.StartsWith("MoveLeft"))
                    {
                        player.MoveLeft(GetNumberOfSteps(userInput));
                    }
                    // Check if the user wants to move right
                    else if (userInput.StartsWith("MoveRight"))
                    {
                        player.MoveRight(GetNumberOfSteps(userInput));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Valid inputs can be: MoveUp(2);, MoveDown(7);, MoveLeft(4);, MoveRight(1);");
                }
            }
        }

        public int GetNumberOfSteps(string input)
        {
            string pattern = @"\((\d+)\)";

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string numberString = match.Groups[1].Value;
                int number = int.Parse(numberString);
                return number;
            }
            return 0;
        }

        public bool ValidateInput(string inputString)
        {
            Regex regex = new Regex(@"^Move(Up|Down|Left|Right)\(\d+\);$");
            return regex.IsMatch(inputString);
        }
    }
}
