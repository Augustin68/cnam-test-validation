namespace LoanApp;

public struct LoanArgs
{
    public LoanArgs(double capital, double annualRate, int monthDuration)
    {
        Capital = capital;
        AnnualRate = annualRate;
        MonthDuration = monthDuration;
    }

    public double Capital { get; set; }
    public double AnnualRate { get; set; }
    public int MonthDuration { get; set; }
}
