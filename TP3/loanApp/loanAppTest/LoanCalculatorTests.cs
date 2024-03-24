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
    public void ShouldNotAcceptUnderMinimalAmount(double capital, double annualRate, int monthlyDuration)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthlyDuration);

        // Assert
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Capital should be striclty above 50 000 (Parameter 'capital')", exception.Message);
    }
}
