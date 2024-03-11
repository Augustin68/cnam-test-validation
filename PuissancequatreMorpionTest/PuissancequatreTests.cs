using System.Collections.Generic;
using Xunit;
using MorpionApp;

namespace PuissancequatreMorpionTest;

public class PuissancequatreTests
{
    public static IEnumerable<object[]> WinningConditionsData =>
        new List<object[]>
        {
            new object[] { new char[4, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', 'X', 'X', 'X', ' ', ' ', ' '},
            }, 'X' },
            // Add more winning conditions here...
        };

    public static IEnumerable<object[]> FullBoardData =>
        new List<object[]>
        {
            new object[] { new char[4, 7]
            {
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O'},
                { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                { 'O', 'X', 'O', 'X', 'O', 'X', 'O'},
            } }
            // Add more full board scenarios here...
        };

        [Theory]
        [MemberData(nameof(WinningConditionsData))]
        public void VerifVictoire_ShouldReturnTrue_WhenWinningConditionMet(char[,] grid, char player)
        {
            // Arrange
            var puissanceQuatre = new PuissanceQuatre();
            puissanceQuatre.grille = grid;

            // Act
            bool result = puissanceQuatre.verifVictoire(player);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(FullBoardData))]
        public void VerifEgalite_ShouldReturnTrue_WhenBoardIsFull(char[,] grid)
        {
            // Arrange
            var puissanceQuatre = new PuissanceQuatre();
            puissanceQuatre.grille = grid;

            // Act
            bool result = puissanceQuatre.verifEgalite();

            // Assert
            Assert.True(result);
        }
}