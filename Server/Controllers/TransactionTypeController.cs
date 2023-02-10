using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeSerrvice _transactionTypeService;

        public TransactionTypeController(ITransactionTypeSerrvice transactionTypeService)
        {
           
            _transactionTypeService = transactionTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TransactionType>>>> GetTransTypes()
        {
            var result = await _transactionTypeService.GetTransactionTypes();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AcctType>>> GetAccountType(int id)
        {
            var result = await _transactionTypeService.GetTransactionTypeById(id);
            return Ok(result);

        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TransactionType>>>> DeleteAccount(int id)
        {
            var result = await _transactionTypeService.DeleteTransactionType(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TransactionType>>>> AddAccount(TransactionType transType)
        {
            var result = await _transactionTypeService.AddTransactionType(transType);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TransactionType>>>> UpdateAccount(TransactionType transType)
        {
            var result = await _transactionTypeService.UpdateTransactionType(transType);
            return Ok(result);
        }
    }
}
