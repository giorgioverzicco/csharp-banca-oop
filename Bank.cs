namespace csharp_banca_oop;

public class Bank
{
    private List<Customer> _customers = new();
    private List<Loan> _loans = new();
    
    public string Name { get; }

    public Bank()
    {
        Name = "No Name";
    }

    public Bank(string name)
    {
        Name = name;
    }

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public void EditCustomer(string fiscalCode, Customer newCustomer)
    {
        try
        {
            var oldCustomer = FetchCustomer(fiscalCode);
            int indexOfCustomer = _customers.IndexOf(oldCustomer);
            _customers[indexOfCustomer] = newCustomer;

            var loans = FetchLoans(fiscalCode);
            loans.ForEach(x => x.Holder = newCustomer);
        }
        catch (InvalidOperationException)
        {
            throw;
        }
    }

    public Customer FetchCustomer(string fiscalCode)
    {
        Customer? customer = _customers.Find(x => x.FiscalCode == fiscalCode);
        
        if (customer is null)
            throw new InvalidOperationException("This customer doesn't exists.");

        return customer;
    }

    public void AddLoan(Loan loan)
    {
        _loans.Add(loan);
    }

    public List<Loan> FetchLoans(string fiscalCode)
    {
        return 
            _loans
            .Where(x => x.Holder.FiscalCode == fiscalCode)
            .ToList();
    }

    public decimal GetTotalAmountOfLoans(string fiscalCode)
    {
        var loans = FetchLoans(fiscalCode);
        
        return loans.Sum(x => x.Amount);
    }

    public int GetRemainingInstalment(string fiscalCode)
    {
        var loans = FetchLoans(fiscalCode);
        var today = DateOnly.FromDateTime(DateTime.Now);
        var loansTillToday = loans.Where(x => x.EndTime >= today);

        return loansTillToday.Sum(x => x.Instalment);
    }
}