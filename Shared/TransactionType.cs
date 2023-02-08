using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
