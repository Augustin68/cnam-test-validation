using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp
{
    public class Loan
    {
        public double Capital { get; set; }
        public double AnnualRate { get; set; }
        public int MonthDuration { get; set; }
        public List<LoanMonthResult> MonthResults { get; set; }
        public double TotalPayment { get; set; }

        const int MIN_CAPITAL = 50000;
        const int MIN_MONTH_DURATION = 108;
        const int MAX_MONTH_DURATION = 300;

        public Loan(double capital, double annualRate, int monthDuration)
        {
            if (capital <= MIN_CAPITAL)
            {
                throw new ArgumentOutOfRangeException("capital", "Capital should be striclty above 50 000");
            }

            // Between 9 and 25 years
            if (monthDuration < MIN_MONTH_DURATION || monthDuration > MAX_MONTH_DURATION)
            {
                throw new ArgumentOutOfRangeException("monthDuration", "Monthly duration should be between 9 and 25 years");
            }

            Capital = capital;
            AnnualRate = annualRate;
            MonthDuration = monthDuration;
            MonthResults = new List<LoanMonthResult>();
        }

        public void ComputeResult()
        {
            double monthlyPayment = LoanCalculator.ComputeLoanMonthlyPayment(this.Capital, this.AnnualRate, this.MonthDuration);
            TotalPayment = LoanCalculator.ComputeLoanTotalPayment(monthlyPayment, this.MonthDuration);

            double remainingCapital = this.Capital;
            double monthlyRate = this.AnnualRate / 12;
            for (int i = 1; i <= this.MonthDuration; i++)
            {
                double monthInterest = remainingCapital * monthlyRate;
                double monthRefundedCapital = monthlyPayment - monthInterest;
                remainingCapital -= monthRefundedCapital;

                MonthResults.Add(new LoanMonthResult
                {
                    MensualityNumber = i,
                    RefundedCapital = monthRefundedCapital,
                    RemainingCapital = remainingCapital,
                });
            }
        }
    }
}
