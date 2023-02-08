using MyBudget.Shared;

namespace MyBudget.Server.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly DataContext _context;
        private Organization? organization;

        public OrganizationService(DataContext context)
        {
            _context = context;
        }

        private async Task<Organization> GetOrganizationForEdit(int id)
        {
            return await _context.Organizations.FirstOrDefaultAsync(o => o.Id == id);
        }

        
        public async Task<ServiceResponse<List<Organization>>> AddOrganization(Organization organization)
        {
            var foundOrganization = await _context.Organizations.FirstOrDefaultAsync(o => o.Name == organization.Name);
            if (foundOrganization != null)
            {
                return new ServiceResponse<List<Organization>>
                {
                    Success = false,
                    Message = $"Organization: '{organization.Name}' already exists"
                };
            }
            organization.Editing = organization.IsNew = false;
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return await GetOrganizations();
        }

        public async Task<ServiceResponse<List<Organization>>> DeleteOrganization(int id)
        {
            var dbOrganization = await GetOrganizationForEdit(id);
            if (dbOrganization == null)
            {
                return new ServiceResponse<List<Organization>>
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            dbOrganization.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetOrganizations();

        }

        public async Task<ServiceResponse<Organization>> GetOrganizationById(int organizationId)
        {
            var response = new ServiceResponse<Organization>();
            var orgainzation = await _context.Organizations.FindAsync(organizationId);
            if (organization == null)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Organization: '{organizationId}' does not exist";
            }
            else
            {
                response.Data = organization;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Organization>>> GetOrganizations()
        {
            var organizations = await _context.Organizations.ToListAsync();
            return new ServiceResponse<List<Organization>>()
            {
                Data = organizations
            };

        }

        public async Task<ServiceResponse<List<Organization>>> UpdateOrganization(Organization organization)
        {
            var dbOrganization = await GetOrganizationForEdit(organization.Id);
            if (dbOrganization == null)
            {
                return new ServiceResponse<List<Organization>>
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            dbOrganization.Name = organization.Name;
            dbOrganization.Phone1 = organization.Phone1;
            dbOrganization.Phone2 = organization.Phone2;
            dbOrganization.Address1 = organization.Address2;


            await _context.SaveChangesAsync();

            return await GetOrganizations();
        }

    }
}
