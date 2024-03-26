using System;

namespace LoanApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoanArgs loanArgs = GetArgs(args);

                Loan loan = new Loan(loanArgs.Capital, loanArgs.AnnualRate, loanArgs.MonthDuration);
                loan.ComputeResult();

                RealFileSystem fileSystem = new RealFileSystem();
                LoanPrinter loanPrinter = new LoanPrinter(fileSystem);
                loanPrinter.PrintLoan(loan.TotalPayment, loan.MonthResults, "loan.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static LoanArgs GetArgs(string[] args)
        {
            if (args.Length != 3 || args.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException("Please provide 3 arguments: capital, annual rate and month duration");
            }

            double capital = double.Parse(args[0]);
            double annualRate = double.Parse(args[1]) / 100;
            int monthDuration = int.Parse(args[2]);

            return new LoanArgs
            {
                Capital = capital,
                AnnualRate = annualRate,
                MonthDuration = monthDuration
            };
        }
    }
}