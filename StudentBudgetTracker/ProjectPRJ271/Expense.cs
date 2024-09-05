using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectPRJ271
{
    public class Expense : Transaction
    {
        public string Category { get; set; }

        public Expense(decimal amount, string category, DateTime date, string description)
            : base(amount, date, description)
        {
            Category = category;
        }

        public override void Display()
        {
            Console.WriteLine($"Expense: {Amount:C} | Category: {Category} | Date: {Date.ToShortDateString()} | Description: {Description}");
        }
        public override void DisplayTransaction()
        {
            Console.WriteLine($"Expense: {Amount:C} | Category: {Category} | Date: {Date.ToShortDateString()} | Description: {Description}");
        }

    }
}
