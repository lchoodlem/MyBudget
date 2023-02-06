using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcctTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public AcctTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AcctType>>> GetAccountTypes()
        {
            var acctTypes = await _context.AcctTypes.ToListAsync();
            var response = new ServiceResponse<List<AcctType>>()
            {
                Data = acctTypes
            };
            return Ok(response);
        }
    }
}
