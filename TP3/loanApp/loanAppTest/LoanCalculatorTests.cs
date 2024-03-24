using Xunit;
using LoanApp;

namespace loanAppTest;

public class LoanCalculatorTests
{
    [Theory]
    [InlineData(45000, 0.015, 120)]
    [InlineData(50000, 0.015, 120)]
    [InlineData(0, 0.015, 120)]
    [InlineData(-10000, 0.015, 120)]
    [InlineData(int.MinValue, 0.015, 120)]
    public void ShouldNotAcceptUnderMinimalAmount(double capital, double annualRate, int monthDuration)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Capital should be striclty above 50 000 (Parameter 'capital')", exception.Message);
    }

    [Theory]
    [InlineData(50001, 0.015, 120)]
    [InlineData(int.MaxValue, 0.015, 120)]
    public void ShouldAcceptAboveMinimalAmount(double capital, double annualRate, int monthDuration)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Exception exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(50001, 0.015, 0)]
    [InlineData(50001, 0.015, int.MinValue)]
    [InlineData(50001, 0.015, int.MaxValue)]
    [InlineData(50001, 0.015, 107)]
    [InlineData(50001, 0.015, 301)]
    public void ShouldNotAcceptUnderMinimalMonthlyDuration(double capital, double annualRate, int monthDuration)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Monthly duration should be between 9 and 25 years (Parameter 'monthDuration')", exception.Message);
    }

    [Theory]
    [InlineData(50001, 0.015, 120)]
    [InlineData(50001, 0.015, 108)]
    [InlineData(50001, 0.015, 300)]
    public void ShouldAcceptBetweenAuthorizedMonthlyDuration(double capital, double annualRate, int monthDuration)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Exception exception = Record.Exception(act);
        Assert.Null(exception);
    }
}
