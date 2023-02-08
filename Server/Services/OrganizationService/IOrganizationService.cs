namespace MyBudget.Server.Services.OrganizationService
{
    public interface IOrganizationService
    {
        Task<ServiceResponse<List<Organization>>> GetOrganizations(); // don't worry about lack of async in name
        Task<ServiceResponse<Organization>> GetOrganizationById(int organizationId);

        Task<ServiceResponse<List<Organization>>> AddOrganization(Organization organization);
        Task<ServiceResponse<List<Organization>>> UpdateOrganization(Organization organization);
        Task<ServiceResponse<List<Organization>>> DeleteOrganization(int id);
    }
}
