using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp
{
    public class LoanCalculator
    {
        public double ComputeLoanMonthlyPayment(double capital, double annualRate, int monthDuration)
        {
            if(capital <= 50000)
            {
                throw new ArgumentOutOfRangeException("capital", "Capital should be striclty above 50 000");
            }

            // Between 9 and 25 years
            if(monthDuration < 108 || monthDuration > 300)
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
