using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {

        private static List<TransactionType> TransactionTypes = new List<TransactionType>
        {
            new TransactionType
            {
                Id = 1,
                TypeName = "Deposit",
                Debit = false,
                Description = "This is a Deposit Transation (+)"

            },
            new TransactionType
            {
                Id = 2,
                TypeName = "Payment",
                Debit = true,
                Description = "This is a Paymenmt Transation (-)"

            },
            new TransactionType
            {
                Id = 3,
                TypeName = "CashWithdrawl",
                Debit = true,
                Description = "This is a Withdrawl Payment Transation (-)"

            },
             new TransactionType
            {
                Id = 4,
                TypeName = "CashDep",
                Debit = false,
                Description = "This is a Withdrawl Transation (+)"

            },
            new TransactionType
            {
                Id = 5,
                TypeName = "CCPayment",
                Debit = true,
                Description = "This is a Credit Card Paymenmt Transation (-)"

            },
            new TransactionType
            {
                Id = 2,
                TypeName = "Payroll",
                Debit = false,
                Description = "This is a Salary Transation (+)"

            }
        };

        [HttpGet]
        public async Task<ActionResult<List<TransactionType>>> GetTransTypes()
        {
            return Ok(TransactionTypes);
        }
    }
}
