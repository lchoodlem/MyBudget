﻿namespace MyBudget.Client.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _http;

        public event Action OnChange;

        public OrganizationService(HttpClient http)
        {
            _http = http;
        }
        public List<Organization> Organizations { get; set; } = new List<Organization>();

        public async Task GetOrganizations()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Organization>>>("api/organization");
            if(response != null && response.Data != null)
                Organizations= response.Data;
        }

        public async Task<ServiceResponse<Organization>> GetOrganizationById(int organizationId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Organization>>($"api/organization{organizationId}");
            return result;
        }

        public async Task AddOrganization(Organization organization)
        {
            var response = await _http.PostAsJsonAsync("api/Organization", organization);
            Organizations = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Organization>>>()).Data;
            await GetOrganizations();
            OnChange.Invoke();

        }

        public async Task DeleteOrganization(int organizationId)
        {
            var response = await _http.DeleteAsync($"api/Organization/{organizationId}");
            Organizations = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Organization>>>()).Data;
            await GetOrganizations();
            OnChange.Invoke();
        }

        public async Task UpdateOrganization(Organization organization)
        {
            var response = await _http.PutAsJsonAsync("api/Organization", organization);
            Organizations = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Organization>>>()).Data;
            await GetOrganizations();
            OnChange.Invoke();
        }

        public Organization CreateNewOrganization()
        {
            // stub out a new category for the form
            var newOrganization = new Organization { IsNew = true, Editing = true};
            Organizations.Add(newOrganization);
            OnChange.Invoke(); 
            return newOrganization;  
        }
    }
}