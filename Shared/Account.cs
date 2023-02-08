using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Shared
{
    public class Account
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string AcctNum { get; set; } = "...0000";
        public AcctType? AcctType { get; set; }
        public int AcctTypeId { get; set; }
        public Organization? Organization { get; set; }
        public int OrganizationId { get; set; }
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;

    }
}
