namespace csharp_banca_oop;

public class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public string FiscalCode { get; }
    public decimal Salary { get; }

    public Customer(
        string firstName,
        string lastName,
        string fiscalCode,
        decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        FiscalCode = fiscalCode;
        Salary = salary;
    }
}