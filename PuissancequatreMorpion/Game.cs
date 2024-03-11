using System;
using System.Security;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Game
    {
    
        public Game() {
            this.Context = new GameContext();
        }
        private List<Player> Players = new List<Player>();

        private GameContext Context;

        public void StartGame() {
            Console.WriteLine("Bienvenu dans la partie !");
            this.CreatePlayers();
            this.SelectGame();
            this.PlayGame();
        }

        private void CreatePlayers() {
            this.Players.Add(new Player("Jean", 'X'));
            this.Players.Add(new Player("Gérard", 'O'));
        }

        private void PlayGame() {
            int roundCount = 1;
            int playedCount = 0;
            bool gameStopped = false;
            do {
                ConsoleDisplay.WriteLine("Tour n° " + roundCount);
                for(int i = 0; i < this.Players.Count; i++) {
                    Position playedPosition = this.PlayRound(this.Players[i]);
                    if(this.Context.CheckWin(playedPosition)) {
                        ConsoleDisplay.WriteLine("Le joueur " + this.Players[i].GetName() + " a gagné !");
                        gameStopped = true;
                        break;
                    }
                    playedCount++;
                    if(this.IsEquality(playedCount)) {
                        ConsoleDisplay.WriteLine("Egalité ! La grille est pleine et aucun joueur n'a gagné !");
                        gameStopped = true;
                        break;
                    }
                }
                roundCount++;
            } while(!gameStopped);
        }

        private Position PlayRound(Player player) {
            ConsoleDisplay.WriteLine("C'est au tour de " + player.GetName() + "("+ player.GetSymbol() +")");
            return this.Context.PlaceToken(player.GetSymbol());
        }

        private bool IsEquality(int playedCount) {
            if(this.Context.IsMaxRoundReached(playedCount)) {
                return true;
            }
            return false;
        }

        private void SelectGame() {
            ConsoleKey key = this.AskGame();

            if(key == ConsoleKey.X) {
                this.Context.SetStrategy(new MorpionStrategy());
            } else if (key == ConsoleKey.P) {

            }

        }

        private ConsoleKey AskGame() {
            ConsoleKey res;
            do
            {
                ConsoleDisplay.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                res = Console.ReadKey(true).Key;
            } while (res != ConsoleKey.X && res != ConsoleKey.P);
            return res;
        }
    }
}
