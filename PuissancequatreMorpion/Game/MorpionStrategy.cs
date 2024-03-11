using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    /// <summary>
    /// 
    /// </summary>
    public class MorpionStrategy : IGameStrategy
    {
        public Position PlaceToken(char symbol) {
            return new Position(3, 4);
        }

        public bool CheckWin(Position lastPlayPosition) {
            return false;
        }

        public bool CanPlaceToken(int line, int column) {
            return false;
        }

        public bool IsMaxRoundReached(int playedCount) {
            return false;
        }
    }
}
