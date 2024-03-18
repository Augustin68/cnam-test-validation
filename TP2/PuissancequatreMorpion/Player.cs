using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Player
    {
        string Name;
        char Symbol;
        public Player(string name, char symbol) {
            this.Name = name;
            this.Symbol = symbol;
        }
        public string GetName() {
            return this.Name;
        }
        public char GetSymbol() {
            return this.Symbol;
        }
    }
}
