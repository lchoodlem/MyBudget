using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartDateAmountController : ControllerBase
    {
        private readonly IStartDateAmountService _startDateAmountService;

        public StartDateAmountController(IStartDateAmountService startDateAmountService)
        {
            _startDateAmountService = startDateAmountService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<StartDateAmount>>>> GetStartDateAmounts()
        {
            var result = await _startDateAmountService.GetAllStartDateAmountsAsync();
            return Ok(result);
        }
        [HttpGet("{acctId}")]
        public async Task<ActionResult<ServiceResponse<StartDateAmount>>> GetStartDateAmountById(int acctId)
        {
            var result = await _startDateAmountService.GetStartDateAmountsAsync(acctId);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<StartDateAmount>>>> DeleteStartDateAmount(int id)
        {
            var result = await _startDateAmountService.DeleteStartDateAmount(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<StartDateAmount>>>> AddStartDateAmount(StartDateAmount account)
        {
            var result = await _startDateAmountService.AddStartDateAmount(account);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<StartDateAmount>>>> UpdateStartDateAmount(StartDateAmount account)
        {
            var result = await _startDateAmountService.UpdateStartDateAmount(account);
            return Ok(result);
        }


    }
}
