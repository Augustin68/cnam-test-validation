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
            csv.AppendLine(totalPayment.ToString());
            foreach (var monthResult in monthResults)
            {
                csv.AppendLine($"{monthResult.MensualityNumber};{monthResult.RefundedCapital};{monthResult.RemainingCapital}");
            }

            FileSystem.WriteAllText(path, csv.ToString());
        }
    }
}
