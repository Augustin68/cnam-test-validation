using System;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class GameContext
    {
        private IGameStrategy strategy;

        public GameContext() {}

        public GameContext(IGameStrategy strategy) {
            this.strategy = strategy;
        }

        public void SetStrategy(IGameStrategy strategy) {
            this.strategy = strategy;
        }

        public Position PlaceToken(char symbol) {
            return this.strategy.PlaceToken(symbol);
        }

        public bool CheckWin(Position lastPlayedPosition) {
            return this.strategy.CheckWin(lastPlayedPosition);
        }

        public bool IsMaxRoundReached(int roundCount) {
            return this.strategy.IsMaxRoundReached(roundCount);
        }


    }
}
