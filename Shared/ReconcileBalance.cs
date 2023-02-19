using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class ReconcileBalance
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountIn { get; set; } // from previous Month/Year if Month is null
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountTotal { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthBudgetIn { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthBudgetOut { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthReconcileIn { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthReconcileOut { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthReconcileTotal { get; set;} // if Month is 0 this is the Dec ReconcilleTotal
        public bool Reconciled { get; set; } = false; // the LastBank Date and the LastBank Value should match
        public DateTime LastBankDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastBankValue { get; set; } // used for reconciling Daily once Mth is reconciled it should be the same as MthTotal

    }
}
