using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp
{
    public class LoanPrinter
    {
        private IFileSystem FileSystem;
        public LoanPrinter(IFileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }

        public void PrintLoan(double totalPayment, List<LoanMonthResult> monthResults, string path)
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine(Math.Round(totalPayment, 2).ToString());
            foreach (var monthResult in monthResults)
            {
                csv.AppendLine($"{Math.Round(monthResult.MensualityNumber, 2)};{Math.Round(monthResult.RefundedCapital, 2)};{Math.Round(monthResult.RemainingCapital, 2)}");
            }

            FileSystem.WriteAllText(path, csv.ToString());
        }
    }
}
