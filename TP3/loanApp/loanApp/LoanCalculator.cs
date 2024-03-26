using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp
{
    public class LoanCalculator
    {
        const int MIN_CAPITAL = 50000;
        const int MIN_MONTH_DURATION = 108;
        const int MAX_MONTH_DURATION = 300;

        public static double ComputeLoanMonthlyPayment(double capital, double annualRate, int monthDuration)
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

            double annualRateOnMonth = annualRate / 12;
            double topEquation = capital * annualRateOnMonth;
            double bottomEquation = 1 - Math.Pow((1 + annualRateOnMonth), -monthDuration);
            double result = Math.Round(topEquation / bottomEquation, 2);

            return result;
        }
    }
}
