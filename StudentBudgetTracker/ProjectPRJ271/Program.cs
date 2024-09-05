using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRJ271

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Budget budget = new Budget();
            DataSaver dataSaver = new DataSaver(budget);
            dataSaver.Start();

            budget.TransactionAdded += transaction =>
            {
                Console.WriteLine("Transaction added:");
                transaction.DisplayTransaction();
            };

            if (RegisterOrLogin())
            {
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\nBudgeting Application");
                    Console.WriteLine("1. Add Income");
                    Console.WriteLine("2. Add Expense");
                    Console.WriteLine("3. View Summary");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AddIncome(budget);
                            break;
                        case "2":
                            AddExpense(budget);
                            break;
                        case "3":
                            budget.GetSummary();
                            break;
                        case "4":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Authentication failed. Exiting...");
            }
        }

        static bool RegisterOrLogin()
        {
            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        if (AuthenticateUser())
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Authentication failed. Would you like to try again? (y/n): ");
                            string retry = Console.ReadLine();
                            if (retry.ToLower() != "y")
                            {
                                return false;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine();
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            UserCredentialsManager.AddUser(username, password);
            Console.WriteLine("Registration successful. You can now log in.");
        }

        static bool AuthenticateUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return UserCredentialsManager.Authenticate(username, password);
        }

        static void AddIncome(Budget budget)
        {
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter income source e.g part-time job, allowance or stipend etc. : ");
            string source = Console.ReadLine();
            Console.Write("Enter date of income received (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter description e.g pocket money, wages etc.  : ");
            string description = Console.ReadLine();

            Income income = new Income(amount, source, date, description);
            try
            {
                budget.AddTransaction(income);
                Console.WriteLine("Income added successfully.");
            }
            catch (InvalidTransactionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddExpense(Budget budget)
        {
            Console.Write("Enter amount spent: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter category: e.g transport, entertainment, food etc ");
            string category = Console.ReadLine();
            Console.Write("Enter date of expence (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter description:(type of transaction e.g instore purchase, EFT, debit order etc.  ");
            string description = Console.ReadLine();

            Expense expense = new Expense(amount, category, date, description);
            try
            {
                budget.AddTransaction(expense);
                Console.WriteLine("Expense added successfully.");
            }
            catch (InvalidTransactionException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
