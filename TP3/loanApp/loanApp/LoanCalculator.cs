using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp
{
    public class LoanCalculator
    {
        const int MIN_CAPITAL = 0;
        const int MIN_MONTH_DURATION = 0;

        public static double ComputeLoanMonthlyPayment(double capital, double annualRate, int monthDuration)
        {
            if (capital <= MIN_CAPITAL)
            {
                throw new ArgumentOutOfRangeException("capital", "Capital should be striclty above 50 000");
            }

            // Between 9 and 25 years
            if (monthDuration < MIN_MONTH_DURATION)
            {
                throw new ArgumentOutOfRangeException("monthDuration", "Monthly duration should be between 9 and 25 years");
            }

            double annualRateOnMonth = annualRate / 12;
            double topEquation = capital * annualRateOnMonth;
            double bottomEquation = 1 - Math.Pow((1 + annualRateOnMonth), -monthDuration);
            double result = Math.Round(topEquation / bottomEquation, 2);

            return result;
        }

        public static double ComputeLoanTotalPayment(double monthlyPayment, int monthDuration)
        {
            if(monthDuration < 1)
            {
                   throw new ArgumentOutOfRangeException("monthDuration", "Monthly duration should be above 0");
            }

            if(monthlyPayment < 1)
            {
                   throw new ArgumentOutOfRangeException("monthlyPayment", "Monthly payment should be above 0");
            }

            return Math.Round(monthlyPayment * monthDuration, 2);
        }
    }
}
