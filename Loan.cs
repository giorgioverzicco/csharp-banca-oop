namespace csharp_banca_oop;

public class Loan
{
    private static int _lastLoanId = 0;

    private int _months;
    
    public int ID { get; }
    public Customer Holder { get; set; }
    public decimal Amount { get; }
    public decimal Instalment { get; }

    private DateOnly _startTime;
    public DateOnly StartTime
    {
        get => _startTime;

        private init
        {
            _startTime = value;
            EndTime = _startTime.AddMonths(_months);
        }
    }

    public DateOnly EndTime { get; private init; }

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
        _months = months;
        
        Holder = holder;
        Amount = amount;
        Instalment = amount / months;
        StartTime = DateOnly.FromDateTime(DateTime.Now);
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