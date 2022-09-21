namespace csharp_banca_oop;

public static class Menu
{
    public static void Init()
    {
        Bank bank = CreateBank();
        int choice;
        
        do
        {
            PrintOptions();
            choice = GetChoice();
            SelectOption(bank, choice);

            Console.WriteLine();
        } while (choice != -1);
    }

    private static void CheckAllLoans(Bank bank)
    {
        SummaryPrinter.PrintAllLoans(bank);
    }
    
    private static void CheckTotalRemainingInstalments(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
        decimal remainingInstalment = bank.GetRemainingInstalment(fiscalCode);
        Console.WriteLine(
            $"The total amount of the remaining instalments in {DateTime.Today} for that customer is: {remainingInstalment:C}");
    }

    private static void CheckTotalLoansAmount(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
        decimal totalAmountOfLoans = bank.GetTotalAmountOfLoans(fiscalCode);
        Console.WriteLine($"The total amount of loans for that customer is: {totalAmountOfLoans:C}");
    }
    
    private static void FindCustomerLoans(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
        SummaryPrinter.PrintCustomerLoans(bank, fiscalCode);
    }

    private static void AddLoan(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
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

        Console.WriteLine("Enter the amount:");
        Console.Write("> ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        
        Console.WriteLine("Enter the total months:");
        Console.Write("> ");
        byte months = Convert.ToByte(Console.ReadLine());

        bank.AddLoan(
            new Loan(customer, amount, months));
    }

    private static void FindCustomer(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
        SummaryPrinter.PrintCustomer(bank, fiscalCode);
    }

    private static void EditCustomer(Bank bank)
    {
        string fiscalCode = GetFiscalCode();
        Customer customer = CreateCustomer();

        try
        {
            bank.EditCustomer(fiscalCode, customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddCustomer(Bank bank)
    {
        Customer customer = CreateCustomer();
        bank.AddCustomer(customer);
    }

    private static Customer CreateCustomer()
    {
        Console.WriteLine("Please, enter the customer details:");
        
        Console.Write("First Name: ");
        string firstName = Console.ReadLine() ?? "";
        
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine() ?? "";
        
        Console.Write("Fiscal Code: ");
        string fiscalCode = Console.ReadLine() ?? "";
        
        Console.Write("Salary: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());
        
        Console.WriteLine();

        return new Customer(firstName, lastName, fiscalCode, salary);
    }

    private static string GetFiscalCode()
    {
        Console.WriteLine("Please, enter the fiscal code of the customer:");
        Console.Write("> ");
        
        string fiscalCode = Console.ReadLine() ?? "";
        Console.WriteLine();
        
        return fiscalCode;
    }

    private static void SelectOption(Bank bank, int choice)
    {
        switch (choice)
        {
            case 1:
                AddCustomer(bank);
                break;
            case 2:
                EditCustomer(bank);
                break;
            case 3:
                FindCustomer(bank);
                break;
            case 4:
                AddLoan(bank);
                break;
            case 5:
                FindCustomerLoans(bank);
                break;
            case 6:
                CheckTotalLoansAmount(bank);
                break;
            case 7:
                CheckTotalRemainingInstalments(bank);
                break;
            case 8:
                CheckAllLoans(bank);
                break;
        }
    }

    private static int GetChoice()
    {
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return choice;
    }

    private static void PrintOptions()
    {
        Console.WriteLine("Select an option (-1 to abort):");
        Console.WriteLine("1. Add a new customer");
        Console.WriteLine("2. Edit a customer");
        Console.WriteLine("3. Find a customer");
        Console.WriteLine("4. Add a loan");
        Console.WriteLine("5. Find customer loans");
        Console.WriteLine("6. Check the total loans amount of a customer");
        Console.WriteLine("7. Check the total of remaining instalments of a customer");
        Console.WriteLine("8. Check all loans in the bank");
        
        Console.Write("> ");
    }

    private static Bank CreateBank()
    {
        Console.WriteLine("Please, enter the bank name:");
        Console.Write("> ");

        string bankName = Console.ReadLine() ?? "";
        Console.WriteLine();

        return new Bank(bankName);
    }
}