using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRJ271
{
    public interface ITrackable
    {
        void Track();
    }

    public interface IBudgetManager
    {
        void AddIncome(Income income);
        void AddExpense(Expense expense);
        void GetSummary();
    }
}
