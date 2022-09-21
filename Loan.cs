namespace csharp_banca_oop;

public class Loan
{
    private static int _lastLoanId = 0;
    
    public int ID { get; }
    public Customer Holder { get; set; }
    public decimal Amount { get; }
    public int Instalment { get; }
    public DateOnly StartTime { get; }
    public DateOnly EndTime { get; }

    private Loan()
    {
        _lastLoanId++;

        ID = _lastLoanId;
    }

    public Loan(
        Customer holder, 
        decimal amount, 
        int instalment, 
        DateOnly startTime, 
        DateOnly endTime)
        : this()
    {
        Holder = holder;
        Amount = amount;
        Instalment = instalment;
        StartTime = startTime;
        EndTime = endTime;
    }
}