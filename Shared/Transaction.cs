using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class Transaction
    {
        public int Id { get; set; }
        public int YearInt { get; set; } = 0; // default 0 is Budget Transactions
        public int MonthInt { get; set; } = 0; // default 0 for Budget      
        public int Day { get; set; } = 1;
        public double BudgetAmount { get; set; } = 0;
        public double Amount { get; set; } = 0;
        public Account? Account { get; set; }
        public int AccountId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
        public bool Reconciled { get; set; } = false;

    }
}
