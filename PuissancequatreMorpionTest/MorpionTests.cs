using Xunit;
using MorpionApp;

namespace PuissancequatreMorpionTest;

public class MorpionTests
{
    [Fact]
    public void VerifVictoire_ReturnsTrue_WhenHorizontalLineIsComplete()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { 'X', 'X', 'X' },
            { 'O', 'O', 'O' },
            { 'O', 'O', 'O' }
        };

        // Act
        bool result = morpion.verifVictoire('X');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifVictoire_ReturnsTrue_WhenVerticalLineIsComplete()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { 'O', ' ', ' ' },
            { 'O', ' ', ' ' },
            { 'O', ' ', ' ' }
        };

        // Act
        bool result = morpion.verifVictoire('O');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifVictoire_ReturnsTrue_WhenDiagonalLineIsComplete()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { ' ', ' ', 'X' },
            { ' ', 'X', ' ' },
            { 'X', ' ', ' ' }
        };

        // Act
        bool result = morpion.verifVictoire('X');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void VerifVictoire_ReturnsFalse_WhenNoVictoryCondition()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { 'X', 'O', 'X' },
            { ' ', ' ', ' ' },
            { 'O', ' ', 'X' }
        };

        // Act
        bool result = morpion.verifVictoire('X');

        // Assert
        Assert.False(result);
    }


    [Fact]
    public void VerifEgalite_ReturnsFalse_WhenGameIsNotOver()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { 'X', ' ', ' ' },
            { ' ', 'O', ' ' },
            { ' ', ' ', ' ' }
        };

        // Act
        bool result = morpion.verifEgalite();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void VerifEgalite_ReturnsTrue_WhenGameIsOverWithNoWinner()
    {
        // Arrange
        var morpion = new Morpion();
        morpion.grille = new char[,]
        {
            { 'X', 'O', 'X' },
            { 'X', 'X', 'O' },
            { 'O', 'X', 'O' }
        };

        // Act
        bool result = morpion.verifEgalite();

        // Assert
        Assert.True(result);
    }
}
