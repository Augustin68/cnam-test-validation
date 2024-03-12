using Xunit;
using MorpionApp;

namespace PuissancequatreMorpionTest;

public class PlayerTests
{
     [Fact]
        public void GetName_ReturnsCorrectName()
        {
            // Arrange
            string name = "John";
            char symbol = 'X';
            Player player = new Player(name, symbol);

            // Act
            string actualName = player.GetName();

            // Assert
            Assert.Equal(name, actualName);
        }

        [Fact]
        public void GetSymbol_ReturnsCorrectSymbol()
        {
            // Arrange
            string name = "John";
            char symbol = 'X';
            Player player = new Player(name, symbol);

            // Act
            char actualSymbol = player.GetSymbol();

            // Assert
            Assert.Equal(symbol, actualSymbol);
        }
}