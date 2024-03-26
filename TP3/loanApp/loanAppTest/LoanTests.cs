using Xunit;
using LoanApp;

namespace LoanAppTest
{
    public class LoanTests
    {
        [Theory]
        [InlineData(50002, 0.015, 120)]
        [InlineData(50001, 0.015, 120)]
        public void ShouldCreateAndInitLoan(double capital, double annualRate, int monthDuration)
        {
            // Arrange
            Loan loan = new Loan(capital, annualRate, monthDuration);

            // Assert
            Assert.Equal(capital, loan.Capital);
            Assert.Equal(annualRate, loan.AnnualRate);
            Assert.Equal(monthDuration, loan.MonthDuration);
        }

        [Theory]
        [InlineData(45000, 0.015, 120)]
        [InlineData(50000, 0.015, 120)]
        [InlineData(0, 0.015, 120)]
        [InlineData(-10000, 0.015, 120)]
        [InlineData(double.MinValue, 0.015, 120)]
        public void ShouldNotAcceptUnderMinimalAmount(double capital, double annualRate, int monthDuration)
        {
            // Arrange
            Loan loan;

            // Act
            Action act = () => loan = new Loan(capital, annualRate, monthDuration);

            // Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("Capital should be striclty above 50 000 (Parameter 'capital')", exception.Message);
        }

        [Theory]
        [InlineData(50001, 0.015, 120)]
        [InlineData(double.MaxValue, 0.015, 120)]
        public void ShouldAcceptAboveMinimalAmount(double capital, double annualRate, int monthDuration)
        {
            // Arrange
            Loan loan;

            // Act
            Action act = () => loan = new Loan(capital, annualRate, monthDuration);

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
            Loan loan;

            // Act
            Action act = () => loan = new Loan(capital, annualRate, monthDuration);

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
            Loan loan;

            // Act
            Action act = () => loan = new Loan(capital, annualRate, monthDuration);

            // Assert
            Exception exception = Record.Exception(act);
            Assert.Null(exception);
        }

        [Fact]
        public void ShouldComputeMonthResult()
        {
            // Arrange
            Loan loan = new Loan(50001, 0.015, 120);

            // Act
            loan.ComputeResult();

            // Assert
            Assert.NotEmpty(loan.MonthResults);
            Assert.Equal(120, loan.MonthResults.Count);
        }

        [Theory, MemberData(nameof(LoanMonthlyResult))]
        public void ShouldComputeMonthResultWithGoodResult(double capital, double annualRate, int monthDuration, double expectedTotal, List<LoanMonthResult> expectedResult)
        {
            // Arrange
            Loan loan = new Loan(capital, annualRate, monthDuration);

            // Act
            loan.ComputeResult();


            // Assert
            expectedResult.ForEach(expected =>
            {
                LoanMonthResult result = loan.MonthResults.Find(r => r.MensualityNumber == expected.MensualityNumber);
                Console.WriteLine(result);
                Assert.Equal(expected.RefundedCapital, result.RefundedCapital, 2);
                Assert.Equal(expected.RemainingCapital, result.RemainingCapital, 2);
            });

            Assert.Equal(expectedTotal, loan.TotalPayment, 2);
        }

        public static IEnumerable<object[]> LoanMonthlyResult =>
        new List<object[]>
        {
            new object[] { "100000", "0,015", "120", "107749,2" , new List<LoanMonthResult>()
                {
                    new LoanMonthResult { MensualityNumber = 1, RefundedCapital = 897.91, RemainingCapital = 99102.09 },
                    new LoanMonthResult { MensualityNumber = 2, RefundedCapital = 1795.82, RemainingCapital = 98204.18 },
                    new LoanMonthResult { MensualityNumber = 24, RefundedCapital = 21549.84, RemainingCapital = 78450.16 }
                }
            },
        };
    }
}