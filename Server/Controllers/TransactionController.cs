using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> GetTransactions()
        {
            var result = await _transactionService.GetTransactions();
            return Ok(result);
        }
        [HttpGet("{acctId}")]
        public async Task<ActionResult<ServiceResponse<Transaction>>> GetAcocuntById(int acctId)
        {
            var result = await _transactionService.GetTransactionById(acctId);
            return Ok(result);

        }
        [HttpGet("yr/{yrInt}/mth/{mnthInt}")]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> GetTransactions(int yrInt, int mnthInt)
        {
            var result = await _transactionService.GetTransactions(yrInt, mnthInt);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> DeleteTransaction(int id)
        {
            var result = await _transactionService.DeleteTransaction(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> AddTransaction(Transaction account)
        {
            var result = await _transactionService.AddTransaction(account);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Transaction>>>> UpdateTransaction(Transaction account)
        {
            var result = await _transactionService.UpdateTransaction(account);
            return Ok(result);
        }

    }
}
