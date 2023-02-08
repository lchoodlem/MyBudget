using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<Organization>>> GetOrganizations()
        {
            var result = await _orgainzationService.GetOrganizations();          
            return Ok(result);
        }
        [HttpDelete]
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
