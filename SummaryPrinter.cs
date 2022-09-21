using System.Collections.ObjectModel;

namespace csharp_banca_oop;

public static class SummaryPrinter
{
    public static void PrintCustomer(Bank bank, string fiscalCode)
    {
        Customer customer;
        
        try
        {
            customer = bank.FetchCustomer(fiscalCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        
        string infoText = 
            string.Format(
                "| {0,20} | {1,20} | {2,20} | {3,15} |", 
                "First Name", 
                "Last Name", 
                "Fiscal Code", 
                "Salary");
        string customerInfo = 
            string.Format(
                "| {0,20} | {1,20} | {2,20} | {3,15} |", 
                customer.FirstName, 
                customer.LastName,
                customer.FiscalCode, 
                customer.FormattedSalary);
        
        Console.WriteLine(infoText);
        Console.WriteLine(customerInfo);
    }

    public static void PrintAllLoans(Bank bank)
    {
        ReadOnlyCollection<Loan> loans = bank.Loans;

        if (loans.Count <= 0)
        {
            Console.WriteLine("There are no loans.");
            return;
        }
        
        string infoText = 
            string.Format(
                "| {0,5} | {1,20} | {2,20} | {3,15} | {4,12} | {5,15} | {6,15} |", 
                "ID", 
                "Holder",
                "Holder Fiscal Code",
                "Amount", 
                "Instalment",
                "Start Time",
                "End Time");
        Console.WriteLine(infoText);

        foreach (Loan loan in loans)
        {
            string loanInfo = 
                string.Format(
                    "| {0,5} | {1,20} | {2,20} | {3,15} | {4,12} | {5,15} | {6,15} |", 
                    loan.ID, 
                    loan.Holder.FullName,
                    loan.Holder.FiscalCode,
                    loan.FormattedAmount, 
                    loan.Instalment,
                    loan.StartTime,
                    loan.EndTime);
            Console.WriteLine(loanInfo);
        }
    }

    public static void PrintCustomerLoans(Bank bank, string fiscalCode)
    {
        List<Loan> loans = bank.FetchLoans(fiscalCode);

        if (loans.Count <= 0)
        {
            Console.WriteLine("There are no loans for this customer.");
            return;
        }
        
        string infoText = 
            string.Format(
                "| {0,20} | {1,20} | {2,15} | {3,12} | {4,15} | {5,15} |", 
                "Name", 
                "Fiscal Code", 
                "Amount", 
                "Instalment",
                "Start Time",
                "End Time");
        Console.WriteLine(infoText);
        
        foreach (Loan loan in loans)
        {
            string dataText = 
                string.Format(
                    "| {0,20} | {1,20} | {2,15} | {3,12} | {4,15} | {5,15} |", 
                    loan.Holder.FullName, 
                    loan.Holder.FiscalCode,
                    loan.FormattedAmount, 
                    loan.Instalment,
                    loan.StartTime,
                    loan.EndTime);
            Console.WriteLine(dataText);
        }
    }
}