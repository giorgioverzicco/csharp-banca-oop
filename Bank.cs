using System.Collections.ObjectModel;

namespace csharp_banca_oop;

public class Bank
{
    private readonly List<Customer> _customers;
    private readonly List<Loan> _loans;
    
    public string Name { get; }
    public ReadOnlyCollection<Loan> Loans { get; }

    public Bank()
    {
        _customers = new List<Customer>();
        _loans = new List<Loan>();
        
        Name = "No Name";
        Loans = _loans.AsReadOnly();
    }

    public Bank(string name)
        : this()
    {
        Name = name;
    }

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public void EditCustomer(string fiscalCode, Customer newCustomer)
    {
        var oldCustomer = FetchCustomer(fiscalCode);
        int indexOfCustomer = _customers.IndexOf(oldCustomer);
        _customers[indexOfCustomer] = newCustomer;

        var loans = FetchLoans(fiscalCode);
        loans.ForEach(x => x.Holder = newCustomer);
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

    public decimal GetRemainingInstalment(string fiscalCode)
    {
        var loans = FetchLoans(fiscalCode);
        var today = DateOnly.FromDateTime(DateTime.Now);
        var loansTillToday = loans.Where(x => x.EndTime >= today);

        return loansTillToday.Sum(x => x.Instalment);
    }
}