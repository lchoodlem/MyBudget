using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcctTypeController : ControllerBase
    {
       
        private readonly IAcctTypeService _acctTypeService;

        public AcctTypeController(IAcctTypeService acctTypeService)
        {
           
            _acctTypeService = acctTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AcctType>>>> GetAccountTypes()
        {
            var result = await _acctTypeService.GetAllAcctTypesAsync();
            return Ok(result);
        }
        [HttpGet("{acctTypeId}")]
        public async Task<ActionResult<ServiceResponse<AcctType>>> GetAccountType(int acctTypeId)
        {
           var result = await _acctTypeService.GetAcctTypeAsync(acctTypeId);
            return Ok(result);

        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<AcctType>>>> DeleteAcctType(int id)
        {
            var result = await _acctTypeService.DeleteAccountType(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AcctType>>>> AddAccount(AcctType accountType)
        {
            var result = await _acctTypeService.AddAccountType(accountType);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<AcctType>>>> UpdateAccount(AcctType accountType)
        {
            var result = await _acctTypeService.UpdateAccountType(accountType);
            return Ok(result);
        }

    }
}
