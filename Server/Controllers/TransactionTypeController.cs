using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TransactionType>>>> GetTransTypes()
        {
            var transactions = await _context.TransactionTypes.ToListAsync();
            var response = new ServiceResponse<List<TransactionType>>()
            {
                Data = transactions
            };
            return Ok(response);
        }
    }
}
