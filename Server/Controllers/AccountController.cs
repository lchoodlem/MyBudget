using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> GetAccounts()
        {
            var result = await _accountService.GetAccounts();
            return Ok(result);
        }
        [HttpGet("{acctId}")]
        public async Task<ActionResult<ServiceResponse<Account>>> GetAcocuntById(int acctId)
        {
            var result = await _accountService.GetAccountById(acctId);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> DeleteAccount(int id)
        {
            var result = await _accountService.DeleteAccount(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> AddAccount(Account account)
        {
            var result = await _accountService.AddAccount(account);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> UpdateAccount(Account account)
        {
            var result = await _accountService.UpdateAccount(account);
            return Ok(result);
        }
    }
}
