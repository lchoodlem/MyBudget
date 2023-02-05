using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public bool Debit { get; set; } = true; // (- transaction value if true) or (+ false)
        public string Description { get; set; } = string.Empty;
    }
}
