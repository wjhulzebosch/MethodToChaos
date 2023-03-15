using MethodToChaos;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MethodToCHaos
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
        }

        public static int ExtractNumber(string input)
        {
            string pattern = @"\((\d+)\)";
            Match match = Regex.Match(input, pattern);
            int number = 0;
            if (match.Success)
            {
                string numberString = match.Groups[1].Value;
                number = int.Parse(numberString);
                Console.WriteLine(number);
            }
            
            return number;
        }
    }
}
