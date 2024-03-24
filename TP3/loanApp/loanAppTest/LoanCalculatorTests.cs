using Xunit;
using LoanApp;

namespace loanAppTest;

public class LoanCalculatorTests
{
    [Theory]
    [InlineData(0,0,0, 0)]
    public void ComputeLoanMonthlyPayment(double capital, double annualRate, int monthDuration, double result)
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        double computedResult = loanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Assert.Equal(computedResult, result);
    }

    [Fact]
    public void ShouldNotAcceptUnderMinimalAmount()
    {
        // Arrange
        LoanCalculator loanCalculator = new LoanCalculator();

        // Act
        Action act = () => loanCalculator.ComputeLoanMonthlyPayment(45000, 0.015, 120);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Capital should be above 50 000", exception.Message);
    }
}
