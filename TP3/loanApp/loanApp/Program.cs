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

                double monthlyPayment = LoanCalculator.ComputeLoanMonthlyPayment(loanArgs.Capital, loanArgs.AnnualRate, loanArgs.MonthDuration);
                Console.WriteLine($"Monthly payment: {monthlyPayment}");
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
            double annualRate = double.Parse(args[1]);
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