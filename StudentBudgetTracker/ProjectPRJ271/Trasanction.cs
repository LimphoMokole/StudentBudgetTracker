using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRJ271
{
    public abstract class Transaction
    {
        public decimal Amount { get; protected set; }
        public DateTime Date { get; protected set; }
        public string Description { get; protected set; }

        protected Transaction(decimal amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public abstract void DisplayTransaction();

        public abstract void Display();
    }
}
