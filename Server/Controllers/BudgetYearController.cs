using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetYearController : ControllerBase
    {
        private readonly IBudgetYearService _budgetYearService;

        public BudgetYearController(IBudgetYearService budgetYearService)
        {
            _budgetYearService = budgetYearService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BudgetYear>>>> GetBudgetYears()
        {
            var result = await _budgetYearService.GetAllBudgetYearAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BudgetYear>>> GetBudgetYearById(int id)
        {
            var result = await _budgetYearService.GetBudgetYearByIdAsync(id);
            return Ok(result);

        }
        [HttpGet("year/{id}")]
        public async Task<ActionResult<ServiceResponse<BudgetYear>>> GetBudgetYearByYear(int year)
        {
            var result = await _budgetYearService.GetBudgetYearByYearAsync(year);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<BudgetYear>>>> DeleteBudgetYear(int id)
        {
            var result = await _budgetYearService.DeleteBudgetYear(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<BudgetYear>>>> AddBudgetYear(BudgetYear account)
        {
            var result = await _budgetYearService.AddBudgetYear(account);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<BudgetYear>>>> UpdateBudgetYear(BudgetYear account)
        {
            var result = await _budgetYearService.UpdateBudgetYear(account);
            return Ok(result);
        }
    }
}
