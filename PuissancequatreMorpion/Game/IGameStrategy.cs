using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    public interface IGameStrategy
    {
        public Position PlaceToken(char symbol);
        public bool CheckWin(Position lastPlayPosition);
        public bool CanPlaceToken(int line, int column);
        public bool IsMaxRoundReached(int roundCount);
    }
}
