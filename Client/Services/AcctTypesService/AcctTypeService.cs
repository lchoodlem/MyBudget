
using MyBudget.Shared;

namespace MyBudget.Client.Services.AcctTypesService
{
    public class AcctTypeService : IAcctTypeService
    {
        private readonly HttpClient _http;

        public AcctTypeService(HttpClient http)
        {
            _http = http;
        }
        public List<AcctType> AcctTypes { get; set; } = new List<AcctType>();

        public event Action OnChange;

        public async Task<ServiceResponse<AcctType>> GetAcctTypeById(int acctTypeId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<AcctType>>($"api/acctType/{acctTypeId}");
            return result;
        }

        public async Task<IEnumerable<AcctType>> GetAcctTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<AcctType>>>("api/acctType");
            if (result != null && result.Data != null)
                AcctTypes = result.Data;
            return AcctTypes;
        }

        public async Task AddObject(AcctType obj)
        {
            var response = await _http.PostAsJsonAsync("api/acctType", obj);
            AcctTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<AcctType>>>()).Data;
            await GetAcctTypes();
            OnChange.Invoke();
        }

        public AcctType CreateNewObject()
        {
            // stub out a new category for the form
            var newObj = new AcctType { IsNew = true, Editing = true };
            AcctTypes.Add(newObj);
            OnChange.Invoke();
            return newObj;
        }

        public async Task DeleteObject(int id)
        {
            var response = await _http.DeleteAsync($"api/AcctType/{id}");
            AcctTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<AcctType>>>()).Data;
            await GetAcctTypes();
            OnChange.Invoke();
        }

        public async Task UpdateObject(AcctType acctType)
        {
            var response = await _http.PutAsJsonAsync("api/AcctType", acctType);
            AcctTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<AcctType>>>()).Data;
            await GetAcctTypes();
            OnChange.Invoke();
        }

    }
}
