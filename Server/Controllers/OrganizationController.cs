using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly DataContext _context;

        public OrganizationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Organization>>> GetAccountTypes()
        {
            var orgs = await _context.Organizations.ToListAsync();
            var response = new ServiceResponse<List<Organization>>()
            {
                Data = orgs
            };
            return Ok(response);
        }
    }
}
