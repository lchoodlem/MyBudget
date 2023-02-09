namespace MyBudget.Client.Services.OrganizationService
{
    public interface IOrganizationService
    {
        event Action OnChange;

        List<Organization> Organizations { get; set; }

        Task<IEnumerable<Organization>> GetOrganizations();
        Task<ServiceResponse<Organization>> GetOrganizationById(int organizationId);
        Task AddOrganization(Organization organization);
        Task DeleteOrganization(int organizationId);
        Task UpdateOrganization(Organization organization);
        Organization CreateNewOrganization();

    }
}
