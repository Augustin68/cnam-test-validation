using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class ConsoleDisplay
    {
        public static void WriteLine(string text) {
            Console.Clear();
            Console.WriteLine(text);
        }
    }
}
