using Xunit;
using LoanApp;

namespace LoanAppTest
{
    public class LoanTests
    {
        [Theory]
        [InlineData(50000, 0.015, 120)]
        [InlineData(50001, 0.015, 120)]
        public void ShouldCreateAndInitLoan(double capital, double annualRate, int monthDuration)
        {
            // Act
            Loan loan = new Loan(capital, annualRate, monthDuration);

            // Assert
            Assert.Equal(capital, loan.Capital);
            Assert.Equal(annualRate, loan.AnnualRate);
            Assert.Equal(monthDuration, loan.MonthDuration);
        }
    }
}
