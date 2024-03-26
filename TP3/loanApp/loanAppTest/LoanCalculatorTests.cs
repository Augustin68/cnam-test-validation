using LoanApp;

namespace LoanAppTest;

public class LoanCalculatorTests
{
    [Theory]
    [InlineData(-50000, 0.015, 120)]
    [InlineData(-1000000, 0.015, 120)]
    [InlineData(0, 0.015, 120)]
    [InlineData(double.MinValue, 0.015, 120)]
    public void ShouldNotAcceptUnderMinimalAmount(double capital, double annualRate, int monthDuration)
    {
        // Act
        Action act = () => LoanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Capital should be striclty above 50 000 (Parameter 'capital')", exception.Message);
    }

    [Theory]
    [InlineData(50001, 0.015, 120)]
    [InlineData(double.MaxValue, 0.015, 120)]
    public void ShouldAcceptAboveMinimalAmount(double capital, double annualRate, int monthDuration)
    {
        // Act
        Action act = () => LoanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Exception exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(50001, 0.015, -1)]
    [InlineData(50001, 0.015, int.MinValue)]
    [InlineData(50001, 0.015, -10000)]
    [InlineData(50001, 0.015, -99999999)]
    public void ShouldNotAcceptUnderMinimalMonthlyDuration(double capital, double annualRate, int monthDuration)
    {
        // Act
        Action act = () => LoanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("Monthly duration should be between 9 and 25 years (Parameter 'monthDuration')", exception.Message);
    }

    [Theory]
    [InlineData(50001, 0.015, 1)]
    [InlineData(50001, 0.015, 0)]
    [InlineData(50001, 0.015, 300)]
    public void ShouldAcceptAboveAuthorizedMonthlyDuration(double capital, double annualRate, int monthDuration)
    {
        // Act
        Action act = () => LoanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Exception exception = Record.Exception(act);
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(100000, 0.015, 120, 897.91)]
    [InlineData(100000, double.MaxValue, 120, double.PositiveInfinity)]
    [InlineData(double.MaxValue, double.MaxValue, 150, double.PositiveInfinity)]
    public void ShouldComputeMonthlyLoan(double capital, double annualRate, int monthDuration, double correctResult)
    {
        // Act
        double result = LoanCalculator.ComputeLoanMonthlyPayment(capital, annualRate, monthDuration);

        // Assert
        Assert.Equal(correctResult, result);
    }
}
