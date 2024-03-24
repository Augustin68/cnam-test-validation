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
            return 0;
        }
    }
}
