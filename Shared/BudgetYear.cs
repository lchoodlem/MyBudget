using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class BudgetYear
    {
        public int Id { get; set; }
        public string Year { get; set; } = string.Empty;
        public int? ReconcileBalanceId { get; set; }
        public ReconcileBalance? Balances { get; set; }

        public bool Deleted { get; set; }
        public bool CurrentYear { get; set; }
    }
}
