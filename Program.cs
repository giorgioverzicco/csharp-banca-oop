using csharp_banca_oop;

Customer giorgio = new Customer(
    "Giorgio",
    "Verzicco",
    "VRZGRG00R25B619C",
    24000m);
Customer alan = new Customer(
    "Alan",
    "Bruno",
    "BRNALN92T12A112G",
    20000m);

Bank bank = new Bank("Intesa San Paolo");
bank.AddCustomer(giorgio);
bank.AddCustomer(alan);
bank.AddLoan(
    new Loan(
        giorgio, 
        20000m, 
        60, 
        DateOnly.FromDateTime(DateTime.Now), 
        DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(1825))));
bank.AddLoan(
    new Loan(
        giorgio, 
        1000m, 
        6, 
        DateOnly.FromDateTime(DateTime.Now),
        DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(183))));
bank.AddLoan(
    new Loan(
        alan, 
        12550m, 
        30, 
        DateOnly.FromDateTime(DateTime.Now), 
        DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(913))));
bank.AddLoan(
    new Loan(
        alan, 
        5000m, 
        10, 
        DateOnly.FromDateTime(DateTime.Now),
        DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(304))));

List<Loan> giorgioLoans = bank.FetchLoans(giorgio.FiscalCode);
List<Loan> alanLoans = bank.FetchLoans(alan.FiscalCode);

SummaryPrinter.PrintCustomer(bank, giorgio.FiscalCode);
SummaryPrinter.PrintCustomerLoans(bank, giorgio.FiscalCode);
SummaryPrinter.PrintAllLoans(bank);
