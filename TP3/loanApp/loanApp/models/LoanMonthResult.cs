namespace LoanApp;

public struct LoanMonthResult
{
    public LoanMonthResult(double mensualityNumber, double refundedCapital, int remainingCapital)
    {
        MensualityNumber = mensualityNumber;
        RefundedCapital = refundedCapital;
        RemainingCapital = remainingCapital;
    }

    public double MensualityNumber { get; set; }
    public double RefundedCapital { get; set; }
    public double RemainingCapital { get; set; }
}
