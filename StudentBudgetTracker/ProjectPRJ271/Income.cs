using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectPRJ271
{
    public class Income : Transaction
    {
        public string Source { get; set; }

        public Income(decimal amount, string source, DateTime date, string description)
            : base(amount, date, description)
        {
            Source = source;
        }

        public override void Display()
        {
            Console.WriteLine($"Income: {Amount:C} | Source: {Source} | Date: {Date.ToShortDateString()} | Description: {Description}");
        }
        public override void DisplayTransaction()
        {
            Console.WriteLine($"Income: {Amount:C} | Source: {Source} | Date: {Date.ToShortDateString()} | Description: {Description}");
        }
    }

   
}
