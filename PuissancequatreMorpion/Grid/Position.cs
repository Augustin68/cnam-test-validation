using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    public struct Position
    {
        public Position(int line, int column) {
            this.Line = line;
            this.Column = column;
        }
        public int Line;
        public int Column;
    }
}
