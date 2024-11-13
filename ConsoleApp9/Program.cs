using System;

class ATM
{
    static void Main()
    {
        decimal balance = 1000m; // ยอดเงินเริ่มต้น
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Calculate Tax");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Deposit(ref balance);
                    break;
                case "2":
                    Withdraw(ref balance);
                    break;
                case "3":
                    CalculateTax();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine($"\nCurrent balance: {balance:C}\n");
        }
    }

    static void Deposit(ref decimal balance)
    {
        Console.Write("Enter amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
    }

    static void Withdraw(ref decimal balance)
    {
        Console.Write("Enter amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrew {amount:C}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
    }

    static void CalculateTax()
    {
        Console.Write("Enter income and bonus: ");
        decimal incomeAndBonus = decimal.Parse(Console.ReadLine());

        Console.Write("Enter personal expenses: ");
        decimal personalExpenses = decimal.Parse(Console.ReadLine());

        Console.Write("Enter personal deductions: ");
        decimal personalDeductions = decimal.Parse(Console.ReadLine());

        decimal grossIncome = incomeAndBonus;
        decimal netIncome = grossIncome - personalExpenses - personalDeductions;

        Console.WriteLine($"\nGross Income: {grossIncome:C}");
        Console.WriteLine($"Net Income after expenses and deductions: {netIncome:C}");

        decimal taxAmount = CalculateTaxAmount(netIncome);
        Console.WriteLine($"Total Tax Payable: {taxAmount:C}");
    }

    static decimal CalculateTaxAmount(decimal netIncome)
    {
        decimal taxAmount = 0;

        if (netIncome > 5000000)
        {
            taxAmount = (netIncome - 5000000) * 0.35m + 1265000;
        }
        else if (netIncome > 2000000)
        {
            taxAmount = (netIncome - 2000000) * 0.30m + 365000;
        }
        else if (netIncome > 1000000)
        {
            taxAmount = (netIncome - 1000000) * 0.25m + 115000;
        }
        else if (netIncome > 750000)
        {
            taxAmount = (netIncome - 750000) * 0.20m + 65000;
        }
        else if (netIncome > 500000)
        {
            taxAmount = (netIncome - 500000) * 0.15m + 27500;
        }
        else if (netIncome > 300000)
        {
            taxAmount = (netIncome - 300000) * 0.10m + 7500;
        }
        else if (netIncome > 150000)
        {
            taxAmount = (netIncome - 150000) * 0.05m;
        }
        else
        {
            taxAmount = 0; // ยกเว้นภาษี
        }

        return taxAmount;
    }
}
