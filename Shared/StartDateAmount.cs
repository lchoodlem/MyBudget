using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class StartDateAmount
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime StartDate { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public double Amount { get; set; } = 0;
        public bool Active { get; set; }

    }
}
