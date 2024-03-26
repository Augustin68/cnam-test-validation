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

        public Loan(double capital, double annualRate, int monthDuration)
        {
            Capital = capital;
            AnnualRate = annualRate;
            MonthDuration = monthDuration;
            MonthResults = new List<LoanMonthResult>();
        }
    }
}
