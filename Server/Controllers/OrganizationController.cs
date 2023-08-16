namespace MyBudget.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
       
        private readonly IOrganizationService _orgainzationService;

        public OrganizationController(IOrganizationService orgainzationService)
        {

            _orgainzationService = orgainzationService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Organization>>>> GetOrganizations()
        {
            var result = await _orgainzationService.GetOrganizations();          
            return Ok(result);
        }
        [HttpGet("{orgId}")]
        public async Task<ActionResult<ServiceResponse<AcctType>>> GetOrganizationById(int orgId)
        {
            var result = await _orgainzationService.GetOrganizationById(orgId);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Organization>>>> DeleteOrganization(int id)
        {
            var result = await _orgainzationService.DeleteOrganization(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Organization>>>> AddOrganization(Organization Organization)
        {
            var result = await _orgainzationService.AddOrganization(Organization);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Organization>>>> UpdateOrganization(Organization Organization)
        {
            var result = await _orgainzationService.UpdateOrganization(Organization);
            return Ok(result);
        }
    }


}
