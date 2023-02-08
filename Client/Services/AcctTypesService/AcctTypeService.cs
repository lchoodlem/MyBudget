


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

        public async Task<ServiceResponse<AcctType>> GetAcctTypeById(int acctTypeId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<AcctType>>($"api/accttype/{acctTypeId}");
            return result;
        }

        public async Task GetAcctTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<AcctType>>>("api/acctType");
            if (result != null && result.Data != null)
                AcctTypes = result.Data;
        }
    }
}
