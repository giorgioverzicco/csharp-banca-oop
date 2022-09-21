namespace csharp_banca_oop;

public class Loan
{
    private static int _lastLoanId = 0;
    
    public int ID { get; }
    public Customer Holder { get; set; }
    public decimal Amount { get; }
    public decimal Instalment { get; }
    public DateOnly StartTime { get; }
    public DateOnly EndTime { get; }

    public string FormattedAmount => $"{Amount:C}";
    public string FormattedInstalment => $"{Instalment:C}";

    private Loan()
    {
        _lastLoanId++;

        ID = _lastLoanId;
    }

    public Loan(
        Customer holder, 
        decimal amount, 
        byte months)
        : this()
    {
        Holder = holder;
        Amount = amount;
        Instalment = amount / months;
        StartTime = DateOnly.FromDateTime(DateTime.Now);
        EndTime = StartTime.AddMonths(months);
    }

    public Loan(
        Customer holder,
        decimal amount,
        byte months,
        DateOnly startTime)
        : this(holder, amount, months)
    {
        StartTime = startTime;
    }
    
    public int GetMonthsLeft() {
        var endTimeDate = EndTime.ToDateTime(TimeOnly.MinValue);
        var today = DateTime.Now;
        var difference = endTimeDate - today;
        var monthsLeft = difference.Days / 30;

        return monthsLeft;
    }

    public override string ToString()
    {
        return
            "Holder:\n" +
            $"{Holder}\n" +
            "Loan:" +
            $"Amount: {FormattedAmount}\n" +
            $"Instalment: {FormattedInstalment}\n" +
            $"Start Time: {StartTime}\n" +
            $"End Time: {EndTime}\n";
    }
}