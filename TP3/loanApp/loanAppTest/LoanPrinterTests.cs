using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanApp;

namespace LoanAppTest
{
    public class LoanPrinterTests
    {
        [Fact]
        public void PrintLoan_ShouldWriteFile()
        {
            // Arrange
            IFileSystem fileSystem = new TestFileSystem();
            LoanPrinter loanPrinter = new LoanPrinter(fileSystem);
            Loan loan = new Loan(100000, 0.015, 120);
            loan.ComputeResult();

            string fileName = "test.csv";
            // Act
            loanPrinter.PrintLoan(loan.TotalPayment, loan.MonthResults, fileName);

            // Assert
            Assert.True(fileSystem.Exists(fileName));
        }

        [Fact]
        public void PrintLoan_ShouldWriteTotalOnFirstLine()
        {
            // Arrange
            TestFileSystem fileSystem = new TestFileSystem();
            LoanPrinter loanPrinter = new LoanPrinter(fileSystem);
            Loan loan = new Loan(100000, 0.015, 120);
            loan.ComputeResult();

            string fileName = "test.csv";
            // Act
            loanPrinter.PrintLoan(loan.TotalPayment, loan.MonthResults, fileName);

            // Assert
            string content = fileSystem.fileSystem[fileName];
            string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.Equal("107749,2", lines[0]);
            Assert.Equal("1;897,91;99102,09", lines[1]);
            Assert.Equal("24;21549,84;78450,16", lines[24]);

        }
    }
}
