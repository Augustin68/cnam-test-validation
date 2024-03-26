using LoanApp;

namespace loanAppTest;

public class ProgramTests
{
    [Theory]
    [InlineData("50000", "0.015", "120", "0")]
    [InlineData("50000", "0.015")]
    [InlineData("50000", "0.015", "120", "0", "50000", "0.015", "120", "0")]
    [InlineData("50000", "", "0.015")]

    public void ShouldThrowErrorsIfArgsIncorrect(params string[] args)
    {
        // Arrange
        // Act
        Action act = () => Program.GetArgs(args);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Please provide 3 arguments: capital, annual rate and month duration", exception.Message);
    }

    [Theory, MemberData(nameof(LoanArgsData))]
    public void ShouldReturnLoanArgsFormated(string capital, string annualRate, string monthDuration, LoanArgs expected)
    {
        // Arrange
        string[] args = new string[] { capital, annualRate, monthDuration };
        // Act
        LoanArgs result = Program.GetArgs(args);

        // Assert
        Assert.Equal(expected.Capital, result.Capital);
        Assert.Equal(expected.AnnualRate, result.AnnualRate);
        Assert.Equal(expected.MonthDuration, result.MonthDuration);
    }

    public static IEnumerable<object[]> LoanArgsData =>
        new List<object[]>
        {
            new object[] { "50000", "0,015", "120", new LoanArgs(50000, 0.015, 120) },
            new object[] { "50000", "0", "120", new LoanArgs(50000, 0, 120) },
        };
}