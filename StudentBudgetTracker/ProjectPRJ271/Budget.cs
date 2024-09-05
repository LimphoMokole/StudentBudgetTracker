using System;
using System.Collections.Generic;

namespace ProjectPRJ271
{
    public delegate void TransactionAddedHandler(Transaction transaction);

    public class Budget : IBudgetManager
    {
        private List<Transaction> transactions;

        public event TransactionAddedHandler TransactionAdded;

        public Budget()
        {
            transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0)
            {
                throw new InvalidTransactionException("Transaction amount must be positive.");
            }

            transactions.Add(transaction);
            OnTransactionAdded(transaction);
        }

        protected virtual void OnTransactionAdded(Transaction transaction)
        {
            TransactionAdded?.Invoke(transaction);
        }

        public decimal GetTotalIncome()
        {
            decimal totalIncome = 0;
            foreach (var transaction in transactions)
            {
                if (transaction is Income income)
                {
                    totalIncome += income.Amount;
                }
            }
            return totalIncome;
        }

        public decimal GetTotalExpenses()
        {
            decimal totalExpenses = 0;
            foreach (var transaction in transactions)
            {
                if (transaction is Expense expense)
                {
                    totalExpenses += expense.Amount;
                }
            }
            return totalExpenses;
        }

        public decimal GetBalance()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("----All Income Transactions----");
            foreach (var transaction in transactions)
            {
                if (transaction is Income)
                {
                    transaction.DisplayTransaction();
                }
            }

            Console.WriteLine("\n----All Expense Transactions----");
            foreach (var transaction in transactions)
            {
                if (transaction is Expense)
                {
                    transaction.DisplayTransaction();
                }
            }
        }

        public void GetSummary()
        {
            Console.WriteLine("----Budget Summary----");

            Console.WriteLine("----All Income Transactions----");
            foreach (var transaction in transactions)
            {
                if (transaction is Income)
                {
                    transaction.DisplayTransaction();
                }
            }


            Console.WriteLine("\n----All Expense Transactions----");
            foreach (var transaction in transactions)
            {
                if (transaction is Expense)
                {
                    transaction.DisplayTransaction();
                }
            }

            decimal totalIncome = GetTotalIncome();
            decimal totalExpenses = GetTotalExpenses();
            decimal balance = GetBalance();
            decimal savings = balance;

            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Balance: {balance:C}");

            JudgeSavings(totalIncome, savings);
        }

        private void JudgeSavings(decimal totalIncome, decimal savings)
        {
            decimal requiredSavings = totalIncome * 0.20M;

            if (savings >= requiredSavings)
            {
                Console.WriteLine("Congratulations! You've saved more than 20% of your income.");
            }
            else
            {
                Console.WriteLine("You need to work on your savings. Try to save at least 20% of your income.");
            }
        }

        public void AddIncome(Income income)
        {
            AddTransaction(income);
        }

        public void AddExpense(Expense expense)
        {
            AddTransaction(expense);
        }
    }
}
